using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSetFalse : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float guard = 20f;

    private void Update()
    {
        if (player.position.z - transform.position.z > guard)
        {
            if (!MoveCamera.gameover)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
