using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketSpawner : MonoBehaviour
{
    public bool canSpawn = true;
    public GameObject basketPrefab;
    public List<Transform> basketSpawnPositions = new List<Transform>();
    public GameObject appleModel;
    public GameObject pearModel;
    private Vector3 initialPosition;
    private List<GameObject> basketList = new List<GameObject>();

    private void SpawnBasket()
    {
        Vector3 randomPosition = basketSpawnPositions[Random.Range(0, basketSpawnPositions.Count)].position; // 1
        GameObject basket = Instantiate(basketPrefab, randomPosition, basketPrefab.transform.rotation); // 2
        basketList.Add(basket);
        basket.GetComponent<Basket>().SetSpawner(this);
    }
    public void InstantiateApple(GameObject basket)
    {
        initialPosition = basket.transform.position;
        Vector3 displacement = new Vector3(-1f, 0f, 0f);
        Vector3 newPosition = initialPosition + displacement;
        GameObject apple = Instantiate(appleModel, newPosition, appleModel.transform.rotation);
        apple.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        BoxCollider boxCollider = apple.GetComponent<BoxCollider>();
        apple.transform.parent = basket.transform;
    }
    public void InstantiatePear(GameObject basket)
    {
        initialPosition = basket.transform.position;
        Vector3 displacement = new Vector3(1f, 0f, 0f);
        Vector3 newPosition = initialPosition + displacement;
        GameObject pear = Instantiate(pearModel, newPosition, pearModel.transform.rotation);
        pear.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        BoxCollider boxCollider = pear.GetComponent<BoxCollider>();
        pear.transform.parent = basket.transform;
    }
    private void NumberOfBaskets()
    {
        if (basketList.Count < 1)
        {
            SpawnBasket();
        }
    }
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
        SpawnBasket();
    }
    // Update is called once per frame
    void Update()
    {
        NumberOfBaskets();
    }
}
