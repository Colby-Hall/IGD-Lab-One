using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody ballBody;
    private int goodPickups;
    private int badPickups;

    public float speedMult;
    public Text scoreText;
    public Text winText;
    public Text lossText;




    private void Start()
    {
        ballBody = GetComponent<Rigidbody>();
        goodPickups = 0;
        badPickups = 0;
        setScore();
        winText.text = "";
        lossText.text = "";
    }



    private void setScore()
    {
        scoreText.text = "Score: " + ((10 * (goodPickups - badPickups)).ToString());
        if (badPickups >= 3)
        {
            lossText.text = "You lost :( Play again? Y/N";
        }
        else if (10 * (goodPickups - badPickups) >= 70)
        {
            winText.text = "You Win! Play again? Y/N";
            
        }
     }



    private void FixedUpdate()
    {
        float moveHori = Input.GetAxis("Horizontal");
        float moveVert = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(moveHori, 0, moveVert);

        
        ballBody.AddForce(movement * speedMult);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (badPickups < 3 && 10 * (goodPickups - badPickups) < 70)
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
