using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PearSpawner : MonoBehaviour
{
    public bool canSpawn = true;
    public GameObject pearPrefab;
    public List<Transform> FruitSpawnPositions = new List<Transform>();
    //public float timeBetweenSpawns;
    public int numberOfPears;
    private List<GameObject> pearList = new List<GameObject>(); // 5
    float _overlapRadius = 1f;


    private void SpawnFruit()
    {
        Vector3 randomPosition = FruitSpawnPositions[Random.Range(0,
        FruitSpawnPositions.Count)].position; // 1
        Collider[] hitColliders = Physics.OverlapSphere(randomPosition, _overlapRadius);
        if (hitColliders.Length != 0)
        {
            Debug.Log("There is an apple in this spawn spot");
            SpawnFruit();
        }
        else
        {
            GameObject pear = Instantiate(pearPrefab, randomPosition, pearPrefab.transform.rotation); // 2
            pearList.Add(pear); // 3
            pear.GetComponent<Pear>().SetSpawner(this); // 4
        }
        
    }
    private void NumberOfPears()
    {
        if(pearList.Count < numberOfPears)
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

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(SpawnRoutine());
        SpawnFruit();
    }

    // Update is called once per frame
    void Update()
    {
        NumberOfPears();
    }
}
