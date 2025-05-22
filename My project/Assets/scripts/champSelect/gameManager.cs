using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform player1Spawn;
    public Transform player2Spawn;

    public lifeBar1 barraJugador1; // Asignar en Inspector
    public lifeBar2 barraJugador2; // Asignar en Inspector

    public Image barraPowerJugador1UI; // Esto es la Image del canvas
    public Image barraPowerJugador2UI;

    void Start()
    {
        int p1 = characterSelectionManager.player1Selection;
        int p2 = characterSelectionManager.player2Selection;

        GameObject player1 = Instantiate(characterPrefabs[p1], player1Spawn.position, Quaternion.identity);
        GameObject player2 = Instantiate(characterPrefabs[p2], player2Spawn.position, Quaternion.Euler(0, 180, 0));

        // Asignar las barras de vida ya presentes en la escena
        barraJugador1.SetTarget(player1.GetComponent<player1Life>());
        barraJugador2.SetTarget(player2.GetComponent<player2Life>());

        // Asignar las barras de vida ya presentes en la escena
        Image barraPower1 = GameObject.Find("fillPowerBar1")?.GetComponent<Image>();
        Image barraPower2 = GameObject.Find("fillPowerBar2")?.GetComponent<Image>();

        PowerBarController p1Power = player1.GetComponent<PowerBarController>();
        PowerBarController p2Power = player2.GetComponent<PowerBarController>();

        if (p1Power != null && barraPowerJugador1UI != null)
            p1Power.powerFill = barraPowerJugador1UI;

        if (p2Power != null && barraPowerJugador2UI != null)
            p2Power.powerFill = barraPowerJugador2UI;
    }
}
