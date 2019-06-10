using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSetFalse : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject particleEffect;
    public static int score = 0;
    private static GameObject pe;
    [SerializeField] private AudioClip collects;
    private static AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(player.transform.position.z - transform.position.z > 5f)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            score++;
            source.PlayOneShot(collects, 1);
            pe = Instantiate(particleEffect) as GameObject;
            pe.transform.position = transform.position;
            StartCoroutine(Wait2());
        }
    }

    private IEnumerator Wait2()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}

