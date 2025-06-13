using UnityEngine;

public class volumeScript : MonoBehaviour
{
    public void SetVolume(float volume)
    {
        GetComponent<AudioSource>().volume = volume;
    }
}
