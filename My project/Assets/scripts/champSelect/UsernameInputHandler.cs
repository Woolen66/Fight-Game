using TMPro;
using UnityEngine;

public class UsernameInputHandler : MonoBehaviour
{
    public int playerNumber;
    public TMP_InputField inputField;
    public characterSelectionManager manager;

    public void OnConfirmUsername()
    {
        if (manager != null && inputField != null)
        {
            string username = inputField.text;
            manager.SetPlayerUsername(playerNumber, username);
            Debug.Log($"Jugador {playerNumber} ingresó el nombre: {username}");
        }
        else
        {
            Debug.LogError("Falta asignar manager o inputField en el UsernameInputHandler.");
        }
    }
}
