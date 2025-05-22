using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public TMP_InputField inputName;
    public TMP_Text stats;
    public Button searchButton;

    [System.Serializable]
    public class Stats
    {
        public int wins;
        public int losses;
        public int clean_wins;
        public int total_damage;
        public int special_ability_uses;
    }

    [System.Serializable]
    public class Player
    {
        public string player_id;
        public Stats stats;
    }

    [System.Serializable]
    public class PlayerData
    {
        public List<Player> players;
    }

    private PlayerData playerDatabase;

    void Start()
    {
        try
        {
            string path = Path.Combine(Application.streamingAssetsPath, "database.json");

            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                playerDatabase = JsonConvert.DeserializeObject<PlayerData>(json);
            }
            else
            {
                Debug.LogWarning("database.json not found.");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error loading JSON: " + e.Message);
        }
    }

    public void ShowPlayerStats()
    {
        string name = inputName.text.Trim();

        if (string.IsNullOrEmpty(name))
        {
            stats.text = "Please enter a player name.";
            return;
        }

        Player player = playerDatabase.players.Find(p =>
            p.player_id.Equals(name, System.StringComparison.OrdinalIgnoreCase));

        if (player != null)
        {
            stats.text =
                $"Jugador: {player.player_id}\n" +
                $"Ganadas: {player.stats.wins}\n" +
                $"Perdidas: {player.stats.losses}\n" +
                $"Victorias limpias: {player.stats.clean_wins}\n" +
                $"Daño total: {player.stats.total_damage}\n" +
                $"Habilidad especial usadas: {player.stats.special_ability_uses}";

            
            inputName.gameObject.SetActive(false);
            searchButton.gameObject.SetActive(false);
        }
        else
        {
            stats.text = "Player not found.";
        }
    }


    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
