using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // Array of objects to spawn
    public GameObject[] obstacles; // Array of obstacle objects
    public Transform leftTarget; // Target on the left side
    public Transform rightTarget; // Target on the right side
    public Vector3 leftSpawnMin; // Minimum spawn position on the left side
    public Vector3 leftSpawnMax; // Maximum spawn position on the left side
    public Vector3 rightSpawnMin; // Minimum spawn position on the right side
    public Vector3 rightSpawnMax; // Maximum spawn position on the right side
    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 5f;

    private bool spawning = true;

    void Start()
    {
        StartCoroutine(SpawnObjectsAtRandomIntervals());
    }

    IEnumerator SpawnObjectsAtRandomIntervals()
    {
        while (spawning)
        {
            // Random time interval between spawns
            float randomInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(randomInterval);

            // Randomly select a side (left or right)
            bool spawnOnLeft = Random.Range(0, 2) == 0;

            // Random position based on the side
            Vector3 randomPosition;
            Transform target;

            if (spawnOnLeft)
            {
                randomPosition = new Vector3(
                    Random.Range(leftSpawnMin.x, leftSpawnMax.x),
                    Random.Range(leftSpawnMin.y, leftSpawnMax.y),
                    Random.Range(leftSpawnMin.z, leftSpawnMax.z)
                );
                target = leftTarget; // Set the target to left
            }
            else
            {
                randomPosition = new Vector3(
                    Random.Range(rightSpawnMin.x, rightSpawnMax.x),
                    Random.Range(rightSpawnMin.y, rightSpawnMax.y),
                    Random.Range(rightSpawnMin.z, rightSpawnMax.z)
                );
                target = rightTarget; // Set the target to right
            }

            // Select an object to spawn based on weighted probability
            GameObject spawnedObject = ChooseObjectToSpawn();

            // Instantiate the selected object
            GameObject instantiatedObject = Instantiate(spawnedObject, randomPosition, Quaternion.identity);

            // Set the target for the spawned object
            ObjectMover mover = instantiatedObject.GetComponent<ObjectMover>();
            if (mover != null)
            {
                mover.SetTarget(target); // Assign the target based on the spawn side
            }
            else
            {
                Debug.LogError("ObjectMover component is missing on the spawned object!");
            }
        }
    }

    // Method to choose an object to spawn with weighted probabilities
    private GameObject ChooseObjectToSpawn()
    {
        // Define the total weight for each category
        int totalWeight = 3; // Adjust total weight to change probabilities
        int randomValue = Random.Range(0, totalWeight);

        // Return an obstacle with higher probability
        if (randomValue < 2) // 2 out of 3 chance to spawn an obstacle
        {
            int obstacleIndex = Random.Range(0, obstacles.Length);
            return obstacles[obstacleIndex];
        }
        else // 1 out of 3 chance to spawn a collectible
        {
            int collectibleIndex = Random.Range(0, objectsToSpawn.Length);
            return objectsToSpawn[collectibleIndex];
        }
    }

    public void StopSpawning()
    {
        spawning = false; // Stops spawning
    }
}
