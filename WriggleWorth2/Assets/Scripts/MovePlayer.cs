using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private KeyCode moveLeft = KeyCode.LeftArrow;
    [SerializeField] private KeyCode moveRight = KeyCode.RightArrow;
    [SerializeField] private float speedZ;
    [SerializeField] private int laneNumber = 0;
    private Rigidbody rigidBody;
    private float horizontalVelocity = 0;
    private bool controlLocked = false;
    public static float time;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rigidBody.velocity = new Vector3(horizontalVelocity, 0, speedZ);
        if (Input.GetKeyDown(moveLeft) && laneNumber != -1 && !controlLocked)
        {
            horizontalVelocity = -2;
            controlLocked = true;
            StartCoroutine(StopSlide());
            laneNumber -= 1;
        }
        else if (Input.GetKeyDown(moveRight) && laneNumber != 1 && !controlLocked)
        {
            horizontalVelocity = 2;
            controlLocked = true;
            StartCoroutine(StopSlide());
            laneNumber += 1;
        }
        speedZ += 0.05f * Time.deltaTime;
        if (!MoveCamera.gameover)
        {
            time += Time.deltaTime;
        }
    }

    IEnumerator StopSlide()
    {
        yield return new WaitForSeconds(0.5f);
        horizontalVelocity = 0;
        controlLocked = false;
    }
}
