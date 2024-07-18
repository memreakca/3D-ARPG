using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DragonSpawner : MonoBehaviour
{
    public GameObject dragonPrefab; 

    private bool dragonSpawned = false;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !dragonSpawned)
        {
            SpawnDragon();
            var collider = GetComponent<SphereCollider>().enabled=false;

        }
    }

    private void SpawnDragon()
    {
        var dragon = Instantiate(dragonPrefab, transform.position, Quaternion.identity);
        dragon.transform.SetParent(transform);
        dragonSpawned = true;
    }
}