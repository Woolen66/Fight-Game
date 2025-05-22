using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{
    public GameObject winMenu;
    public TMP_Text winnerText;

    public void FinishGame(string player)
    {
        winMenu.SetActive(true);
        winnerText.text = $"{player} Wins!";
    }

    public void menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
}
