using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController audioController;

    void Start()
    {
        audioController = this;
    }

    public void PlayClip(AudioClip clip, float vol)
    {
        AudioSource aud = new GameObject("Sound Clip", typeof(AudioSource)).GetComponent<AudioSource>();
        aud.volume = vol;
        aud.PlayOneShot(clip);
        Destroy(aud.gameObject, clip.length);
    }
}