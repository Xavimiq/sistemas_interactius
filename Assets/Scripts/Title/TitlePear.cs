using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePear : MonoBehaviour
{
    public float movementSpeed;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * movementSpeed * Time.deltaTime);        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            transform.position = new Vector3(-13.5f, 2.3f, 59.3f);
        }
    }
}
