using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audioSrc;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        instance = this;
    }

    public void PlayForOnce(AudioClip clip)
    {
        audioSrc.PlayOneShot(clip);
    }
}
