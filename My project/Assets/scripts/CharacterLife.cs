using UnityEngine;

public abstract class CharacterLife : MonoBehaviour
{
    [SerializeField] protected float maxLife = 100f;
    public float MaxLife => maxLife;
    public float CurrentLife => currentLife;

    protected float currentLife;

    protected virtual void Awake() => currentLife = maxLife;

    public abstract void takeDamage(int damage);
}
