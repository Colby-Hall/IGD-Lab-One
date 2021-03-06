﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody ballBody;
    private int goodPickups;
    private int badPickups;
    private double winThresh;
    private double failThresh;
    private int numCubes;
    private bool jumping;

    public float speedMult;
    public Text scoreText;
    public Text winText;
    public Text lossText;
    public Text cubeText;




    private void Start()
    {
        ballBody = GetComponent<Rigidbody>();
        goodPickups = 0;
        badPickups = 0;
        setScore();
        winText.text = "";
        lossText.text = "";
        numCubes = Int32.Parse(cubeText.text) / 2;
        winThresh = Math.Floor(.7 * numCubes);
        failThresh = Math.Floor(.3 * numCubes);

    }



    private void setScore()
    {
        scoreText.text = "Score: " + ((10 * (goodPickups - badPickups)).ToString());
        if (badPickups >= failThresh)
        {
            lossText.text = "You lost :( Play again? Y/N";
        }
        else if (goodPickups >= winThresh)
        {
            winText.text = "You Win! Play again? Y/N";
            
        }
     }



    private void FixedUpdate()
    {
        float moveHori = Input.GetAxisRaw("Horizontal");
        float moveVert = Input.GetAxisRaw("Vertical");
        
        Vector3 movement = new Vector3(moveHori, 0, moveVert);
        Vector3 jump = new Vector3(0, 300, 0);


        if (Input.GetKeyDown(KeyCode.Mouse0) && ballBody.velocity.y == 0)
        {
            ballBody.AddForce(jump);
        }
        ballBody.AddForce(movement * speedMult);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (badPickups < failThresh && goodPickups < winThresh)
        {
            if (other.gameObject.CompareTag("Bad Pickup"))
            {
                Destroy(other.gameObject);
                badPickups += 1;
                setScore();
            }
            else if (other.gameObject.CompareTag("Good Pickup"))
            {
                Destroy(other.gameObject);
                goodPickups += 1;
                setScore();
            }
        }
    }
}
