using UnityEngine;

public class Destruir : MonoBehaviour
{
    public float posicionDestruccionY; // La posición Y en la que se destruirá la bola

    // Este método se llama cuando este objeto colisiona con otro objeto
    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si la colisión ocurrió con algún objeto
        if (collision.gameObject != null)
        {
            // Comprueba si la posición Y de la bola es menor o igual a la posición de destrucción
            if (transform.position.y <= posicionDestruccionY)
            {
                // Destruye el objeto que colisionó
                Destroy(gameObject);
            }
        }
    }
}