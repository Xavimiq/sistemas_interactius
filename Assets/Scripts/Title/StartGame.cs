using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour
{
    public static StartGame Instance;

    public bool player1Prepared = false;
    public bool player2Prepared = false;

    void Awake()
    {
        Instance = this;

    }
    private void ChangeScene()
    {
        SceneManager.LoadScene("Scene");
    }
    public void PreparedPlayer1()
    {
        player1Prepared = true;
        CheckForStart();
    }
    public void PreparedPlayer2()
    {
        player2Prepared = true;
        CheckForStart();
    }
    private void CheckForStart()
    {
        if(player1Prepared == true && player2Prepared == true)
        {
            ChangeScene();
        }
    }
}
