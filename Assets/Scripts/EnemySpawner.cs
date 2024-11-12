using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private BoxCollider spawnArea;

    [SerializeField]
    private float minDistanceFromPlayer = 5f;

    [SerializeField]
    private Vector2 spawnIntervalRange = new Vector2(1f, 5f);

    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            float spawnInterval = Random.Range(spawnIntervalRange.x, spawnIntervalRange.y);
            yield return new WaitForSeconds(spawnInterval);
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = GetRandomPositionInBox();
        if (Vector3.Distance(spawnPosition, player.transform.position) >= minDistanceFromPlayer)
        {
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private Vector3 GetRandomPositionInBox()
    {
        Vector3 center = spawnArea.center + spawnArea.transform.position;
        Vector3 size = spawnArea.size;

        float x = Random.Range(center.x - size.x / 2, center.x + size.x / 2);
        float y = center.y; 
        float z = Random.Range(center.z - size.z / 2, center.z + size.z / 2);

        return new Vector3(x, y, z);
    }
}
