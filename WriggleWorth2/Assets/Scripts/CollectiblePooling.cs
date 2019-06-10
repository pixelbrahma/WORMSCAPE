using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblePooling : MonoBehaviour
{
    [SerializeField] private int poolAmount = 1;
    [SerializeField] private GameObject pooledObject;
    private List<GameObject> collectiblePool;
    [SerializeField] private float minDistance = 20;
    [SerializeField] private float maxDistance = 30;
    private float lastSpawnZ;

    private void Start()
    {
        lastSpawnZ = minDistance;
        collectiblePool = new List<GameObject>();
        for(int i=0;i<poolAmount;i++)
        {
            GameObject go = Instantiate(pooledObject) as GameObject;
            collectiblePool.Add(go);
            go.SetActive(false);
        }
    }

    private void Update()
    {
        for(int i=0;i<collectiblePool.Count;i++)
        {
            if(!collectiblePool[i].activeInHierarchy)
            {
                lastSpawnZ += Random.Range(minDistance, maxDistance);
                collectiblePool[i].transform.position = new Vector3(Random.Range(-1, 2), 1f, lastSpawnZ);
                collectiblePool[i].SetActive(true);
            }
        }
    }

}
