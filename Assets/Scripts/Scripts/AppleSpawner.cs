using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public bool canSpawn = true;
    public GameObject applePrefab;
    public List<Transform> FruitSpawnPositions = new List<Transform>();
    //public float timeBetweenSpawns;
    public float numberOfApples;
    private List<GameObject> appleList = new List<GameObject>(); // 5
    float _overlapRadius = 1f;

    private void SpawnFruit()
    {
        Vector3 randomPosition = FruitSpawnPositions[Random.Range(0,
        FruitSpawnPositions.Count)].position; // 1
        Collider[] hitColliders = Physics.OverlapSphere(randomPosition, _overlapRadius);
        if (hitColliders.Length != 0)
        {
            Debug.Log("There is a pear in this spawn spot");
            SpawnFruit();
        }
        else
        {
            GameObject apple = Instantiate(applePrefab, randomPosition,
        applePrefab.transform.rotation); // 2
            appleList.Add(apple); // 3
            apple.GetComponent<Apple>().SetSpawner(this); // 4
        }
        
    }
    private void NumberOfApples()
    {
        if (appleList.Count < numberOfApples)
        {
            SpawnFruit();
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

    // Start is called before the first frame update
    void Start()
    {
        SpawnFruit();
    }

    // Update is called once per frame
    void Update()
    {
        NumberOfApples();
    }
}
