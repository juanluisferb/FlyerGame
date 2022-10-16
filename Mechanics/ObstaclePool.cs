using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    [SerializeField] GameObject spawner;
    [SerializeField] float offSet;

    //Object used to recycle obstacles so we don't have to destroy in runtime
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            other.transform.position = spawner.transform.position;
            float randomHeight = Random.Range(0.5f, -0.5f);

            other.transform.position = new Vector3(spawner.transform.position.x, 
                                                   spawner.transform.position.y + randomHeight * offSet, 
                                                   spawner.transform.position.z);
            other.transform.rotation = Random.rotation;

        }
    }
}
