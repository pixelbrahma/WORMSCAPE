using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private GameObject pooledObject;
    public int pooledAmount = 3;
    List<GameObject> pool;
    public static float endDistance = 20;
    [SerializeField] private Transform player;
    private Vector3 nextSpawnPosition;

    private void Start()
    {
        nextSpawnPosition = new Vector3(0, 0, 2);
        pool = new List<GameObject>();
        for(int i=0;i<pooledAmount;i++)
        {
            GameObject go = Instantiate(pooledObject);
            nextSpawnPosition += new Vector3(0, 0, 2);
            go.transform.position = nextSpawnPosition;
            go.SetActive(false);
            pool.Add(go);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i=0;i<pool.Count;i++)
        {
            if(!pool[i].activeInHierarchy)
            {
                nextSpawnPosition += new Vector3(0, 0, 2);
                pool[i].transform.position = nextSpawnPosition;
                return pool[i];
            }
        }
        GameObject go = Instantiate(pooledObject);
        nextSpawnPosition += new Vector3(0, 0, 2);
        go.transform.position = nextSpawnPosition;
        go.SetActive(false);
        pool.Add(go);

        return go;
    }

    private void Update()
    {
        if(nextSpawnPosition.z - player.position.z < endDistance)
        {
            GetPooledObject().SetActive(true);
        }
    }
}
