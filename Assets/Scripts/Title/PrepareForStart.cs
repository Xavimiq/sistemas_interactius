using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PrepareForStart : MonoBehaviour
{
    public MeshRenderer model;
    public Color normalColor;
    public Color hoverColor;

    public bool playerInside;

    void Start()
    {
        model.material.color = normalColor;
        playerInside = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!playerInside)
        {
            model.material.color = hoverColor;
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
            model.material.color = normalColor;
            playerInside = false;
        }
        else if (other.CompareTag("Player2"))
        {
            model.material.color = normalColor;
            playerInside = false;
        }
    }
}
