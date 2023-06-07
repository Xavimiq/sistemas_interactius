using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pear : MonoBehaviour
{
    private PearSpawner pearSpawner;
    private Vector3 initialPosition;
    private bool isCarried;

    public void SetSpawner(PearSpawner spawner)
    {
        pearSpawner = spawner;
    }

    private void Start()
    {
        initialPosition = transform.position;
        isCarried = false;
    }

    private void HitByPlayer(GameObject player)
    {
        isCarried = true;
        SoundManager.Instance.PlayFruitCollectedClip();
        
        pearSpawner.carryingOn = true;
        
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
            pearSpawner.carryingOn = false;
            GameStateManager.Instance.CollectedPears();
            pearSpawner.RemoveFruitFromList(gameObject);
            Destroy(gameObject);
            isCarried = false;
        }
        else if (other.CompareTag("enemy"))
        {
            if (Vector3.Distance(gameObject.transform.position, initialPosition) > 10f)
            {
                gameObject.transform.position = initialPosition;
                pearSpawner.carryingOn = false;
                gameObject.transform.parent = null;
                isCarried = false;
            }

        }
    }
}
