using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEditor;
//using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [Header("Ship parameters")]
    [SerializeField] private float shipAcc = 10f;
    [SerializeField] private float shipMaxVelocity = 10f;
    [SerializeField] private float shipRotationSpeed = 180f;

   // [SerializeField] private GameManager gm;
    //private int asteroids ; 
    private Rigidbody2D shipRG;
    private bool isAlive = true;
    private bool isAccelerating = false;
    private void Start(){
        shipRG = GetComponent<Rigidbody2D>();
        
     }


    private void HandleShipAcceleration(){
        isAccelerating = Input.GetKey(KeyCode.W);
    }
    private void FixedUpdate(){
        if (isAlive && isAccelerating){
            shipRG.AddForce(shipAcc*transform.up);
            shipRG.velocity = Vector2.ClampMagnitude(shipRG.velocity,shipMaxVelocity);
        }
    }
    private void HandleShipRotation(){
        if(Input.GetKey(KeyCode.A)){
            transform.Rotate(shipRotationSpeed * Time.deltaTime * transform.forward);
        }else if (Input.GetKey(KeyCode.D)){
            transform.Rotate(-shipRotationSpeed * Time.deltaTime * transform.forward);

        }
    }


   
    private void Update(){
        if (isAlive){
            HandleShipAcceleration();
            HandleShipRotation();
        }

        
    }

    

    private void OnCollisionEnter2D(Collision2D enemy){
        GameManager gameManager = FindAnyObjectByType<GameManager>();

        if(enemy.gameObject.CompareTag("Asteroid")){
            Debug.Log("EENMT gound");
            Destroy(enemy.gameObject);
            gameManager.reduceCount();
            int temp = gameManager.enemys();
            Debug.Log(temp);
        } else if(gameManager.enemys() == 0){
            gameManager.GameOver();
            Destroy(gameObject);
        }
        
        
       
        
    }

   


}