using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Enemy enemy;
    [SerializeField] Transform enemiesContainer;
    [SerializeField] Transform[] spawnPositions;


    void Start()
    {
        StartCoroutine(SpawnForever());
    }

    IEnumerator SpawnForever()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0, 2f));
            Spawn(player);
        }
    }

    void Spawn(Player player)
    {
        Enemy instancedEnemy = Instantiate(enemy, enemiesContainer);
        instancedEnemy.AssignPlayer(player);
        Vector3 randomPos = spawnPositions[Random.Range(0, spawnPositions.Length)].position;
        instancedEnemy.transform.position = randomPos;
    }
}
