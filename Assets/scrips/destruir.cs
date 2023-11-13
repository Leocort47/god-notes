using UnityEngine;

public class Destruir : MonoBehaviour
{
   

    // Este método se llama cuando este objeto colisiona con otro objeto
    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si la colisión ocurrió con algún objeto
        if (collision.gameObject != null)
        {
                Destroy(gameObject);

        }
    }
}