using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    public float movementSpeed;
    
    private double stopPointX = 60; // Punto x donde el cami�n se detendr�

    private bool shouldMove = true;
    private bool detention = false;
    //public Transform modelParent; // 1
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

        if (shouldMove)
        {
            transform.Translate(transform.right * -movementSpeed * Time.deltaTime);
            //verificar si el cami�n ha alcanzado el punto de parada
            if (detention)
            {
                shouldMove = true;
            }
            else
            {
                if (transform.position.x >= stopPointX)
                {
                    shouldMove = false; // detener el cami�n
                    SoundManager.Instance.StopTruckClip();
                }
            }            
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Basket"))
        {
            detention = true;
            shouldMove = true; // Permitir que el cami�n se mueva nuevamente despu�s de la colisi�n con el objeto "cesto"
            SoundManager.Instance.PlayTruckClip();
        }
    }
    
}
