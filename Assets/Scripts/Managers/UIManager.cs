using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public static UIManager Instance; // 1

    public Text appleCollectedText;
    public Text pearCollectedText;
    public GameObject gameOverWindow; // 4

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;

    }
    public void UpdateCollectedApples() // 1
    {
        appleCollectedText.text = GameStateManager.Instance.appleCollected.ToString();
    }

    public void UpdateCollectedPears() // 2
    {
        pearCollectedText.text = GameStateManager.Instance.pearCollected.ToString();
    }
    //public void showgameoverwindow()
    //{
    //    gameoverwindow.setactive(true);
    //}

}
