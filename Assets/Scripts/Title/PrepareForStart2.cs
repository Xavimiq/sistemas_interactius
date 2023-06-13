using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PrepareForStart2 : MonoBehaviour
{
    public bool playerInside;

    void Start()
    {
        playerInside = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!playerInside)
        {
            if (other.CompareTag("Player1"))
            {
                playerInside = true;
            }
            else if (other.CompareTag("Player2"))
            {
                playerInside = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            playerInside = false;
        }
        else if (other.CompareTag("Player2"))
        {
            playerInside = false;
        }
    }
}
