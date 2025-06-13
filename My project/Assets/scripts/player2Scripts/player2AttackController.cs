using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class player2AttackController : MonoBehaviour
{
    [Header("Puñetazo 1")]
    public Transform punch1Control;
    public float punch1Radio;

    [Header("Puñetazo 2")]
    public Transform punch2Control;
    public float punch2Radio;

    [Header("Patada")]
    public Transform kickControl;
    public float kickRadio;

    [Header("Daño base")]
    public int attackDamage;
    public Animator animator;
    public float waitTime;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad4) && waitTime <= 0)
        {
            Attack(punch1Control, punch1Radio, attackDamage * 1, "punch1");
            waitTime = 0.6f;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5) && waitTime <= 0)
        {
            Attack(punch2Control, punch2Radio, attackDamage * 1, "punch2");
            waitTime = 1.2f;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad6) && waitTime <= 0)
        {
            Attack(kickControl, kickRadio, attackDamage * 2, "kick");
            waitTime = 1.2f;
        }

        if (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
        }
    }

    private void Attack(Transform control, float radius, int totalAttackDamage, string animation)
    {
        animator.SetTrigger(animation);
        Collider2D[] objetos = Physics2D.OverlapCircleAll(control.position, radius);

        foreach (Collider2D collider in objetos)
        {
            if (collider.CompareTag("Player"))
            {
                collider.transform.GetComponent<player1Life>().takeDamage(totalAttackDamage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (punch1Control != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(punch1Control.position, punch1Radio);
        }

        if (punch2Control != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(punch2Control.position, punch2Radio);
        }

        if (kickControl != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(kickControl.position, kickRadio);
        }
    }
}
