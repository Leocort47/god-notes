using UnityEngine;
using System.Collections.Generic;

public class RegistroDeTiempos : MonoBehaviour
{
    private Dictionary<KeyCode, List<float>> tiemposPorTecla = new Dictionary<KeyCode, List<float>>();

    void Update()
    {
        // Verifica las teclas 1, 2, 3 y 4
        foreach (KeyCode tecla in new KeyCode[] { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4 })
        {
            if (Input.GetKeyDown(tecla))
            {
                RegistrarTiempo(tecla);
            }
        }
    }

    private void RegistrarTiempo(KeyCode tecla)
    {
        if (!tiemposPorTecla.ContainsKey(tecla))
        {
            tiemposPorTecla[tecla] = new List<float>();
        }

        float tiempoActual = Time.time;
        tiemposPorTecla[tecla].Add(tiempoActual);

        Debug.Log("Tecla '" + tecla.ToString() + "' presionada en el tiempo: " + tiempoActual);
    }

    public List<float> ObtenerTiemposPorTecla(KeyCode tecla)
    {
        if (tiemposPorTecla.ContainsKey(tecla))
        {
            return tiemposPorTecla[tecla];
        }
        else
        {
            return new List<float>();
        }
    }
}


