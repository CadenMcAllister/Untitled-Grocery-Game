using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject Bullet;
    public Transform bulletPos;
    public Animator animator;

    private float timer;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player =  GameObject.FindGameObjectWithTag("Player");
        animator = GameObject.FindGameObjectWithTag("EnemyGFX").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, Player.transform.position);
        if (distance < 20){
        timer += Time.deltaTime;

            if (timer > 2){
        timer = 0;
        shoot();
        }
        }
    }

    void shoot(){
        animator.SetBool("Shoot", true);
        Instantiate(Bullet, bulletPos.position, Quaternion.identity);
    }
}
