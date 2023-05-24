using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketSpawner : MonoBehaviour
{
    public bool canSpawn = true;
    public GameObject basketPrefab;
    public List<Transform> basketSpawnPositions = new List<Transform>();
    //public float timeBetweenSpawns;
    //public int numberOfPears;
    private List<GameObject> basketList = new List<GameObject>(); // 5
    //float _overlapRadius = 1f;


    private void SpawnBasket()
    {
        Vector3 randomPosition = basketSpawnPositions[Random.Range(0, basketSpawnPositions.Count)].position; // 1
        //Collider[] hitColliders = Physics.OverlapSphere(randomPosition, _overlapRadius);                    
        GameObject basket = Instantiate(basketPrefab, randomPosition, basketPrefab.transform.rotation); // 2
        basketList.Add(basket);
        basket.GetComponent<Basket>().SetSpawner(this);
        

    }
    
    private void NumberOfBaskets()
    {
        if (basketList.Count < 1)
        {
            //Debug.Log("Less pears than permited");
            SpawnBasket();
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

public void RemoveFruitFromList(GameObject basket)
    {
        basketList.Remove(basket);
    }
    public void DestroyAllFruit()
    {
        foreach (GameObject basket in basketList) // 1
        {
            Destroy(basket); // 2
        }

        basketList.Clear();
    }

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(SpawnRoutine());
        SpawnBasket();
    }

    // Update is called once per frame
    void Update()
    {
        NumberOfBaskets();
    }
}
