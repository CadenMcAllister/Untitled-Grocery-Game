using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileMovement : MonoBehaviour
{   
    public GameObject Player;
    public Rigidbody2D rb;
    public float speed = 7f;
    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();

    }

        public void FixedUpdate(){
        rb.AddForce (new Vector2(joystick.Horizontal * speed * Time.fixedDeltaTime, joystick.Vertical * speed * Time.fixedDeltaTime ), ForceMode2D.Impulse);
        }
}
