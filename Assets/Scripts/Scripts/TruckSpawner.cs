using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckSpawner : MonoBehaviour
{
    public bool canSpawn = true;
    public GameObject truckPrefab;
    public List<Transform> TruckSpawnPositions = new List<Transform>();
    public float timeBetweenSpawns;
    private List<GameObject> truckList = new List<GameObject>(); // 5
    

    private void SpawnTruck()
    {
        //Vector3 randomPosition = FruitSpawnPositions[Random.Range(0, FruitSpawnPositions.Count)].position; // 1
        Vector3 spawnPosition = TruckSpawnPositions[0].position;
        GameObject truck = Instantiate(truckPrefab, spawnPosition, truckPrefab.transform.rotation); // 2
        truckList.Add(truck); // 3
        truck.GetComponent<Truck>().SetSpawner(this); // 4
    }
    /*
    private void NumberOfApples()
    {
        if (appleList.Count < numberOfApples)
        {
            SpawnFruit();
        }
    }
    */

    private IEnumerator SpawnRoutine() // 1
    {
        while (canSpawn) // 2
        {
            SpawnTruck(); // 3
            yield return new WaitForSeconds(timeBetweenSpawns); // 4
        }
    }
    
    public void RemoveFruitFromList(GameObject truck)
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
        SpawnTruck();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnRoutine();
    }
}
