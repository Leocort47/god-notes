using UnityEngine;
using System.IO;

public class SpawnManager : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;

    [Header("Spawn Positions")]
    [SerializeField] private Vector3 spawnPositionPrefab1 = new Vector3(1f, 0f, 0f);
    [SerializeField] private Vector3 spawnPositionPrefab2 = new Vector3(2f, 0f, 0f);
    [SerializeField] private Vector3 spawnPositionPrefab3 = new Vector3(3f, 0f, 0f);
    [SerializeField] private Vector3 spawnPositionPrefab4 = new Vector3(4f, 0f, 0f);

    [Header("Destruction Time")]
    [SerializeField] private float destructionTime = 2.05f;

    private void Start()
    {
        string filePath = Application.dataPath + "/tiempos - copia.txt";

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(':');

                if (parts.Length == 2)
                {
                    string key = parts[0].Trim();
                    float time = float.Parse(parts[1].Split(' ')[1].Trim());

                    float adjustedTime = Mathf.Max(0, time - 2.05f);

                    switch (key)
                    {
                        case "Tecla 1":
                            Invoke("SpawnAndDestroyPrefab1", adjustedTime);
                            break;
                        case "Tecla 2":
                            Invoke("SpawnAndDestroyPrefab2", adjustedTime);
                            break;
                        case "Tecla 3":
                            Invoke("SpawnAndDestroyPrefab3", adjustedTime);
                            break;
                        case "Tecla 4":
                            Invoke("SpawnAndDestroyPrefab4", adjustedTime);
                            break;
                        default:
                            Debug.LogWarning("Tecla no reconocida: " + key);
                            break;
                    }
                }
            }
        }
        else
        {
            Debug.LogError("El archivo tiempos - copia.txt no existe.");
        }
    }

    private void SpawnAndDestroyPrefab1()
    {
        GameObject instance = Instantiate(prefab1, spawnPositionPrefab1, Quaternion.identity);
        Destroy(instance, destructionTime);
    }

    private void SpawnAndDestroyPrefab2()
    {
        GameObject instance = Instantiate(prefab2, spawnPositionPrefab2, Quaternion.identity);
        Destroy(instance, destructionTime);
    }

    private void SpawnAndDestroyPrefab3()
    {
        GameObject instance = Instantiate(prefab3, spawnPositionPrefab3, Quaternion.identity);
        Destroy(instance, destructionTime);
    }

    private void SpawnAndDestroyPrefab4()
    {
        GameObject instance = Instantiate(prefab4, spawnPositionPrefab4, Quaternion.identity);
        Destroy(instance, destructionTime);
    }

    public float GetDestructionTime()
    {
        return destructionTime;
    }
}