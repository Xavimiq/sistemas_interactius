using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;



public class StartGame : MonoBehaviour
{
    public static StartGame Instance;
    public GameObject titleWindow;
    public bool player1Prepared = false;
    public bool player2Prepared = false;
    public PrepareForStart prepare1;
    public PrepareForStart2 prepare2;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        TitleSoundManager.Instance.PlayIntroClip();
        titleWindow.SetActive(true);
    }
    private void ChangeScene()
    {
        SceneManager.LoadScene("Scene");
    }
    private void Update()
    {
        if(prepare1.playerInside == true && prepare2.playerInside == true)
        {
            ChangeScene();
        }
    }
}
