using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketMovement : MonoBehaviour
{
    private bool player2InContact;
    private bool player1InContact;
    private GameObject player1;
    private GameObject player2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            player1InContact = true;
            player1 = other.gameObject;
        }
        else if (other.CompareTag("Player2"))
        {
            player2InContact = true;
            player2 = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player1")){
            player1InContact = false;
            player1 = null;
        }
        else if (other.CompareTag("Player2"))
        {
            player2InContact = false;
            player2 = null;
        }
    }
    void Update()
    {
        if(player1InContact && player1 != null && player2InContact && player2 != null)
        {
            Vector3 middlePoint = (player1.transform.position + player2.transform.position) / 2f;
            transform.position = middlePoint;
        }
    }
}
