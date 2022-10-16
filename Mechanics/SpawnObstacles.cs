using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    [SerializeField] GameObject obstacle;
    [SerializeField] float spawnFrequency;
    [SerializeField] int obstaclesToSpawn = 4;
    [SerializeField] float offSet;
    private GameManager gm;
    private int obstaclesInstantiated;


    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }
    private void Start()
    {
        obstaclesInstantiated = 0;
        InvokeRepeating("SpawnObstacle", 2.0f, spawnFrequency);

    }

    private void Update()
    {
        if (gm.IsPausedGame())
        {
            return;
        }

        //There will be only 4 (or more if changed) obstacles in scene to maintain performance.
        if (obstaclesInstantiated >= obstaclesToSpawn)
        {
            CancelInvoke();
        }
    }

    void SpawnObstacle()
    {
        //Instantiating obstacles in random positiones in Y axis
        float randomHeight = Random.Range(0.5f, -0.5f);
      
        Vector3 obstaclePosition = new Vector3(0f, randomHeight * offSet, 0f);

        Instantiate(obstacle, this.transform.position + obstaclePosition, Random.rotation);
        obstaclesInstantiated++;

    }
}
