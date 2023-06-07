using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance; // 1

    public AudioClip truckClip; // 2
    public AudioClip hornClip;
    public AudioClip forestClip; // 3
    public AudioClip fruitCollectedClip; // 4
    public AudioClip ticTacClip;
    public AudioClip alarmClip;

    private AudioSource truckAudioSource;
    private AudioSource forestAudioSource;
    private AudioSource ticTacAudioSource;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this; // 1
        truckAudioSource = gameObject.AddComponent<AudioSource>();
        forestAudioSource = gameObject.AddComponent<AudioSource>();
        ticTacAudioSource = gameObject.AddComponent<AudioSource>();
    }
    
    private void PlaySound(AudioClip clip, AudioSource audioSource) // 1
    {
        audioSource.PlayOneShot(clip); // 2
    }

    public void PlayTruckClip()
    {
        //PlaySound(truckClip, truckAudioSource);
        truckAudioSource.clip = truckClip;
        truckAudioSource.loop = true;
        truckAudioSource.Play();
    }
    public void StopTruckClip()
    {
        truckAudioSource.Stop();
    }

    public void PlayHornClip()
    {
        PlaySound(hornClip, GetComponent<AudioSource>());
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

    public void PlayTicTacClip()
    {
        ticTacAudioSource.clip = ticTacClip;
        ticTacAudioSource.loop = true;
        ticTacAudioSource.Play();
    }
    public void StopTicTacClip()
    {
        ticTacAudioSource.Stop();
    }

    public void PlayAlarmClip()
    {
        PlaySound(alarmClip, GetComponent<AudioSource>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
