using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public bool canSpawn = false;
    public bool carryingOn = false;
    public GameObject applePrefab;
    public List<Transform> FruitSpawnPositions = new List<Transform>();
    //public float timeBetweenSpawns;
    public int numberOfApples;
    private List<GameObject> appleList = new List<GameObject>(); // 5
    float _overlapRadius = 1f;

    private void Awake()
    {
        canSpawn = false;
    }

    private void SpawnFruit()
    {
        Vector3 randomPosition = FruitSpawnPositions[Random.Range(0, FruitSpawnPositions.Count)].position; // 1
        Collider[] hitColliders = Physics.OverlapSphere(randomPosition, _overlapRadius);
        bool isFruitPresent = false;

        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("fruit"))
            {
                isFruitPresent = true;
                Debug.Log("There is a pear in this spawn spot");
                SpawnFruit();
                break;
            }
        }
        if (!isFruitPresent)
        {
            GameObject apple = Instantiate(applePrefab, randomPosition, applePrefab.transform.rotation); // 2
            //currentApple = apple;
            appleList.Add(apple); // 3
            apple.GetComponent<Apple>().SetSpawner(this); // 4
        }
        
    }
    private void NumberOfApples()
    {
        if (canSpawn) {      
            if (!carryingOn)
            {
                if (appleList.Count < numberOfApples)
                {
                    Debug.Log("Spawneo");
                    SpawnFruit();
                }
            }
        }
    }

    //public void CheckTreeCollision(GameObject player)
    //{
    //    if(currentApple != null)
    //    {
    //        Apple apple = currentApple.GetComponent<Apple>();
    //        if(apple != null && apple.IsCarried() && apple.carryingPlayer == player)
    //        {
    //            apple.ResetApple();
    //        }
    //    }
    //}
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
    public void RemoveFruitFromList(GameObject apple)
    {
        appleList.Remove(apple);
    }
    public void DestroyAllFruit()
    {
        foreach (GameObject apple in appleList) // 1
        {
            Destroy(apple); // 2
        }

        appleList.Clear();
    }

    public void InitializeSpawner()
    {
        canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        NumberOfApples();
    }
}
