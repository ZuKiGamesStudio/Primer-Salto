using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
    public GameObject groundTilePrefab;
    public GameObject obstaclePrefab;

    public int initialGroundTiles = 10;
    public float tileWidth = 3f;

    public float obstacleSpawnChance = 0.15f;
    public float obstacleSpawnIncreaseRate = 0.01f;
    public float maxObstacleSpawnChance = 0.4f;

    public float groundY = -5f;
    public float obstacleHeight = -4.2f;
    public float maxTileDistance = 30f;

    public Transform player;

    public float speed = 5f;
    public float speedIncreaseRate = 0.1f;
    public float maxSpeed = 12f;

    private float nextSpawnX = 0f;
    private List<GameObject> spawnedTiles = new List<GameObject>();

    private int tilesSpawned = 0;
    private bool canSpawnObstacles = false;

    void Start()
    {
        StartCoroutine(InitialSpawn());
    }

    IEnumerator InitialSpawn()
    {
        // Generar los primeros tiles sin obstáculos
        for (int i = 0; i < initialGroundTiles; i++)
        {
            SpawnGroundTile(false);
        }

        // Esperar 1 segundo antes de permitir spawn de obstáculos
        yield return new WaitForSeconds(1f);
        canSpawnObstacles = true;
    }

    void Update()
    {
        speed = Mathf.Min(maxSpeed, speed + speedIncreaseRate * Time.deltaTime);
        obstacleSpawnChance = Mathf.Min(maxObstacleSpawnChance, obstacleSpawnChance + obstacleSpawnIncreaseRate * Time.deltaTime);

        if (Camera.main.transform.position.x + 10f > nextSpawnX - (initialGroundTiles * tileWidth))
        {
            SpawnGroundTile(canSpawnObstacles);
        }

        RemoveOldTiles();
    }

    void SpawnGroundTile(bool spawnObstacles)
    {
        GameObject tile = Instantiate(
            groundTilePrefab,
            new Vector3(nextSpawnX, groundY, 0),
            Quaternion.identity
        );
        spawnedTiles.Add(tile);
        tilesSpawned++;

        if (spawnObstacles && Random.value < obstacleSpawnChance)
        {
            float randomOffset = Random.Range(-tileWidth / 2f + 0.5f, tileWidth / 2f - 0.5f);
            Vector3 obstaclePos = new Vector3(nextSpawnX + randomOffset, obstacleHeight, 0);

            GameObject obstacle = Instantiate(obstaclePrefab, obstaclePos, Quaternion.identity);
            obstacle.transform.parent = tile.transform;
        }

        nextSpawnX += tileWidth;
    }

    void RemoveOldTiles()
    {
        for (int i = spawnedTiles.Count - 1; i >= 0; i--)
        {
            if (player.position.x - spawnedTiles[i].transform.position.x > maxTileDistance)
            {
                Destroy(spawnedTiles[i]);
                spawnedTiles.RemoveAt(i);
            }
        }
    }
}
