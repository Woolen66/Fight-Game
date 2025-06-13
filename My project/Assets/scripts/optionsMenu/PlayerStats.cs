using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;
using System;

public class PlayerStatsInfo : MonoBehaviour
{
    public TMP_InputField inputName;
    public TMP_Text stats;
    public Button searchButton;

    private PlayerDataList playerDatabase = new PlayerDataList();
    private string filePath;

    void Start()
    {
        filePath = Path.Combine(Application.streamingAssetsPath, "database.json");

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            playerDatabase = JsonConvert.DeserializeObject<PlayerDataList>(json);
        }
        else
        {
            SaveDatabase(); // Crear archivo vacío
        }
    }

    public void ShowPlayerStats()
    {
        string name = inputName.text.Trim();

        if (string.IsNullOrEmpty(name))
        {
            stats.text = "Por favor, ingresa un nombre de jugador.";
            return;
        }

        Player player = playerDatabase.players.Find(p =>
            p.player_id.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (player == null)
        {
            // Crear nuevo jugador si no existe
            player = new Player { player_id = name };
            playerDatabase.players.Add(player);
            SaveDatabase();

            stats.text = $"Nuevo jugador creado: {name}\n\nEstadísticas iniciales:\n" +
                         $"Ganadas: 0\nPerdidas: 0\nVictorias limpias: 0\nDaño total: 0\nHabilidad especial usadas: 0";
        }
        else
        {
            stats.text =
                $"Jugador: {player.player_id}\n" +
                $"Ganadas: {player.stats.wins}\n" +
                $"Perdidas: {player.stats.losses}\n" +
                $"Victorias limpias: {player.stats.clean_wins}\n" +
                $"Daño total: {player.stats.total_damage}\n" +
                $"Habilidad especial usadas: {player.stats.special_ability_uses}";
        }

        inputName.gameObject.SetActive(false);
        searchButton.gameObject.SetActive(false);
    }

    private void SaveDatabase()
    {
        try
        {
            string json = JsonConvert.SerializeObject(playerDatabase, Formatting.Indented);
            File.WriteAllText(filePath, json);
            Debug.Log("Base de datos actualizada.");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error al guardar JSON: " + e.Message);
        }
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
