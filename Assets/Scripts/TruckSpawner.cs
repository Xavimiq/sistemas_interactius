using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckSpawner : MonoBehaviour
{
    public bool isSpawning = false;
    public bool canSpawn = false;
    public GameObject truckPrefab;
    public List<Transform> TruckSpawnPositions = new List<Transform>();
    public float timeBetweenSpawns = 0;
    private List<GameObject> truckList = new List<GameObject>(); // 5
    

    private void SpawnTruck()
    {
        Vector3 spawnPosition = TruckSpawnPositions[0].position;
        GameObject truck = Instantiate(truckPrefab, spawnPosition, truckPrefab.transform.rotation); // 2
        truckList.Add(truck); // 3
        truck.GetComponent<Truck>().SetSpawner(this); // 4
        canSpawn = false;
        isSpawning = false;
    }

    private void NumberOfTrucks()
    {
        if (canSpawn)
        {
            if (truckList.Count < 1 && !isSpawning)
            {
                isSpawning = true;
                Invoke("SpawnTruck", timeBetweenSpawns);
            }
        }
    }
    
    public void RemoveTruckFromList(GameObject truck)
    {
        truckList.Remove(truck);
        
    }
    public void DestroyAllFruit()
    {
        foreach (GameObject truck in truckList) // 1
        {
            Destroy(truck); // 2
        }

        truckList.Clear();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    void Update()
    {
        NumberOfTrucks();
    }
    
}
