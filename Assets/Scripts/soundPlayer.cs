using UnityEngine.Audio;
using UnityEngine;

public class soundPlayer : MonoBehaviour
{
    public void playSound(AudioClip clip)
    {
        AudioSource source = Instantiate(GetComponent<AudioSource>());
        source.clip = clip;
        source.Play();
        Destroy(source.gameObject, source.clip.length);
    }
}
