using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BonesScript : MonoBehaviour
{
    
    

    public void OnCollisionEnter2D(Collision2D collision)
     
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameManager.instance.AddPoint();
            
        }
    }

}
