using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private List<GameObject> obstacles;
    [SerializeField] private float minRate = 5;
    [SerializeField] private float maxRate = 8;
    private float lastSpawnZ;
    private List<GameObject> obstaclePool;

    private void Awake()
    {
        lastSpawnZ = ObjectPooler.endDistance;
        obstaclePool = new List<GameObject>();
        for(int i=0;i<obstacles.Count;i++)
        {
            GameObject go = Instantiate(obstacles[i]);
            obstaclePool.Add(go);
            go.SetActive(false);
        }
    }

    private void Update()
    {
        if(lastSpawnZ - player.transform.position.z < ObjectPooler.endDistance)
        {
            int c = Random.Range(0, obstaclePool.Count);
            while(obstaclePool[c].activeInHierarchy)
            {
                c = Random.Range(0, obstaclePool.Count);
            }
            GameObject go = obstaclePool[c];
            lastSpawnZ += Random.Range(minRate,maxRate);
            go.transform.position = new Vector3(Random.Range(-1, 2), 0.5f, lastSpawnZ);
            if(c==1||c==6)
            {
                go.transform.position += new Vector3(0, 0.1f, 0);
            }
            else if(c==5||c==7)
            {
                go.transform.position += new Vector3(0, 0.2f, 0);
            }
            go.SetActive(true);
        }
    }
}
