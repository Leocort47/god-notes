using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    // Método que se asociará con el botón a través del Inspector
    public void CambiarAEscenaNiveles()
    {
        // Cargar la escena con el nombre "niveles"
        SceneManager.LoadScene("niveles");
    }
    public void VolverAlMenu()
    {
        // Cargar la escena del menú (asegúrate de que el nombre sea correcto)
        SceneManager.LoadScene("menu");
    }

    public void irEstrella()
    {
        // Cargar la escena del menú (asegúrate de que el nombre sea correcto)
        SceneManager.LoadScene("Tutorial");
    }
    public void irPokemon()
    {
        // Cargar la escena del menú (asegúrate de que el nombre sea correcto)
        SceneManager.LoadScene("Pokemon");
    }
    public void irDuko()
    {
        // Cargar la escena del menú (asegúrate de que el nombre sea correcto)
        SceneManager.LoadScene("Duki");
    }
}
