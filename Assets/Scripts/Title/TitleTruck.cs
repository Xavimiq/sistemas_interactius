using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleTruck : MonoBehaviour
{
    public float movementSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * -movementSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            transform.position = new Vector3(-16.9f, 9.7f, 84.4f);
        }
    }
}
