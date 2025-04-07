using System.Threading.Tasks;
using UnityEngine;

public class combat : MonoBehaviour
{
    public GameObject hitboxPrefab; // asigna el prefab en el inspector
    public Transform spawnPoint; // punto donde aparecerá la hitbox
    public float hitboxLifetime = 0.5f; // cuánto dura
    public Animator animator;
    private bool antiSpam = false; // se usara un booleano para evitar que el usuario spamee golpes sin que haya terminado la transicion

    public void SpawnHitbox()
    {
        antiSpam = true;
        GameObject hitbox = Instantiate(hitboxPrefab, spawnPoint.position, spawnPoint.rotation);
        Destroy(hitbox, hitboxLifetime); // se destruye después del tiempo dado
        
    }

    public async Task unPunchTime(int milis)
    {
        await Task.Delay(milis);
        animator.SetBool("punch", false);
        antiSpam = false;
    }

    public bool getAntiSpam()
    {
        return antiSpam;
    }

}
