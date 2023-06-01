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
    public TruckSpawner truckSpawner;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        
    }
    void Start()
    {
        appleObjective = Random.Range(1, 4);
        pearObjective = Random.Range(1, 4);
        UIManager.Instance.UpdateObjectiveApples();
        UIManager.Instance.UpdateObjectivePears();
    }
    public void ResetCounters()
    {
        appleCollected = 0;
        pearCollected = 0;
        appleSpawner.canSpawn = true;
        pearSpawner.canSpawn = true;
        UIManager.Instance.UpdateCollectedApples();
        UIManager.Instance.UpdateCollectedPears();
        appleObjective = Random.Range(1, 4);
        pearObjective = Random.Range(1, 4);
        UIManager.Instance.UpdateObjectiveApples();
        UIManager.Instance.UpdateObjectivePears();
    }
    public void CollectedApples()
    {
        appleCollected++;
        
        Debug.Log("apple collected");
        if (appleCollected == appleObjective)
        {
            StopSpawnApples();
            CheckIfSpawnsTruck();
        }
        
    }
    public void CollectedPears()
    {
        pearCollected++;
        Debug.Log("pear collected");
        if (pearCollected == pearObjective)
        {
            StopSpawnPears();
            CheckIfSpawnsTruck();
        }

    }
    private void CheckIfSpawnsTruck()
    {
        if (appleCollected == appleObjective && pearCollected == pearObjective)
        {
            TruckAppears();
        }
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
