using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance; // 1

    [HideInInspector]
    public int appleCollected; // 2

    [HideInInspector]
    public int pearCollected; // 3

    public int appleCollectedBeforeTruckAppears;
    public int pearsCollectedBeforeTruckAppears;
    public AppleSpawner appleSpawner;
    public PearSpawner pearSpawner;
    public TruckSpawner truckSpawner;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;

    }
    public void ResetCounters()
    {
        appleCollected = 0;
        pearCollected = 0;
        appleSpawner.canSpawn = true;
        pearSpawner.canSpawn = true;
        UIManager.Instance.UpdateCollectedApples();
        UIManager.Instance.UpdateCollectedPears();
    }
    public void CollectedApples()
    {
        appleCollected++;
        
        Debug.Log("apple collected");
        if (appleCollected == appleCollectedBeforeTruckAppears)
        {
            StopSpawnApples();
            CheckIfSpawnsTruck();
        }
        
    }
    public void CollectedPears()
    {
        pearCollected++;
        Debug.Log("pear collected");
        if (pearCollected == pearsCollectedBeforeTruckAppears)
        {
            StopSpawnPears();
            CheckIfSpawnsTruck();
        }

    }
    private void CheckIfSpawnsTruck()
    {
        if (appleCollected == appleCollectedBeforeTruckAppears && pearCollected == pearsCollectedBeforeTruckAppears)
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
