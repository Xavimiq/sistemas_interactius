using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance; // 1

    [HideInInspector]
    public int appleCollected;
    [HideInInspector]
    public int appleObjective;

    [HideInInspector]
    public int pearCollected;
    [HideInInspector]
    public int pearObjective;

    public AppleSpawner appleSpawner;
    public PearSpawner pearSpawner;
    public BasketSpawner basketSpawner;
    public TruckSpawner truckSpawner;
    public int level = 1;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;        
    }
    void Start()
    {
        level = 1;
        GamePlay();
    }
    public void GamePlay()
    {
        if(level == 1)
        {
            StartCoroutine(Level1());
        }
        else if(level == 2)
        {
            StartCoroutine(Level2());
        }
        else if(level == 3)
        {
            StartCoroutine(Level3());
        }
        else if(level == 4)
        {
            StartCoroutine(Level4());
        }
        else if(level == 5)
        {
            StartCoroutine(Victory());
        }
    }
    private IEnumerator Level1()
    {
        UIManager.Instance.ShowLevel1Window();
        yield return new WaitForSeconds(8f);
        UIManager.Instance.StopShowLevel1Window();
        appleSpawner.canSpawn = true;
        pearSpawner.canSpawn = true;
        appleObjective = 2;
        pearObjective = 2;
        UIManager.Instance.UpdateObjectiveApples();
        UIManager.Instance.UpdateObjectivePears();
    }
    private IEnumerator Level2()
    {
        UIManager.Instance.ShowLevel2Window();
        yield return new WaitForSeconds(8f);
        UIManager.Instance.StopShowLevel2Window();
        appleCollected = 0;
        pearCollected = 0;
        appleSpawner.canSpawn = true;
        pearSpawner.canSpawn = true;
        UIManager.Instance.UpdateCollectedApples();
        UIManager.Instance.UpdateCollectedPears();
        appleObjective = 3;
        pearObjective = 3;
        UIManager.Instance.UpdateObjectiveApples();
        UIManager.Instance.UpdateObjectivePears();
        Crono.Instance.StartCountdown(75);
    }
    private IEnumerator Level3()
    {
        UIManager.Instance.ShowLevel3Window();
        yield return new WaitForSeconds(8f);
        UIManager.Instance.StopShowLevel3Window();
        appleCollected = 0;
        pearCollected = 0;
        appleSpawner.canSpawn = true;
        pearSpawner.canSpawn = true;
        UIManager.Instance.UpdateCollectedApples();
        UIManager.Instance.UpdateCollectedPears();
        appleObjective = 3;
        pearObjective = 3;
        UIManager.Instance.UpdateObjectiveApples();
        UIManager.Instance.UpdateObjectivePears();
        Crono.Instance.StartCountdown(60);
    }
    private IEnumerator Level4()
    {
        UIManager.Instance.ShowLevel4Window();
        yield return new WaitForSeconds(8f);
        UIManager.Instance.StopShowLevel4Window();
        appleCollected = 0;
        pearCollected = 0;
        appleSpawner.canSpawn = true;
        pearSpawner.canSpawn = true;
        UIManager.Instance.UpdateCollectedApples();
        UIManager.Instance.UpdateCollectedPears();
        appleObjective = 3;
        pearObjective = 3;
        UIManager.Instance.UpdateObjectiveApples();
        UIManager.Instance.UpdateObjectivePears();
        Crono.Instance.StartCountdown(45);
    }
    private IEnumerator Victory()
    {
        SoundManager.Instance.PlayVictoryClip();
        UIManager.Instance.ShowVictoryWindow();
        yield return new WaitForSeconds(13f);
        UIManager.Instance.StopShowVictoryWindow();
        SceneManager.LoadScene("Title 1");
    }
    public void CollectedApples()
    {
        appleCollected++;
        UIManager.Instance.UpdateCollectedApples();
        if (appleCollected == appleObjective)
        {
            GameObject basket = GameObject.FindGameObjectWithTag("Basket");
            basketSpawner.InstantiateApple(basket);
            StopSpawnApples();
            CheckIfSpawnsTruck();
        }
        
    }
    public void CollectedPears()
    {
        pearCollected++;
        UIManager.Instance.UpdateCollectedPears();
        if (pearCollected == pearObjective)
        {
            GameObject basket = GameObject.FindGameObjectWithTag("Basket");
            basketSpawner.InstantiatePear(basket);
            StopSpawnPears();
            CheckIfSpawnsTruck();
        }

    }
    private void CheckIfSpawnsTruck()
    {
        if (appleCollected == appleObjective && pearCollected == pearObjective)
        {
            if(level == 1)
            {
                StartCoroutine(ShowTruckInformation());
            }
            TruckAppears();
        }
    }
    private IEnumerator ShowTruckInformation()
    {
        UIManager.Instance.ShowTruckAppearsWindow();
        yield return new WaitForSeconds(8f);
        UIManager.Instance.StopShowTruckAppearsWindow();
    }
    private void StopSpawnApples()
    {
        appleSpawner.canSpawn = false;
        appleSpawner.DestroyAllFruit();
    }
    private void StopSpawnPears()
    {
        pearSpawner.canSpawn = false;
        pearSpawner.DestroyAllFruit();
    }
    private void TruckAppears()
    {
        truckSpawner.canSpawn = true;
    }
    public void GameOver()
    {
        StopSpawnApples();
        StopSpawnPears();
        UIManager.Instance.ShowGameOverWindow();
    } 
}
