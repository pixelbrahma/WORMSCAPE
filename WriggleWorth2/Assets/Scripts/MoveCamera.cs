using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private float speedZ;
    private Rigidbody rigidBody;
    public static bool gameover = false;
    [SerializeField] private Light dLight;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        transform.GetChild(0).GetComponent<AudioSource>().Play();
    }

    private void Update()
    {
        if(gameover)
        {
            rigidBody.velocity = Vector3.zero;
            StartCoroutine(Wait5());
        }
        else
        {
            rigidBody.velocity = new Vector3(0, 0, speedZ);
            speedZ += 0.05f * Time.deltaTime;
        }
    }

    private IEnumerator Wait5()
    {
        yield return new WaitForSeconds(1);
        dLight.color = Color.red;
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }
}
