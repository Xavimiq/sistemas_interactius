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

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetSpawner(AppleSpawner spawner)
    {
        appleSpawner = spawner;
    }
    private void HitByPlayer(Collider other)
    {
        if (other.CompareTag(tagFilter))
        {
            Destroy(gameObject);
        }
    }
}
