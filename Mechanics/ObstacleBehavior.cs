using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    [SerializeField] float speedMultiplier;
    GameManager gm;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (gm.IsPausedGame())
        {
            return;
        }

        //Obstacles will automatically travel towards the player
        transform.Translate(-new Vector3(speedMultiplier * Time.deltaTime, 0, 0), Space.World);
    }
}
