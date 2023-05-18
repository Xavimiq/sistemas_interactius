using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public string tagFilter;
    private AppleSpawner appleSpawner;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetSpawner(AppleSpawner spawner)
    {
        appleSpawner = spawner;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HitByPlayer()
    {
        appleSpawner.RemoveFruitFromList(gameObject);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            HitByPlayer();
        }
      
    }

    
}
