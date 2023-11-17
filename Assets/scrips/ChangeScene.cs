using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChangeScene : MonoBehaviour
{
    public string sceneToLoad = "SampleScene"; // El nombre de la escena a la que quieres cambiar
    public TextMeshProUGUI buttonText; // Referencia al componente TextMeshProUGUI del botón

    private void Start()
    {
        if (buttonText == null)
        {
            Debug.LogError("TextMeshProUGUI component not assigned to the script.");
        }
    }

    // Este método se llama cuando se presiona el botón
    public void OnButtonPress()
    {
        SceneManager.LoadScene(sceneToLoad); // Cambia a la escena especificada
    }

    // Método para cambiar el texto del botón (puedes llamar a este método para cambiar el texto desde otro lugar)
    public void SetButtonText(string newText)
    {
        if (buttonText != null)
        {
            buttonText.text = newText;
        }
    }
}
