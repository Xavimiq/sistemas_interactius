using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    //public string tagFilter;
    private BasketSpawner basketSpawner;

    public void SetSpawner(BasketSpawner spawner)
    {
        basketSpawner = spawner;
    }

    private void HitByTruck()
    {
        basketSpawner.RemoveFruitFromList(gameObject);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Truck"))
        {
            Destroy(gameObject);
            HitByTruck();
        }

    }
}
