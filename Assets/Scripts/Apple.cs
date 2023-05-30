using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    //public string tagFilter;
    private AppleSpawner appleSpawner;
    //public GameObject applePrefabInstance;

    public void SetSpawner(AppleSpawner spawner)
    {
        appleSpawner = spawner;
    }

    private void HitByPlayer(GameObject player)
    {
        appleSpawner.RemoveFruitFromList(gameObject);
        SoundManager.Instance.PlayFruitCollectedClip();
        
        appleSpawner.carryingOn = true;

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
            appleSpawner.carryingOn = false;
            GameStateManager.Instance.CollectedApples();
            UIManager.Instance.UpdateCollectedApples();
            Destroy(gameObject);
            
        }
    }
}
