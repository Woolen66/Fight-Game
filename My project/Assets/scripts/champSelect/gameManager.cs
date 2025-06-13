using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] characterPrefabs;
    [SerializeField] private Transform player1Spawn, player2Spawn;

    [Header("Barras de vida")]
    [SerializeField] private LifeBar barraVidaP1, barraVidaP2;

    [Header("Barras de power")]
    [SerializeField] private Image barraPowerP1, barraPowerP2;

    void Start()
    {
        int sel1 = characterSelectionManager.player1Selection;
        int sel2 = characterSelectionManager.player2Selection;

        GameObject p1 = Instantiate(characterPrefabs[sel1], player1Spawn.position, Quaternion.identity);
        Debug.Log($"Jugador 1 instanció: {p1.name}");
        GameObject p2 = Instantiate(characterPrefabs[sel2], player2Spawn.position, Quaternion.Euler(0, 180, 0));

        Debug.Log($"Jugador 2 instanció: {p2.name}");

        // Enlazar controles
        var movement1 = p1.GetComponent<playerMovement>();
        if (movement1 != null) movement1.isPlayer1 = true;

        var movement2 = p2.GetComponent<playerMovement>();
        if (movement2 != null) movement2.isPlayer1 = false;

        p1.GetComponent<PlayerAttack>().isPlayer1 = true;
        p2.GetComponent<PlayerAttack>().isPlayer1 = false;

        // Enlazar barras
        barraVidaP1.SetTarget(p1.GetComponent<CharacterLife>());
        barraVidaP2.SetTarget(p2.GetComponent<CharacterLife>());

        p1.GetComponent<PowerBarController>().powerFill = barraPowerP1;
        p2.GetComponent<PowerBarController>().powerFill = barraPowerP2;
    }
}

