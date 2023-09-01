using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject Bullet;
    public Transform bulletPos;
    public Animator animator;
    public float bulletPosx;
    public float bulletPosy;
    private float timer;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject != null){
        Player =  GameObject.FindGameObjectWithTag("Player");
        animator = GameObject.FindGameObjectWithTag("EnemyGFX").GetComponentInChildren<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        bulletPosx = bulletPos.position.x;
        bulletPosy = bulletPos.position.y;
        float distance = Vector2.Distance(transform.position, Player.transform.position);
        if (distance < 20){
        timer += Time.deltaTime;

            if (timer > 1){
        timer = 0;
        shoot();
        }
        }
    }

    void shoot(){
        animator.SetBool("Shoot", true);
        Debug.Log("Set");
        Instantiate(Bullet, new Vector3 (bulletPosx, bulletPosy, 0), Quaternion.identity);
        StartCoroutine(StopAnim());
    }

    IEnumerator StopAnim(){
        yield return new WaitForSeconds(0);
        Debug.Log("StopAnim");
    }
}
