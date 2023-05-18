using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    public float movementSpeed;
    public float horizontalBoundary = 22;
    
    //public Transform modelParent; // 1
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void UpdateMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput < 0 && transform.position.x > -horizontalBoundary)
        {
            transform.Translate(transform.right * -movementSpeed * Time.deltaTime);
        }
        else if (horizontalInput > 0 && transform.position.x < horizontalBoundary)
        {
            transform.Translate(transform.right * movementSpeed * Time.deltaTime);
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * -movementSpeed * Time.deltaTime);
    }
}
