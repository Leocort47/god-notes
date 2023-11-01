using UnityEngine;

public class InputChecker : MonoBehaviour
{
    private KeyCode lastKeyPressed;

    [Header("Prefab Settings")]
    [SerializeField] private GameObject notaRojaPrefab;
    [SerializeField] private GameObject notaAzulPrefab;
    [SerializeField] private GameObject notaVerdePrefab;
    [SerializeField] private GameObject notaAmarillaPrefab;

    [Header("Position Settings")]
    [SerializeField] private float targetPositionY = -4.25f; // Posición objetivo en el eje Y
    [SerializeField] private float yErrorMargin = 5f; // Margen de error en el eje Y

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) ||
            Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4))
        {
            lastKeyPressed = GetLastPressedKey();
            CheckInput(lastKeyPressed);
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

    private void CheckInput(KeyCode keyCode)
    {
        GameObject prefabToCheck = GetPrefabForKeyCode(keyCode);

        if (prefabToCheck != null)
        {
            if (IsPrefabWithinYRange(prefabToCheck))
            {
                Debug.Log("Tecla correcta y dentro del margen de error: " + keyToString(keyCode));
            }
            else
            {
                Debug.Log("Tecla correcta, pero fuera del margen de error: " + keyToString(keyCode));
            }
        }
        else
        {
            Debug.Log("Tecla incorrecta: " + keyToString(keyCode));
        }
    }

    private GameObject GetPrefabForKeyCode(KeyCode keyCode)
    {
        // Devuelve el prefab correspondiente a la tecla
        switch (keyCode)
        {
            case KeyCode.Alpha1: return notaRojaPrefab;
            case KeyCode.Alpha2: return notaAzulPrefab;
            case KeyCode.Alpha3: return notaVerdePrefab;
            case KeyCode.Alpha4: return notaAmarillaPrefab;
            default: return null;
        }
    }

    private string keyToString(KeyCode key)
    {
        switch (key)
        {
            case KeyCode.Alpha1: return "Tecla 1";
            case KeyCode.Alpha2: return "Tecla 2";
            case KeyCode.Alpha3: return "Tecla 3";
            case KeyCode.Alpha4: return "Tecla 4";
            default: return "Ninguna";
        }
    }

    private bool IsPrefabWithinYRange(GameObject prefab)
    {
        // Verifica si el prefab está dentro del margen de error en el eje Y
        float prefabY = prefab.transform.position.y;
        return Mathf.Abs(prefabY - targetPositionY) <= yErrorMargin;
    }
}

