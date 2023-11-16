using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        // Reinicia el puntaje y la cantidad de notas al iniciar el juego
        ReiniciarPuntuacionYNotas();
    }

    void ReiniciarPuntuacionYNotas()
    {
        // Reinicia el puntaje y la cantidad de notas a cero
        PlayerPrefs.SetInt("PuntuacionTotal", 0);
        PlayerPrefs.SetInt("NotasCreadas", 0);

        // Guarda los cambios en PlayerPrefs
        PlayerPrefs.Save();
    }
}
