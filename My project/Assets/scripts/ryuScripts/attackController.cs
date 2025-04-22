using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class attackController : MonoBehaviour
{
    public Transform attackControl;
    public float attackRadio;
    public float attackDamage;
    public Animator animator;
    private float waitTime;
    public movement movementScript;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && waitTime <= 0)
        {
            Attack(attackDamage*1, "punch1");
            waitTime = 0.6f;
            movementScript.transform.GetComponent<movement>().movementLockTimer = waitTime;
        }

        if (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
        }
    }

    private void Attack(float totalAttackDamage, String animation)
    {
        animator.SetTrigger(animation);
        Collider2D[] objetos = Physics2D.OverlapCircleAll(attackControl.position, attackRadio);

        foreach(Collider2D collider in objetos)
        {
            if(collider.CompareTag("Player2")) 
            { 
                collider.transform.GetComponent<pruebaVida>().takeDamage(totalAttackDamage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackControl.position, attackRadio);
    }
}
