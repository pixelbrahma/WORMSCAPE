using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDeactivator : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float guard = 10f;

    private void Update()
    {
        if(player.transform.position.z - transform.position.z > guard)
        {
            gameObject.SetActive(false);
        }
    }
}
