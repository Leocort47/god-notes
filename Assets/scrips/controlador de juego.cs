using UnityEngine;

public class ControladorDelJuego : MonoBehaviour
{
    public GameObject prefabObjeto; // Asigna el prefab del objeto en el Inspector
    public float tiempoDeInstanciacion = 5f; // Ajusta el tiempo deseado para instanciar el objeto

    private float tiempoDelJuego = 0f;

    void Update()
    {
        tiempoDelJuego += Time.deltaTime;

        // Verifica si es el momento de instanciar el objeto
        if (tiempoDelJuego >= tiempoDeInstanciacion)
        {
            InstanciarObjeto();
            tiempoDelJuego = 0f; // Reinicia el tiempo para la siguiente instanciación
        }
    }

    void InstanciarObjeto()
    {
        // Instancia el objeto arriba de la pantalla
        GameObject nuevoObjeto = Instantiate(prefabObjeto, new Vector3(Random.Range(-5f, 5f), 10f, 0f), Quaternion.identity);
        
        // Asegúrate de que el objeto tenga el script que controla su movimiento hacia abajo
        nuevoObjeto.AddComponent<ObjetoQueSeMueve>();
    }
}
