using System.IO;
using UnityEngine;

public class PlayerDatabase : MonoBehaviour
{
    public static PlayerDatabase Instance;

    private PlayerDataList dataList;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            LoadData();
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void LoadData()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "database.json");
        if (!File.Exists(path))
        {
            Debug.LogError("Archivo JSON no encontrado en: " + path);
            dataList = new PlayerDataList(); // Crear lista vacía si no existe archivo
            SaveData();
            return;
        }

        string jsonString = File.ReadAllText(path);
        dataList = JsonUtility.FromJson<PlayerDataList>(jsonString);

        if (dataList == null || dataList.players == null)
        {
            Debug.LogError("Error al parsear el JSON o la lista de jugadores está vacía.");
            dataList = new PlayerDataList();
        }
    }

    public Player GetPlayerByName(string name)
    {
        if (string.IsNullOrEmpty(name)) return null;
        return dataList.players.Find(p => p.player_id.ToLower() == name.ToLower());
    }

    // Nuevo método: Busca o crea un jugador nuevo si no existe
    public Player GetOrCreatePlayer(string name)
    {
        Player player = GetPlayerByName(name);
        if (player == null)
        {
            player = new Player
            {
                player_id = name,
                stats = new PlayerStats() // Inicializa estadísticas por defecto
            };
            dataList.players.Add(player);
            SaveData();
        }
        return player;
    }

    public void SaveData()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "database.json");
        string json = JsonUtility.ToJson(dataList, true);
        File.WriteAllText(path, json);
    }
}
