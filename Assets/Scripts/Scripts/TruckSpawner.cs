using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckSpawner : MonoBehaviour
{
    public bool canSpawn;
    public GameObject truckPrefab;
    public List<Transform> TruckSpawnPositions = new List<Transform>();
    //public float timeBetweenSpawns;
    private List<GameObject> truckList = new List<GameObject>(); // 5
    

    private void SpawnTruck()
    {
        //Vector3 randomPosition = FruitSpawnPositions[Random.Range(0, FruitSpawnPositions.Count)].position; // 1
        if (canSpawn)
        {
            Vector3 spawnPosition = TruckSpawnPositions[0].position;
            GameObject truck = Instantiate(truckPrefab, spawnPosition, truckPrefab.transform.rotation); // 2
            truckList.Add(truck); // 3
            truck.GetComponent<Truck>().SetSpawner(this); // 4
            canSpawn = false;
        }
        
    }

    private void NumberOfTrucks()
    {
        if (truckList.Count < 1)
        {
            SpawnTruck();
        }
    }
    /*
    private void NumberOfApples()
    {
        if (appleList.Count < numberOfApples)
        {
            SpawnFruit();
        }
    }
    

    private IEnumerator SpawnRoutine() // 1
    {
        while (canSpawn) // 2
        {
            SpawnTruck(); // 3
            Debug.Log("Cuenta");
            //yield return new WaitForSeconds(timeBetweenSpawns); // 4
            canSpawn = false;
        }
    }
    */

    public void RemoveTruckFromList(GameObject truck)
    {
        truckList.Remove(truck);
        canSpawn = true;
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
        NumberOfTrucks();
    }
}
