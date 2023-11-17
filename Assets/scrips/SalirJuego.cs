using UnityEngine;
using UnityEngine.UI;

public class SalirJuego : MonoBehaviour
{
    void Start()
    {
        // Intenta encontrar el botón automáticamente en el objeto actual.
        Button exitButton = GetComponent<Button>();

        if (exitButton != null)
        {
            // Agrega el listener al botón para que llame a ExitGame cuando se presiona.
            exitButton.onClick.AddListener(ExitGame);
        }
        else
        {
            Debug.LogError("No se encontró el componente Button en el objeto actual.");
        }
    }

    void ExitGame()
    {
        // Salir del juego.
        Debug.Log("Saliendo del juego");
        Application.Quit();
    }
}
