using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStretchRemover : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}
