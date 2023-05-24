using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance; // 1

    public AudioClip truckClip; // 2
    public AudioClip forestClip; // 3
    public AudioClip fruitCollectedClip; // 4

    private AudioSource truckAudioSource;
    private AudioSource forestAudioSource;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this; // 1
        truckAudioSource = gameObject.AddComponent<AudioSource>();
        forestAudioSource = gameObject.AddComponent<AudioSource>();
    }
    private void PlaySound(AudioClip clip, AudioSource audioSource) // 1
    {
        audioSource.PlayOneShot(clip); // 2
    }

    public void PlayTruckClip()
    {
        PlaySound(truckClip, truckAudioSource);
    }
    public void StopTruckClip()
    {
        truckAudioSource.Stop();
    }

    public void PlayForestClip()
    {
        forestAudioSource.clip = forestClip;
        forestAudioSource.loop = true;
        forestAudioSource.Play();
    }

    public void PlayFruitCollectedClip()
    {
        PlaySound(fruitCollectedClip, GetComponent<AudioSource>());
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
