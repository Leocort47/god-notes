using UnityEngine;
using UnityEngine.UI;

public class OtraEscenaManager : MonoBehaviour
{
    public Text textoPuntuacion;
    public Text textoNotasCreadas;
    public Text textoRango;

    void Start()
    {
        MostrarPuntuacionYNotas();
        CalcularRango();
    }

    void MostrarPuntuacionYNotas()
    {
        // Recupera la puntuación almacenada en PlayerPrefs
        int puntuacion = PlayerPrefs.GetInt("PuntuacionTotal", 0);
        // Recupera la cantidad de notas creadas almacenada en PlayerPrefs
        int notasCreadas = PlayerPrefs.GetInt("NotasCreadas", 0);

        // Convierte el valor de la puntuación y notas a cadena antes de asignarlos al Text
        textoPuntuacion.text = puntuacion.ToString();
        textoNotasCreadas.text = notasCreadas.ToString();
    }

    void CalcularRango()
    {
        // Recupera la puntuación almacenada en PlayerPrefs
        int puntuacion = PlayerPrefs.GetInt("PuntuacionTotal", 0);
        // Recupera la cantidad de notas creadas almacenada en PlayerPrefs
        int notasCreadas = PlayerPrefs.GetInt("NotasCreadas", 0);

        // Evita la división por cero
        if (notasCreadas > 0)
        {
            // Calcula la proporción de aciertos
            float proporcionAciertos = (float)puntuacion / notasCreadas;

            // Asigna el rango según la proporción de aciertos
            if (proporcionAciertos >= 0.9f)
            {
                textoRango.text = "S";
            }
            else if (proporcionAciertos >= 0.7f)
            {
                textoRango.text = "A";
            }
            else if (proporcionAciertos >= 0.5f)
            {
                textoRango.text = "B";
            }
            else
            {
                textoRango.text = "C";
            }
        }
        else
        {
            // Manejar el caso donde no se hayan creado notas
            textoRango.text = "Rango: Sin notas creadas";
        }
    }
}

