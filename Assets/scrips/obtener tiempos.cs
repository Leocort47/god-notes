using UnityEngine;
using System.Collections.Generic;

public class OtroScript : MonoBehaviour
{
    [System.Serializable]
    public struct ObjetoInfo
    {
        public GameObject prefabObjeto;
        public KeyCode teclaObjeto;
        public Vector3 posicionInicial;
    }

    public ObjetoInfo[] objetosInfo; // Asigna los prefabs, teclas y posiciones iniciales en el Inspector
    private bool tiemposRegistrados = false;

    void Start()
    {
        // Encuentra la instancia de RegistroDeTiempos en la escena
        RegistroDeTiempos registroScript = FindObjectOfType<RegistroDeTiempos>();

        // Si los tiempos no han sido registrados, hazlo y marca que ya fueron registrados
        if (!tiemposRegistrados)
        {
            RegistrarTiemposIniciales(registroScript);
            tiemposRegistrados = true;
        }
        else // Si los tiempos ya fueron registrados, instanciar objetos
        {
            InstanciarObjetos(registroScript);
        }
    }

    void RegistrarTiemposIniciales(RegistroDeTiempos registroScript)
    {
        foreach (ObjetoInfo objetoInfo in objetosInfo)
        {
            // Ejemplo de obtener y mostrar los tiempos de la tecla
            List<float> tiemposTecla = registroScript.ObtenerTiemposPorTecla(objetoInfo.teclaObjeto);

            // Guardar los tiempos en PlayerPrefs u otro medio de almacenamiento persistente
            GuardarTiempos(objetoInfo.teclaObjeto, tiemposTecla);
        }
    }

    void InstanciarObjetos(RegistroDeTiempos registroScript)
    {
        foreach (ObjetoInfo objetoInfo in objetosInfo)
        {
            // Ejemplo de obtener y mostrar los tiempos de la tecla
            List<float> tiemposTecla = ObtenerTiempos(objetoInfo.teclaObjeto);

            // Instancia los objetos según los tiempos guardados y la información del objeto
            InstanciarObjetos(tiemposTecla, objetoInfo);
        }
    }

    void GuardarTiempos(KeyCode tecla, List<float> tiempos)
    {
        string clave = tecla.ToString();
        string valor = string.Join(",", tiempos.ConvertAll(x => x.ToString()).ToArray());

        PlayerPrefs.SetString(clave, valor);
        PlayerPrefs.Save(); // Guarda los cambios
    }

    List<float> ObtenerTiempos(KeyCode tecla)
    {
        string clave = tecla.ToString();
        if (PlayerPrefs.HasKey(clave))
        {
            string valor = PlayerPrefs.GetString(clave);
            return new List<float>(System.Array.ConvertAll(valor.Split(','), float.Parse));
        }
        else
        {
            return new List<float>();
        }
    }

    void InstanciarObjetos(List<float> tiempos, ObjetoInfo objetoInfo)
    {
        foreach (float tiempo in tiempos)
        {
            // Calcula el tiempo desde el inicio del juego
            float tiempoDesdeInicio = Time.time - tiempo;

            // Asegúrate de que el tiempo sea mayor que cero para evitar instancias inmediatas
            if (tiempoDesdeInicio > 0f)
            {
                // Usa la posición inicial especificada en la información del objeto
                Vector3 posicionInicial = objetoInfo.posicionInicial;

                // Instancia el objeto con el componente ObjetoQueSeMueve
                GameObject nuevoObjeto = Instantiate(objetoInfo.prefabObjeto, posicionInicial, Quaternion.identity);
                nuevoObjeto.AddComponent<ObjetoQueSeMueve>();

                // Ajusta el tiempo del componente ObjetoQueSeMueve para que empiece en el tiempo correcto
                ObjetoQueSeMueve componenteMovimiento = nuevoObjeto.GetComponent<ObjetoQueSeMueve>();
                componenteMovimiento.IniciarDesdeTiempo(tiempoDesdeInicio);
            }
        }
    }
}

