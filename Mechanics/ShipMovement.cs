using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{

    Quaternion maxRotation;
    Quaternion minRotation;
    [SerializeField] float rotationSpeed;
    [SerializeField] float heightMultiplier;
    private GameManager gm;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        minRotation = Quaternion.Euler(0, 0, 45f);
        maxRotation = Quaternion.Euler(0, 0, -45f);

    }


    void Update()
    {
        if (gm.IsPausedGame())
        {
            return;
        }

        //Input of the three main keys, and control of a smoothrotation towards the direction
        if (Input.touchCount > 0)
        {

            transform.Translate(new Vector3(0, heightMultiplier * Time.deltaTime, 0),Space.World);
            this.transform.rotation = Quaternion.Slerp(this.transform.localRotation, minRotation, rotationSpeed * Time.deltaTime);


        }
        else{

            transform.Translate(new Vector3(0, -heightMultiplier * Time.deltaTime, 0), Space.World);
            this.transform.rotation = Quaternion.Slerp(this.transform.localRotation, maxRotation, rotationSpeed * Time.deltaTime);
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") ||
           other.CompareTag("Border"))
        {
            //gm.ManageHighScorePanel();
            gm.LoseGame();
        }
    }

}
