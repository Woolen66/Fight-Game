using UnityEngine;
using UnityEngine.SceneManagement;

public class characterSelectionManager : MonoBehaviour
{
    public static int player1Selection = -1;
    public static int player2Selection = -1;

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

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

