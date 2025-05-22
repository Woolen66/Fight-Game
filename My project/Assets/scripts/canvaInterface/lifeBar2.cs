using UnityEngine;
using UnityEngine.UI;

public class lifeBar2 : MonoBehaviour
{
    public Image lifeFill;
    private player2Life player2Life;
    private float maxLife;

    public void SetTarget(player2Life target)
    {
        player2Life = target;
        maxLife = player2Life.playerLife;
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeFill != null)
        lifeFill.fillAmount = player2Life.playerLife / maxLife;
    }


    
}
