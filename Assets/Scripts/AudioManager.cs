using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //code from https://www.youtube.com/watch?v=N8whM1GjH4w
    public AudioSource musicSource;
    public AudioSource SFXSource;

    public AudioClip backgroundMusic;
    public AudioClip skeletonAttack;
    public AudioClip skeletonWalk;
    public AudioClip skeletonHurt;
    public AudioClip skeletonDeath;

    public void PlaySFX(AudioClip sfx, float volume)
    {
        SFXSource.PlayOneShot(sfx, volume);
    }
}
