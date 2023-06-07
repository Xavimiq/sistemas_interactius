using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PearSpawner : MonoBehaviour
{
    public bool canSpawn = false;
    public bool carryingOn = false;
    public GameObject pearPrefab;
    public List<Transform> FruitSpawnPositions = new List<Transform>();
    //public float timeBetweenSpawns;
    public int numberOfPears;
    private List<GameObject> pearList = new List<GameObject>(); // 5
    float _overlapRadius = 1f;
    
    private void Awake()
    {
        canSpawn = false;
    }

    private void SpawnFruit()
    {
        Transform spawnPoint = FruitSpawnPositions[Random.Range(0, FruitSpawnPositions.Count)]; // 1
        Vector3 randomPosition = spawnPoint.position;
        Collider[] hitColliders = Physics.OverlapSphere(randomPosition, _overlapRadius);
        bool isFruitPresent = false;

        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("fruit"))
            {
                isFruitPresent = true;
                Debug.Log("There is an apple in this spawn spot");
                SpawnFruit();
                break;
            }
        }
        if(!isFruitPresent)
        {
            GameObject pear = Instantiate(pearPrefab, randomPosition, pearPrefab.transform.rotation); // 2
            pearList.Add(pear);
            
            pear.GetComponent<Pear>().SetSpawner(this);
        }
        
    }
    private void NumberOfPears()
    {
        if (canSpawn) { 
            if (!carryingOn)
            {
                if (pearList.Count < numberOfPears)
                {
                    SpawnFruit();
                }
            }

        }
    }
    /*
    private IEnumerator SpawnRoutine() // 1
    {
        while (canSpawn) // 2
        {
            SpawnFruit(); // 3
            yield return new WaitForSeconds(timeBetweenSpawns); // 4
        }
    }
    */
    public void RemoveFruitFromList(GameObject pear)
    {
        pearList.Remove(pear);
    }
    public void DestroyAllFruit()
    {
        foreach (GameObject pear in pearList) // 1
        {
            Destroy(pear); // 2
        }

        pearList.Clear();
    }

    
    public void Spawner()
    {
        canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        NumberOfPears();
    }
}
