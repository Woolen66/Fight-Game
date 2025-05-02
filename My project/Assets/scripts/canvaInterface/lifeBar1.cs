using UnityEngine;
using UnityEngine.UI;

public class lifeBar1 : MonoBehaviour
{
    public Image lifeFill;
    private player1Life player1Life;
    private float maxLife;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player1Life = GameObject.Find("player1").GetComponent<player1Life>();
        maxLife = player1Life.playerLife;
    }

    // Update is called once per frame
    void Update()
    {
        lifeFill.fillAmount = player1Life.playerLife / maxLife;
    }
}
