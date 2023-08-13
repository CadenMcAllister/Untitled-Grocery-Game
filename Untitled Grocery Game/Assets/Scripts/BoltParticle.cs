using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltParticle : MonoBehaviour
{    
    public ParticleSystem ExplosionObject;
    private void OnCollisionEnter2D(Collision2D collision){
        Instantiate(ExplosionObject, transform.position, transform.rotation);
    }
}
