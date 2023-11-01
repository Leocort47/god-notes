using UnityEngine;
using System.IO;
using System.Collections; // Añadir esta línea

public class InputChecker : MonoBehaviour
{
    [SerializeField] private string tiemposFileName = "tiempos - copia.txt";
    private string filePath;
    private float startTime;
    private KeyCode lastKeyPressed;

    [Header("Margen de Tiempo")]
    [SerializeField] private float tiempoMargen = 1f;

    private void Start()
    {
        filePath = Application.dataPath + "/" + tiemposFileName;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) ||
            Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4))
        {
            lastKeyPressed = GetLastPressedKey();
            startTime = Time.time; // Registra el tiempo cuando se presiona una tecla
            StartCoroutine(ReadFileAndCheckInput());
        }
    }

    private KeyCode GetLastPressedKey()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) return KeyCode.Alpha1;
        if (Input.GetKeyDown(KeyCode.Alpha2)) return KeyCode.Alpha2;
        if (Input.GetKeyDown(KeyCode.Alpha3)) return KeyCode.Alpha3;
        if (Input.GetKeyDown(KeyCode.Alpha4)) return KeyCode.Alpha4;
        return KeyCode.None;
    }

    private IEnumerator ReadFileAndCheckInput()
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(':');

                if (parts.Length == 2)
                {
                    string key = parts[0].Trim();
                    float tiempoRegistrado;

                    if (float.TryParse(parts[1].Split(' ')[1].Trim(), out tiempoRegistrado))
                    {
                        float tiempoDiferencia = Mathf.Abs(tiempoRegistrado - startTime - Time.time);

                        Debug.Log($"Tecla: {key}, Tiempo Diferencia: {tiempoDiferencia}, Margen: {tiempoMargen}");

                        // Comprueba si la tecla fue presionada dentro del rango de tiempo (antes y después)
                        if (lastKeyPressed == keyToKeyCode(key) && tiempoDiferencia <= tiempoMargen)
                        {
                            Debug.Log("Tecla correcta en el tiempo indicado: " + key);
                        }
                        else
                        {
                            Debug.Log("Tecla incorrecta o fuera de tiempo: " + key);
                        }
                    }
                    else
                    {
                        Debug.LogWarning("Error al convertir el tiempo a float en la línea: " + line);
                    }

                    // Espera antes de comprobar la siguiente línea
                    yield return new WaitForSeconds(tiempoMargen);
                }
            }
        }
        else
        {
            Debug.LogError("El archivo " + tiemposFileName + " no existe.");
        }
    }

    private KeyCode keyToKeyCode(string key)
    {
        switch (key)
        {
            case "Tecla 1": return KeyCode.Alpha1;
            case "Tecla 2": return KeyCode.Alpha2;
            case "Tecla 3": return KeyCode.Alpha3;
            case "Tecla 4": return KeyCode.Alpha4;
            default: return KeyCode.None;
        }
    }
}
