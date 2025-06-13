using System.Collections.Generic;

[System.Serializable]
public class PlayerStats
{
    public int wins = 0;
    public int losses = 0;
    public int clean_wins = 0;
    public float total_damage = 0f;
    public int special_ability_uses = 0;
}

[System.Serializable]
public class Player
{
    public string player_id;
    public PlayerStats stats = new PlayerStats();
}

[System.Serializable]
public class PlayerDataList
{
    public List<Player> players = new List<Player>();
}
