using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaerticleEffectRemover : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Wait2());
    }

    private IEnumerator Wait2()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
