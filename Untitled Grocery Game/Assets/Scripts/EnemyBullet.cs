using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    public Animator animator;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject != null){
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>();
        }

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(-direction.x, -direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);

    }

    IEnumerator ResetTrigger(){
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("Shoot", false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2){
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D (Collider2D other){
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Obstacle")){
            Destroy(gameObject);
        }
    }
}
