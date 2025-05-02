using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class player1Life : MonoBehaviour
{
    public float playerLife = 100;
    public Animator animator;
    public player1Movement movementScript;
    public Rigidbody2D rb;

    public void takeDamage(float damage)
    {
        playerLife -= damage;

        if (playerLife <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            return;
        }

        // Animacion de daño
        animator.SetTrigger("hit");

        // Bloquear movimiento temporalmente
        StartCoroutine(HitReaction());
    }

    IEnumerator HitReaction()
    {
        if (movementScript != null)
            movementScript.canMove = false;

        // Empujar un poco hacia la izquierda
        if (rb != null)
            rb.linearVelocity = new Vector2(-2f, rb.linearVelocity.y);

        yield return new WaitForSeconds(0.4f); // Duracion de la animacion de daño

        if (movementScript != null)
            movementScript.canMove = true;
    }
}
