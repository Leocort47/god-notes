using UnityEngine;
using UnityEngine.UI;

public class ControladorCollider : MonoBehaviour
{
    public KeyCode teclaActiva = KeyCode.Space;
    private Collider miCollider;
    private bool estaActivo = false;
    public static int puntosTotales = 0;
    public Text textoPuntaje;

    void Start()
    {
        miCollider = GetComponent<Collider>();
        miCollider.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(teclaActiva) && !estaActivo)
        {
            ActivarCollider();
            Invoke("DesactivarCollider", 0.2f);
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
        // Verifica si no hubo colisiones después de 0.5 segundos y resta un punto si es el caso
        if (!ColisionDetectada())
        {
            // No ha habido colisión, resta un punto
            RestarPunto();
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
            // Aumenta la puntuación compartida cada vez que hay una colisión
            SumarPunto();
        }
    }

    void SumarPunto()
    {
        puntosTotales++;
        Debug.Log("Punto ganado. Puntos totales: " + puntosTotales);
        ActualizarTextoPuntaje();
    }

    void RestarPunto()
    {
        puntosTotales--;
        Debug.Log("No hubo colisión después de 0.5 segundos. Punto restado. Puntos totales: " + puntosTotales);
        ActualizarTextoPuntaje();
    }

    void ActualizarTextoPuntaje()
    {
        if (textoPuntaje != null)
        {
            textoPuntaje.text = "Puntuación: " + puntosTotales;
        }
    }
}

