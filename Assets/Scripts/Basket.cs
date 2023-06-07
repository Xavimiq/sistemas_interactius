using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    //public string tagFilter;
    private BasketSpawner basketSpawner;

    public void SetSpawner(BasketSpawner spawner1)
    {
        basketSpawner = spawner1;
    }

    private void HitByTruck()
    {
        basketSpawner.RemoveFruitFromList(gameObject);
        if(GameStateManager.Instance.level != 1)
        {
            Crono.Instance.StopCountdown();
        }
        GameStateManager.Instance.level++;
        GameStateManager.Instance.GamePlay();
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
