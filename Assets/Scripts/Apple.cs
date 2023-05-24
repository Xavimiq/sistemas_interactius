using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    //public string tagFilter;
    private AppleSpawner appleSpawner;

    public void SetSpawner(AppleSpawner spawner)
    {
        appleSpawner = spawner;
    }

    private void HitByPlayer()
    {
        appleSpawner.RemoveFruitFromList(gameObject);
        SoundManager.Instance.PlayFruitCollectedClip();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            Destroy(gameObject);
            HitByPlayer();
        }
      
    }

    
}
