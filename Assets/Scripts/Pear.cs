using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pear : MonoBehaviour
{
    private PearSpawner pearSpawner;
    //public string tagFilter;
 
    public void SetSpawner(PearSpawner spawner)
    {
        pearSpawner = spawner;
    }

    private void HitByPlayer()
    {
        pearSpawner.RemoveFruitFromList(gameObject);
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
