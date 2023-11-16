using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorCollider : MonoBehaviour
{
    public KeyCode teclaActiva = KeyCode.Space;
    private Collider miCollider;
    private bool estaActivo = false;
    public static int puntosTotales = 0;
    public Text textoPuntaje;

    void Start()
    {
        ReiniciarPuntuacion(); // Llama a la función para reiniciar la puntuación al iniciar el juego

        miCollider = GetComponent<Collider>();
        miCollider.enabled = false;

        // Recupera la puntuación almacenada en PlayerPrefs al iniciar la escena
        puntosTotales = PlayerPrefs.GetInt("PuntuacionTotal", 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(teclaActiva) && !estaActivo)
        {
            ActivarCollider();
            Invoke("DesactivarCollider", 0.07f);
            Invoke("VerificarColision", 0.5f);
        }

        ActualizarTextoPuntaje();
    }

    void ActivarCollider()
    {
        if (!estaActivo)
        {
            miCollider.enabled = true;
            estaActivo = true;
        }
    }

    void DesactivarCollider()
    {
        miCollider.enabled = false;
        estaActivo = false;
    }

    void VerificarColision()
    {
        // Verifica si no hubo colisiones después de 0.5 segundos
        if (!ColisionDetectada())
        {
            // No ha habido colisión
            // Puedes agregar aquí cualquier lógica adicional si lo deseas
        }
    }

    bool ColisionDetectada()
    {
        // Verifica si hay algún collider en la posición actual del objeto
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.1f);

        // Excluye el propio collider del objeto actual
        foreach (Collider col in colliders)
        {
            if (col != miCollider)
            {
                return true; // Hay una colisión
            }
        }

        return false; // No hay colisiones
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collider ha entrado en contacto con: " + collision.gameObject.name);

        // Asegúrate de que la colisión no se cuente más de una vez
        if (estaActivo) 
        {
            // Aumenta la puntuación cada vez que hay una colisión
            SumarPunto();
        }
    }

    void SumarPunto()
    {
        puntosTotales++;
        Debug.Log("Punto ganado. Puntos totales: " + puntosTotales);
        ActualizarTextoPuntaje();

        // Guarda la puntuación en PlayerPrefs cada vez que se suma un punto
        PlayerPrefs.SetInt("PuntuacionTotal", puntosTotales);
    }

    void ActualizarTextoPuntaje()
    {
        if (textoPuntaje != null)
        {
            textoPuntaje.text = "Puntuación: " + puntosTotales;
        }
    }

    void ReiniciarPuntuacion()
    {
        // Reinicia la puntuación al valor inicial (en este caso, 0)
        puntosTotales = 0;

        // Actualiza el texto del puntaje
        ActualizarTextoPuntaje();

        // Guarda la puntuación reiniciada en PlayerPrefs
        PlayerPrefs.SetInt("PuntuacionTotal", puntosTotales);
    }
}
