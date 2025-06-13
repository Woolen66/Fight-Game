using UnityEngine;
using UnityEngine.SceneManagement;

public class characterSelectionManager : MonoBehaviour
{
    public static int player1Selection = -1;
    public static int player2Selection = -1;

    public static string player1Username;
    public static string player2Username;

    public static PlayerStats player1Stats;
    public static PlayerStats player2Stats;

    private int currentPlayer = 1;

    public void SelectCharacter(int characterID)
    {
        if (currentPlayer == 1)
        {
            player1Selection = characterID;
            currentPlayer = 2;
            Debug.Log("Jugador 1 eligió personaje " + characterID);
        }
        else if (currentPlayer == 2)
        {
            player2Selection = characterID;
            Debug.Log("Jugador 2 eligió personaje " + characterID);

            // Buscar datos del jugador desde PlayerDatabase antes de cambiar de escena
            player1Stats = PlayerDatabase.Instance.GetPlayerByName(player1Username)?.stats;
            player2Stats = PlayerDatabase.Instance.GetPlayerByName(player2Username)?.stats;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void SetPlayerUsername(int playerNumber, string username)
    {
        if (playerNumber == 1)
            player1Username = username;
        else if (playerNumber == 2)
            player2Username = username;
    }
}
