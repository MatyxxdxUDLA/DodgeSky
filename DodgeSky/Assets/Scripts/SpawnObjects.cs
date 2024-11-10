using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject[] enemies;
    public float timeSpawn = 1;
    public float repeatSpawnRate = 3;
    public Transform xRangeLeft;
    public Transform xRangeRight;
    public Transform yRangeUp;
    public Transform yRangeDown;

    void Start()
    {
        InvokeRepeating("SpawnEnemies", timeSpawn, repeatSpawnRate);
    }

    public void SpawnEnemies()
    {
        Vector3 spawnPosition = new Vector3(0,0,0);
        spawnPosition = new Vector3(Random.Range(xRangeLeft.position.x, xRangeRight.position.x),
                                    Random.Range(yRangeDown.position.y, yRangeUp.position.y), 0);

        GameObject enemie = Instantiate(enemies[0], spawnPosition, gameObject.transform.rotation);
    }
}
