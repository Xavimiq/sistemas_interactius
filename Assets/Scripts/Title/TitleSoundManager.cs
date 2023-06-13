using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSoundManager : MonoBehaviour
{
    public static TitleSoundManager Instance;

    public AudioClip introClip;

    private AudioSource introAudioSource;

    void Awake()
    {
        Instance = this; // 1
        introAudioSource = gameObject.AddComponent<AudioSource>();
    }
    public void PlayIntroClip()
    {
        introAudioSource.clip = introClip;
        introAudioSource.loop = true;
        introAudioSource.Play();
    }
}
