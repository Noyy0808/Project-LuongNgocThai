using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform destination;

    //click chuot vao object
    //private void OnMouseDown()
    //{
    //    TeleportToDestination();
    //}

    public void TeleportToDestination()
    {

        //teleport player position to the remaining point
        GameObject.FindGameObjectWithTag("Player").transform.position = destination.position;
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            //Invoke("TeleportToDestination", 0.5f);
            
            TeleportToDestination();

        }
    }
}
