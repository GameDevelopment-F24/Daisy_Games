using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollisions : MonoBehaviour
{
   
   
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Asteroid")){
            Debug.Log("Enter");
        }
    }

    private void OnCollisionStay2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Asteroid")){
            Debug.Log("Stay");
        }
    }

    private void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Asteroid")){
            Debug.Log("Exit");
        }
    }
}
