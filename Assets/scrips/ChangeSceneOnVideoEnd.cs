using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CambioEscena : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        if (videoPlayer != null)
        {
            // Suscribirse al evento de finalización del video
            videoPlayer.loopPointReached += OnVideoEnd;
        }
    }

    // Método que se llama cuando el video llega al final
    private void OnVideoEnd(VideoPlayer vp)
    {
        CambiarASiguienteEscena();
    }

    // Método para cambiar a la escena "Puntuacion"
    private void CambiarASiguienteEscena()
    {
        SceneManager.LoadScene("Puntuacion");
    }
}
