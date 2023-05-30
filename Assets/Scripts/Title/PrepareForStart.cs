using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class PrepareForStart : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            StartGame.Instance.PreparedPlayer1();
        }
        else if (other.CompareTag("Player2"))
        {
            StartGame.Instance.PreparedPlayer2();
        }
    }
}
