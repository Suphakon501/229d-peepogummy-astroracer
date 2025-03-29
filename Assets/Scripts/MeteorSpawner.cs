using UnityEngine;
using System.Collections;

public class MeteorManager : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float spawnRate = 1.0f;
    public float spawnRadius = 15f;
    public float spawnHeight = 50f;
    public float fallSpeed = 200f;

    private Transform player;

    void Start()
    {
        StartCoroutine(FindPlayerAndSpawn());
    }

    IEnumerator FindPlayerAndSpawn()
    {
        while (player == null)
        {
            player = GameObject.FindWithTag("Player")?.transform;
            if (player == null)
            {
                yield return new WaitForSeconds(1f);
            }
        }

        StartCoroutine(SpawnMeteor());
    }

    IEnumerator SpawnMeteor()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            Spawn();
        }
    }

    void Spawn()
    {
        if (player == null) return;

        float randomX = player.position.x + Random.Range(-spawnRadius, spawnRadius);
        float randomZ = player.position.z + Random.Range(-spawnRadius, spawnRadius);
        Vector3 spawnPosition = new Vector3(randomX, spawnHeight, randomZ);

        GameObject meteor = Instantiate(meteorPrefab, spawnPosition, Quaternion.identity);

        // Get the Meteor component and initialize it
        Meteor meteorScript = meteor.GetComponent<Meteor>();
        if (meteorScript != null)
        {
            meteorScript.Initialize(player.position, fallSpeed); // This should now match the Meteor.Initialize method
        }
    }
}
