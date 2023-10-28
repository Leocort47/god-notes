using UnityEngine;
using System.IO;

public class InputManager : MonoBehaviour
{
    private float startTime;
    private StreamWriter fileWriter;

    private float totalTimeElapsed = 0f;

    private void Start()
    {
        // Abre o crea el archivo en la carpeta "Assets"
        fileWriter = new StreamWriter(Application.dataPath + "/tiempos.txt", true);

        // Inicia el temporizador
        startTime = Time.time;
    }

    private void Update()
    {
        // Actualiza el tiempo total transcurrido
        totalTimeElapsed += Time.deltaTime;

        // Comprueba las teclas 1, 2, 3 y 4
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) ||
            Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4))
        {
            float elapsedTime = Time.time - startTime;
            int keyNumber = GetPressedKeyNumber();

            // Escribe en el archivo la tecla presionada y el tiempo
            fileWriter.WriteLine("Tecla " + keyNumber + ": " + elapsedTime.ToString("F2") + " segundos desde el inicio del juego");
        }
    }

    private int GetPressedKeyNumber()
    {
        // Devuelve el número de la tecla presionada (1, 2, 3 o 4)
        if (Input.GetKeyDown(KeyCode.Alpha1)) return 1;
        if (Input.GetKeyDown(KeyCode.Alpha2)) return 2;
        if (Input.GetKeyDown(KeyCode.Alpha3)) return 3;
        if (Input.GetKeyDown(KeyCode.Alpha4)) return 4;
        return 0; // Valor por defecto
    }

    private void OnDestroy()
    {
        // Cierra el archivo al destruir el objeto
        fileWriter.Close();
    }
}
