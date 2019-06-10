using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private GameObject fire;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float limitUp = 4;
    [SerializeField] private float limitDown = 0;
    private Rigidbody rigidBody;
    private int direction = 1;


    private void Start()
    {
        fire.SetActive(false);
        rigidBody = GetComponent<Rigidbody>();
        transform.position += new Vector3(0, Random.Range(-1, 3), 0);
    }

    private void FixedUpdate()
    {
        if (transform.position.y >= limitUp)
        {
            direction = -1;
            fire.SetActive(false);
        }
        else if (transform.position.y <= limitDown)
        {
            direction = 1;
            fire.SetActive(true);
        }
        rigidBody.velocity = Vector3.up * speed * direction;
    }
}
