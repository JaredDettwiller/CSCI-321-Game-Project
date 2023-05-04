using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioClip fairySound;
    private AudioSource speaker;

    private void Start()
    {
        speaker = GetComponent<AudioSource>();
    }

    public void playFairySound()
    {
        speaker.clip = fairySound;
        speaker.loop = false;
        speaker.Play();
    }
}
