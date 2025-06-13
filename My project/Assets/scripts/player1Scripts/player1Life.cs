using System.Collections;
using UnityEngine;

public class player1Life : CharacterLife
{
    public Animator animator;
    public playerMovement movementScript;
    public Rigidbody2D rb;
    public PowerBarController powerBar;
    private GameObject winObject;

    public string player2;
    public Player player2Data;
    public string player1;
    public Player player1Data;

    void Start()
    {
        winObject = GameObject.FindGameObjectWithTag("PanelUI");
        player2 = characterSelectionManager.player2Username;
        player2Data = PlayerDatabase.Instance.GetPlayerByName(player2);

        player1 = characterSelectionManager.player1Username;
        player1Data = PlayerDatabase.Instance.GetPlayerByName(player1);
    }

    public override void takeDamage(int damage)
    {
        currentLife -= damage;
        player2Data.stats.total_damage += damage;

        if (currentLife <= 0)
        {
            winObject.GetComponent<win>().FinishGame("Player2");
            player2Data.stats.wins += 1;
            player1Data.stats.losses += 1;
            PlayerDatabase.Instance.SaveData();
        }

        if (powerBar.currentPower < powerBar.maxPower)
            powerBar.AddPower(damage);

        animator.SetTrigger("hit");
        StartCoroutine(HitReaction());
    }

    IEnumerator HitReaction()
    {
        if (movementScript != null)
            movementScript.canMove = false;

        if (rb != null)
            rb.linearVelocity = new Vector2(-2f, rb.linearVelocity.y);

        yield return new WaitForSeconds(0.4f);

        if (movementScript != null)
            movementScript.canMove = true;
    }
}
