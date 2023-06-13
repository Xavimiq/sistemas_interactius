using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private AppleSpawner appleSpawner;
    private Vector3 initialPosition;
    private bool isCarried;

    private void Start()
    {
        initialPosition = transform.position;
        isCarried = false;
    }

    public void SetSpawner(AppleSpawner spawner)
    {
        appleSpawner = spawner;
    }

    private void HitByPlayer(GameObject player)
    {
        isCarried = true;
        SoundManager.Instance.PlayFruitCollectedClip();
        
        appleSpawner.carryingOn = true;

        gameObject.transform.position = player.transform.position;
        gameObject.transform.parent = player.transform;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!isCarried)
        {
            if (other.CompareTag("Player1"))
            {
                GameObject player1 = GameObject.FindGameObjectWithTag("Player1");
                HitByPlayer(player1);
            }
            else if (other.CompareTag("Player2"))
            {
                GameObject player2 = GameObject.FindGameObjectWithTag("Player2");
                HitByPlayer(player2);
            }
        }
        else if (other.CompareTag("Basket"))
        {
            appleSpawner.carryingOn = false;
            appleSpawner.RemoveFruitFromList(gameObject);
            GameStateManager.Instance.CollectedApples();
            Destroy(gameObject);
            isCarried = false;
        }
        else if (other.CompareTag("enemy"))
        {
            if (Vector3.Distance(gameObject.transform.position, initialPosition) > 10f)
            {
                SoundManager.Instance.PlayFruitSpawnedClip();
                gameObject.transform.position = initialPosition;
                appleSpawner.carryingOn = false;
                gameObject.transform.parent = null;
                isCarried = false;
            }

        }
    }
}
