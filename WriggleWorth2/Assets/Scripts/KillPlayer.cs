using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] private GameObject particleEffect;
    private GameObject pe;
    [SerializeField] private AudioSource music;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            pe = Instantiate(particleEffect) as GameObject;
            ParticleSystem ps = pe.GetComponent<ParticleSystem>();
            ParticleSystem.MainModule psmain = ps.main;
            psmain.startColor = Color.red;
            pe.transform.position = transform.position;
            MoveCamera.gameover = true;
            GetComponent<AudioSource>().enabled = true;
            music.Stop();
        }
    }
}
