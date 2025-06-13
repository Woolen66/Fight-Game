using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Puñetazo 1")]
    public Transform punch1Control;
    public float punch1Radius;

    [Header("Puñetazo 2")]
    public Transform punch2Control;
    public float punch2Radius;

    [Header("Patada")]
    public Transform kickControl;
    public float kickRadius;

    [Header("Daño base")]
    public int attackDamage = 10;
    public Animator animator;
    public float waitTime = 0f;

    [Header("Jugador Config")]
    public bool isPlayer1 = true;

    private string opponentTag;

    private void Start()
    {
        opponentTag = isPlayer1 ? "Player2" : "Player1";
    }

    private void Update()
    {
        // Teclas para cada jugador
        KeyCode punch1Key = isPlayer1 ? KeyCode.H : KeyCode.Keypad4;
        KeyCode punch2Key = isPlayer1 ? KeyCode.J : KeyCode.Keypad5;
        KeyCode kickKey = isPlayer1 ? KeyCode.K : KeyCode.Keypad6;

        if (Input.GetKeyDown(punch1Key) && waitTime <= 0)
        {
            Attack(punch1Control, punch1Radius, attackDamage * 1, "punch1");
            waitTime = 0.6f;
        }
        else if (Input.GetKeyDown(punch2Key) && waitTime <= 0)
        {
            Attack(punch2Control, punch2Radius, attackDamage * 1, "punch2");
            waitTime = 1.2f;
        }
        else if (Input.GetKeyDown(kickKey) && waitTime <= 0)
        {
            Attack(kickControl, kickRadius, attackDamage * 2, "kick");
            waitTime = 1.2f;
        }

        if (waitTime > 0)
            waitTime -= Time.deltaTime;
    }

    private void Attack(Transform control, float radius, int totalDamage, string animation)
    {
        if (animator != null)
            animator.SetTrigger(animation);

        Collider2D[] hits = Physics2D.OverlapCircleAll(control.position, radius);

        foreach (var hit in hits)
        {
            if (hit.CompareTag(opponentTag))
            {
                var life = hit.GetComponent<CharacterLife>();
                if (life != null)
                    life.takeDamage(totalDamage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (punch1Control != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(punch1Control.position, punch1Radius);
        }

        if (punch2Control != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(punch2Control.position, punch2Radius);
        }

        if (kickControl != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(kickControl.position, kickRadius);
        }
    }
}
