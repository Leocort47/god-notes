using UnityEngine;
using UnityEngine.UI;

public class NoteCounter : MonoBehaviour
{
    public Text noteCountText; // Referencia al componente Text en el Canvas

    private int noteCounter = 0; // Contador de notas

    // Método para actualizar el contador y el texto en el Canvas
    public void UpdateNoteCount()
    {
        noteCounter++;
        if (noteCountText != null)
        {
            noteCountText.text = "Total Notes: " + noteCounter;
        }
    }
}