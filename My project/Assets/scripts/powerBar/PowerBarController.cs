using UnityEngine;
using UnityEngine.UI;

public class PowerBarController : MonoBehaviour
{
    public Image powerFill;         
    public float maxPower = 50f;   
    public float currentPower = 0f;

    // Llenar la barra proporcionalmente al daño
    public void AddPower(float damage)
    {
        currentPower += damage;

        // Clamp entre 0 y maxPower
        currentPower = Mathf.Clamp(currentPower, 0, maxPower);

        // Actualizar la barra visual
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (powerFill != null)
            powerFill.fillAmount = currentPower / maxPower;
    }

    public void ResetPower()
    {
        currentPower = 0f;
        UpdateUI();
    }
}
