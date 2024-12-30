using System.Collections.Generic;
using UnityEngine;

public class SpawnScrap : MonoBehaviour
{
    [Header("Scrap Configuration")]
    public List<GameObject> scrap_Type = new List<GameObject>();
    public List<int> scrap_ToSpawn = new List<int>();

    [Header("Spawn Area Configuration")]
    public Vector2 spawnBoxSize = new Vector2(10f, 10f); // Width and Height of the spawn area
    public float minDistance = 1f; // Minimum distance between objects
    public float maxDistance = 3f; // Maximum distance for random spawn adjustments

    [Header("Spawn Settings")]
    public Transform spawnAreaCenter; // Center of the box space

    private List<Vector2> spawnedPositions = new List<Vector2>(); // Track spawned positions

    private void Start()
    {
        // Prevent random from generating scraps outside bounds
        spawnBoxSize.x -= maxDistance;
        spawnBoxSize.y -= maxDistance;

        SpawnScrapObjects();
    }

    private void SpawnScrapObjects()
    {
        if (scrap_Type.Count != scrap_ToSpawn.Count)
        {
            Debug.LogError("Mismatch between scrap_Type and scrap_ToSpawn list sizes.");
            return;
        }

        for (int i = 0; i < scrap_Type.Count; i++)
        {
            int count = scrap_ToSpawn[i];
            for (int j = 0; j < count; j++)
            {
                Vector2 spawnPosition = GetValidSpawnPosition();
                GameObject spawnedScrap = Instantiate(scrap_Type[i], spawnPosition, Quaternion.identity);
                spawnedScrap.transform.parent = spawnAreaCenter; // Optional: Set as child of the spawn area
            }
        }
    }

    private Vector2 GetValidSpawnPosition()
    {
        Vector2 position;
        int attempts = 0;
        const int maxAttempts = 100; // Prevent infinite loops

        do
        {
            attempts++;
            position = GetRandomPositionInBox();

            // Check if the position is far enough from all previously spawned positions
        } while (!IsPositionValid(position) && attempts < maxAttempts);

        if (attempts >= maxAttempts)
        {
            Debug.LogWarning("Max spawn attempts reached. Position might not meet constraints.");
        }

        spawnedPositions.Add(position);
        return position;
    }

    private Vector2 GetRandomPositionInBox()
    {
        float x = Random.Range(-spawnBoxSize.x / 2f, spawnBoxSize.x / 2f);
        float y = Random.Range(-spawnBoxSize.y / 2f, spawnBoxSize.y / 2f);

        Vector2 randomOffset = Random.insideUnitCircle * Random.Range(minDistance, maxDistance);
        return new Vector2(x, y) + (Vector2)spawnAreaCenter.position + randomOffset;
    }

    private bool IsPositionValid(Vector2 position)
    {
        foreach (Vector2 existingPosition in spawnedPositions)
        {
            if (Vector2.Distance(position, existingPosition) < minDistance)
            {
                return false;
            }
        }
        return true;
    }
}
