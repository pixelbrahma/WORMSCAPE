using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleMaker : MonoBehaviour
{
    private void OnEnable()
    {
        int rand = Random.Range(0, 41);
        if(rand==7)
        {
            GetComponent<MeshRenderer>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnDisable()
    {
        GetComponent<MeshRenderer>().enabled = true;
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
