using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pear : MonoBehaviour
{
    private PearSpawner pearSpawner;
    public string tagFilter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetSpawner(PearSpawner spawner)
    {
        pearSpawner = spawner;
    }

    private void HitByPlayer()
    {
        pearSpawner.RemoveFruitFromList(gameObject);

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
