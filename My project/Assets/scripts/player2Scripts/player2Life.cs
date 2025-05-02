using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player2Life : MonoBehaviour
{
    public float playerLife = 100;
    public Animator animator;
    public player2Movement movementScript; // Asigna el script de movimiento del Player2
    public Rigidbody2D rb; // Asigna el Rigidbody2D del Player2

    public void takeDamage(float damage)
    {
        playerLife -= damage;

        if (playerLife <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            return;
        }

        animator.SetTrigger("hit");
        StartCoroutine(HitReaction());
    }

    IEnumerator HitReaction()
    {
        if (movementScript != null)
            movementScript.canMove = false;

        if (rb != null)
            rb.linearVelocity = new Vector2(2f, rb.linearVelocity.y); // Empuje hacia la derecha

        yield return new WaitForSeconds(0.4f); // Tiempo de bloqueo

        if (movementScript != null)
            movementScript.canMove = true;
    }
}
