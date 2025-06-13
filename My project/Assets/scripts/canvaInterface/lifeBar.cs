using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    [SerializeField] private Image lifeFill;

    private CharacterLife target;
    private float maxLife;

    public void SetTarget(CharacterLife t)
    {
        target = t;
        maxLife = t.MaxLife;
    }

    void Update()
    {
        if (target == null || lifeFill == null || maxLife <= 0) return;

        lifeFill.fillAmount = target.CurrentLife / maxLife;
    }
}