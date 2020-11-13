using UnityEngine.Audio;
using UnityEngine;

public class soundPlayer : MonoBehaviour
{
    public void playSound(AudioClip clip)
    {
        GetComponent<AudioSource>().clip = clip;
        GetComponent<AudioSource>().Play();
    }
}
