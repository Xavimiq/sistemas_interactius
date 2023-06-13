using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleApple : MonoBehaviour
{
    public float movementSpeed;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * movementSpeed * Time.deltaTime, Space.World);        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            transform.position = new Vector3(-13.5f, 2.3f, 29.1f);
        }
    }
}
