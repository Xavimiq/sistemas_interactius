using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    private TruckSpawner truckSpawner;
    public string tagFilter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetSpawner(TruckSpawner spawner)
    {
        truckSpawner = spawner;
        SoundManager.Instance.PlayTruckClip();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DestroyTruck"))
        {
            Destroy(gameObject);
            truckSpawner.RemoveTruckFromList(gameObject);
            SoundManager.Instance.StopTruckClip();

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
