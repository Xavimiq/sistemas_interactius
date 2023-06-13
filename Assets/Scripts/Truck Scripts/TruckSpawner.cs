using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckSpawner : MonoBehaviour
{
    public bool canSpawn = false;
    public GameObject truckPrefab;
    public List<Transform> TruckSpawnPositions = new List<Transform>();
    private List<GameObject> truckList = new List<GameObject>();
    
    private void SpawnTruck()
    {
        Vector3 spawnPosition = TruckSpawnPositions[0].position;
        GameObject truck = Instantiate(truckPrefab, spawnPosition, truckPrefab.transform.rotation); // 2
        truckList.Add(truck);
        truck.GetComponent<Truck>().SetSpawner(this);
        canSpawn = false;
    }
    private void NumberOfTrucks()
    {
        if (canSpawn)
        {
            if (truckList.Count < 1)
            {
                SpawnTruck();
            }
        }
    }    
    public void RemoveTruckFromList(GameObject truck)
    {
        truckList.Remove(truck);        
    }
    // Update is called once per frame    
    void Update()
    {
        NumberOfTrucks();
    }   
}
