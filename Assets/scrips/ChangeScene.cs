using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChangeScene : MonoBehaviour
{
    public string sceneToLoad = "SampleScene"; // El nombre de la escena a la que quieres cambiar
    public TextMeshProUGUI buttonText; // Referencia al componente TextMeshProUGUI del bot�n

    private void Start()
    {
        if (buttonText == null)
        {
            Debug.LogError("TextMeshProUGUI component not assigned to the script.");
        }
    }

    // Este m�todo se llama cuando se presiona el bot�n
    public void OnButtonPress()
    {
        SceneManager.LoadScene(sceneToLoad); // Cambia a la escena especificada
    }

    // M�todo para cambiar el texto del bot�n (puedes llamar a este m�todo para cambiar el texto desde otro lugar)
    public void SetButtonText(string newText)
    {
        if (buttonText != null)
        {
            buttonText.text = newText;
        }
    }
}
