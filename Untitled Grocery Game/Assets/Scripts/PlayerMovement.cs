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
    // Start is called before the first frame update
    void Start(){

        Player = GameObject.FindGameObjectWithTag("Player");
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        playerSprite = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
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

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");        
    }

    void FixedUpdate(){
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }
}
