using UnityEngine;

public class ObjetoQueSeMueve : MonoBehaviour
{
    public float velocidad = 5f;
    private float tiempoInicio;

    void Update()
    {
        // Mueve el objeto hacia abajo en el eje Y
        transform.Translate(Vector2.down * velocidad * Time.deltaTime);
    }

    public void IniciarDesdeTiempo(float tiempo)
    {
        tiempoInicio = Time.time - tiempo;
    }
}
