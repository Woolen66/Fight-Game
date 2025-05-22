using UnityEngine;
using UnityEngine.UI;

public class lifeBar1 : MonoBehaviour
{
    public Image lifeFill;
    private player1Life player1Life;
    private float maxLife;

    public void SetTarget(player1Life target)
    {
        player1Life = target;
        maxLife = player1Life.playerLife;
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeFill != null)
        lifeFill.fillAmount = player1Life.playerLife / maxLife;
    }

    
}
