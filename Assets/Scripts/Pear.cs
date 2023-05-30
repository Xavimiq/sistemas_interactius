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

    private void HitByPlayer(GameObject player)
    {
        pearSpawner.RemoveFruitFromList(gameObject);
        SoundManager.Instance.PlayFruitCollectedClip();
        
        pearSpawner.carryingOn = true;
        
        gameObject.transform.position = player.transform.position;
        gameObject.transform.parent = player.transform;
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            GameObject player1 = GameObject.FindGameObjectWithTag("Player1");
            HitByPlayer(player1);
        }
        if (other.CompareTag("Player2"))
        {
            GameObject player2 = GameObject.FindGameObjectWithTag("Player2");
            HitByPlayer(player2);
        }
        if (other.CompareTag("Basket"))
        {
            pearSpawner.carryingOn = false;
            GameStateManager.Instance.CollectedPears();
            UIManager.Instance.UpdateCollectedPears();
            Destroy(gameObject);
        }
    }
}
