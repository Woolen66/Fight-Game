using UnityEngine;
using UnityEngine.UI;

public class lifeBar2 : MonoBehaviour
{
    public Image lifeFill;
    private player2Life player2Life;
    private float maxLife;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player2Life = GameObject.Find("player2").GetComponent<player2Life>();
        maxLife = player2Life.playerLife;
    }

    // Update is called once per frame
    void Update()
    {
        lifeFill.fillAmount = player2Life.playerLife / maxLife;
    }
}
