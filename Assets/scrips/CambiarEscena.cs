using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    // M�todo que se asociar� con el bot�n a trav�s del Inspector
    public void CambiarAEscenaNiveles()
    {
        // Cargar la escena con el nombre "niveles"
        SceneManager.LoadScene("niveles");
    }
    public void VolverAlMenu()
    {
        // Cargar la escena del men� (aseg�rate de que el nombre sea correcto)
        SceneManager.LoadScene("menu");
    }

    public void irEstrella()
    {
        // Cargar la escena del men� (aseg�rate de que el nombre sea correcto)
        SceneManager.LoadScene("Tutorial");
    }
    public void irPokemon()
    {
        // Cargar la escena del men� (aseg�rate de que el nombre sea correcto)
        SceneManager.LoadScene("Pokemon");
    }
    public void irDuko()
    {
        // Cargar la escena del men� (aseg�rate de que el nombre sea correcto)
        SceneManager.LoadScene("Duki");
    }
}
