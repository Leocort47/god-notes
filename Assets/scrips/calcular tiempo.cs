using UnityEngine;

public class MovimientoObjeto : MonoBehaviour
{
    public float velocidad = 5.0f;
    public float alturaInicial = 6.0f;
    public float alturaFinal = -4.25f;

    private float tiempoTotal;
    private float distanciaVertical; // Declara la variable aquí

    void Start()
    {
        // Calcular la distancia vertical entre las dos alturas
        distanciaVertical = Mathf.Abs(alturaFinal - alturaInicial);

        // Calcular el tiempo total necesario para el movimiento
        tiempoTotal = distanciaVertical / velocidad;
    }

    void Update()
    {
        // Asegurarse de que el tiempo pasado no supere el tiempo total
        if (tiempoTotal > 0)
        {
            // Reducir el tiempo total
            tiempoTotal -= Time.deltaTime;

            // Calcular la posición y actualizar la posición del objeto
            float t = 1 - tiempoTotal / (distanciaVertical / velocidad);
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(alturaInicial, alturaFinal, t), transform.position.z);
        }
        else
        {
            // El objeto ha llegado a su destino
            float tiempoDemorado = Mathf.Abs(alturaFinal - alturaInicial) / velocidad;
            Debug.Log("El objeto ha llegado a su destino. Tiempo demorado: " + tiempoDemorado + " segundos.");
        }
    }
}
