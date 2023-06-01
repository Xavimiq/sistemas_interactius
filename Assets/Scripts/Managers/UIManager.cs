using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Text appleCollectedText;
    public Text pearCollectedText;
    public Text appleObjectiveText;
    public Text pearObjectiveText;
    //public GameObject gameOverWindow;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        
    }
    public void UpdateCollectedApples()
    {
        appleCollectedText.text = GameStateManager.Instance.appleCollected.ToString();
    }

    public void UpdateCollectedPears()
    {
        pearCollectedText.text = GameStateManager.Instance.pearCollected.ToString();
    }
    public void UpdateObjectiveApples()
    {
        appleObjectiveText.text = GameStateManager.Instance.appleObjective.ToString();
    }

    public void UpdateObjectivePears()
    {
        pearObjectiveText.text = GameStateManager.Instance.pearObjective.ToString();
    }
    //public void showgameoverwindow()
    //{
    //    gameoverwindow.setactive(true);
    //}

}
