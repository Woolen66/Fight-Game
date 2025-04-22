using UnityEngine;

public class pruebaVida : MonoBehaviour
{
    public float playerLife = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(float damage)
    {
        playerLife -= damage;

        if (playerLife < 0)
        {
            Debug.Log("player1 muerto");
        }
    }
}
