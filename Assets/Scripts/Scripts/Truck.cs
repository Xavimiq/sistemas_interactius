using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    private TruckSpawner truckSpawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetSpawner(TruckSpawner spawner)
    {
        truckSpawner = spawner;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
