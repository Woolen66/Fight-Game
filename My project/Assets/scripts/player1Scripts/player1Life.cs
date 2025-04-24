using System;
using UnityEngine;

public class player1Life : MonoBehaviour
{
    public int playerLife = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void takeDamage(int damage)
    {
        playerLife -= damage;

        if (playerLife < 0)
        {
            Debug.Log("player1 muerto");
        }
    }
}
