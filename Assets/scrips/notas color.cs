using UnityEngine;

public class CambioColorObjeto : MonoBehaviour
{
    public KeyCode tecla;
    public Color colorPresionado;
    private Color colorOriginal;
    private Renderer rendererObjeto;

    private void Start()
    {
        // Obtener la referencia al componente Renderer y almacenar el color original
        rendererObjeto = GetComponent<Renderer>();
        colorOriginal = rendererObjeto.material.color;
    }

    private void Update()
    {
        // Verificar si la tecla está siendo presionada
        if (Input.GetKey(tecla))
        {
            // Cambiar el color del objeto mientras la tecla está presionada
            CambiarColor(colorPresionado);
        }
        else
        {
            // Restaurar el color original cuando la tecla no está presionada
            CambiarColor(colorOriginal);
        }
    }

    private void CambiarColor(Color nuevoColor)
    {
        // Asignar el nuevo color al material del objeto
        rendererObjeto.material.color = nuevoColor;
    }
}
