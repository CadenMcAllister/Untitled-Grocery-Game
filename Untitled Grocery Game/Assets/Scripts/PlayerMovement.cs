using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody2D rb;
    public float speed = 15f;
    public SpriteRenderer playerSprite;
    public Sprite[] spriteList;
    Vector2 movement;
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public GameObject gameOver;
    // Start is called before the first frame update
    void Start(){
        currentHealth = maxHealth;

        healthBar.SetMaxHealth(maxHealth);
        if (gameObject != null){
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        playerSprite = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        }
    }

    void TakeDamage(int damage){
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.W)){
            playerSprite.sprite = spriteList[0];
        }
        if (Input.GetKeyDown(KeyCode.S)){
            playerSprite.sprite = spriteList[1];
        }
        if (Input.GetKeyDown(KeyCode.D)){
            playerSprite.sprite = spriteList[2];
        }
        if (Input.GetKeyDown(KeyCode.A)){
            playerSprite.sprite = spriteList[3];
        }
        if (currentHealth == 0){
            gameOver.SetActive(true);
            Destroy(gameObject);
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");        
    }

        private void OnTriggerEnter2D (Collider2D other){
        if (other.gameObject.CompareTag("EnemyProjectile")){
            TakeDamage(10);
        }
    }

    void FixedUpdate(){
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }
}
