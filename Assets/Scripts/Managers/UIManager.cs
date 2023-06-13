using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Text appleCollectedText;
    public Text pearCollectedText;
    public Text appleObjectiveText;
    public Text pearObjectiveText;
    public GameObject gameOverWindow;
    public GameObject level1Window;
    public GameObject truckAppearsWindow;
    public GameObject level2Window;
    public GameObject level3Window;
    public GameObject level4Window;
    public GameObject victoryWindow;

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
    public void ShowGameOverWindow()
    {
        StartCoroutine(ShowGameOverCoroutine());
    }
    private IEnumerator ShowGameOverCoroutine()
    {
        gameOverWindow.SetActive(true);

        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene("Title 1");
    }
    public void ShowLevel1Window()
    {
        level1Window.SetActive(true);
    }
    public void StopShowLevel1Window()
    {
        level1Window.SetActive(false);
    }
    public void ShowTruckAppearsWindow()
    {
        truckAppearsWindow.SetActive(true);
    }
    public void StopShowTruckAppearsWindow()
    {
        truckAppearsWindow.SetActive(false);
    }
    public void ShowLevel2Window()
    {
        level2Window.SetActive(true);
    }
    public void StopShowLevel2Window()
    {
        level2Window.SetActive(false);
    }
    public void ShowLevel3Window()
    {
        level3Window.SetActive(true);
    }
    public void StopShowLevel3Window()
    {
        level3Window.SetActive(false);
    }
    public void ShowLevel4Window()
    {
        level4Window.SetActive(true);
    }
    public void StopShowLevel4Window()
    {
        level4Window.SetActive(false);
    }
    public void ShowVictoryWindow()
    {
        victoryWindow.SetActive(true);
    }
    public void StopShowVictoryWindow()
    {
        victoryWindow.SetActive(false);
    }
}
