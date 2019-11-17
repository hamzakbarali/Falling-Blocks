using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleSpawn : MonoBehaviour
{
    [SerializeField] GameObject obstacle;
    [SerializeField] GameObject obstacleParent;
    private float screenWidthInWorldUnits;
    private float screenHeightInWorldUnits;
    private float nextSpawnTime;
    private int difficulty;
    private float spawnDelay;
    
    void Start()
    {
        screenHeightInWorldUnits = Camera.main.orthographicSize;
        screenWidthInWorldUnits = screenHeightInWorldUnits * Camera.main.aspect;
        obstacleParent = GameObject.Find("Spawn Manager");
        nextSpawnTime = 0;
        difficulty = 0;
        spawnDelay = 1f;
    }

    void Update()
    {
        Spawn();
        DestroySpawn();
    }

    private void SpawnObstacle()
    {
        Vector3 obstacleScale = new Vector3(Random.Range(1.5f, 3f), Random.Range(1.5f, 3f), 1f);
        Vector3 obstacleRotation = new Vector3(0, 0, Random.Range(-10f, 10f));
        float posX = Random.Range(-screenWidthInWorldUnits, screenWidthInWorldUnits);
        float posY = screenHeightInWorldUnits + obstacleScale.y;
        GameObject spawn = Instantiate(obstacle, new Vector3(posX, posY, 0), Quaternion.Euler(obstacleRotation), obstacleParent.transform);
        spawn.transform.localScale = obstacleScale;
    }

    private void DestroySpawn()
    {
        if (GameObject.FindWithTag("Obstacle"))
        {
            if (GameObject.FindWithTag("Obstacle").transform.position.y < -screenHeightInWorldUnits - GameObject.FindWithTag("Obstacle").transform.localScale.y / 2)
            {
                Destroy(GameObject.FindWithTag("Obstacle"));
                
            }
        }
    }

    private void Spawn()
    {
        if(nextSpawnTime < Time.time)
        {
            nextSpawnTime = spawnDelay + Time.time;
            difficulty++;
            if(difficulty % 10 == 0 && spawnDelay >= 0.4f)
            {
                spawnDelay -= 0.1f;    
            }
            SpawnObstacle();
        }
    }
}
