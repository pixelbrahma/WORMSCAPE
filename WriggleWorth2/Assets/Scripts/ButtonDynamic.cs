using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDynamic : MonoBehaviour
{
    private bool flag = true;
    private float time = 0;

    private void Update()
    {
        time += Time.deltaTime;
        if (time > 0.5)
        {
            if (flag)
            {
                transform.localScale *= 1.5f;
            }
            else
            {
                transform.localScale /= 1.5f;
            }
            flag = !flag;
            time = 0;
        }
    }
}
