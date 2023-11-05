using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto con el que colisionó tiene un componente de renderer
        // Puedes ajustar esto según los componentes que desees verificar
        Renderer renderer = collision.gameObject.GetComponent<Renderer>();

        if (renderer != null)
        {
            // Destruye el objeto con el que colisionó
            Destroy(collision.gameObject);
        }
    }
}
