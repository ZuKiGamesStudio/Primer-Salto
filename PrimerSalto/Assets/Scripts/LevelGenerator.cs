using UnityEngine;
using System.Collections.Generic;

// Script para generar un nivel infinito en un juego 2D
public class LevelGenerator : MonoBehaviour
{
    public GameObject groundTilePrefab;
    public GameObject obstaclePrefab;

    public int initialGroundTiles = 10;
    public float tileWidth = 3f;
    public float obstacleSpawnChance = 0.3f;

    public float groundY = -5f;
    public float obstacleHeight = -4.2f;
    public float maxTileDistance = 30f; // distancia máxima para destruir tiles viejos

    public Transform player; // referencia al jugador

    private float nextSpawnX = 0f;
    private List<GameObject> spawnedTiles = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < initialGroundTiles; i++)
        {
            SpawnGroundTile();
        }
    }

    void Update()
    {
        // Generar nuevo tile si la cámara está cerca del final
        if (Camera.main.transform.position.x + 10f > nextSpawnX - (initialGroundTiles * tileWidth))
        {
            SpawnGroundTile();
        }

        // Borrar tiles viejos
        RemoveOldTiles();
    }

    void SpawnGroundTile()
    {
        GameObject tile = Instantiate(
            groundTilePrefab,
            new Vector3(nextSpawnX, groundY, 0),
            Quaternion.identity
        );
        spawnedTiles.Add(tile);

        // Obstáculo aleatorio en ancho del tile
        if (Random.value < obstacleSpawnChance)
        {
            float randomOffset = Random.Range(-tileWidth / 2f + 0.5f, tileWidth / 2f - 0.5f);
            Vector3 obstaclePos = new Vector3(nextSpawnX + randomOffset, obstacleHeight, 0);

            GameObject obstacle = Instantiate(obstaclePrefab, obstaclePos, Quaternion.identity);
            obstacle.transform.parent = tile.transform; // Hijo del tile
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
