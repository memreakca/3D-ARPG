using System.Collections;
using UnityEngine;

public class MushroomPack : MonoBehaviour
{
    public Transform[] spawnPositions;
    public GameObject mushroomPrefab;

    public Transform player;

    [SerializeField] private float CheckRange;

    private bool isRespawning = false; // Flag to check if respawn coroutine is running

    private void Start()
    {
        SpawnMushrooms();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        CheckForPlayer();
        CheckMushroomCount();
    }

    private void SpawnMushrooms()
    {
        for (int i = 0; i < spawnPositions.Length; i++)
        {
            GameObject newMushroom = Instantiate(mushroomPrefab, spawnPositions[i].position, Quaternion.identity);
            newMushroom.transform.parent = transform;
        }
    }

    private void CheckForPlayer()
    {
        if (Vector3.Distance(transform.position, player.position) < CheckRange)
        {
            ActivateMushrooms();
        }
    }

    public void ActivateMushrooms()
    {
        foreach (Transform child in transform)
        {
            var mushroom = child.GetComponent<mushroom_enemy_sc>();
            if (mushroom != null)
            {
                mushroom.isActivated = true;
            }
        }
    }

    private void CheckMushroomCount()
    {
        int mushroomCount = 0;
        foreach (Transform child in transform)
        {
            if (child.GetComponent<mushroom_enemy_sc>() != null)
            {
                mushroomCount++;
            }
        }

        if (mushroomCount == 0 && !isRespawning)
        {
            StartCoroutine(RespawnMushrooms());
        }
    }

    private IEnumerator RespawnMushrooms()
    {
        isRespawning = true;
        yield return new WaitForSeconds(45);
        SpawnMushrooms();
        isRespawning = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, CheckRange);
    }
}