using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltParticle : MonoBehaviour
{    
    public ParticleSystem ExplosionObject;
    public AudioSource Source;
    public AudioClip Clip;
    private void OnCollisionEnter2D(Collision2D collision){
        if(!collision.gameObject.CompareTag("Player")){
        StartCoroutine(Collision());
        }
    }

    IEnumerator Collision(){
        CinemachineShake.Instance.ShakeCamera(2f, 0.2f);
        yield return new WaitForSeconds(0.2f);
        Instantiate(ExplosionObject, transform.position, transform.rotation);
        Source.PlayOneShot(Clip);
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
