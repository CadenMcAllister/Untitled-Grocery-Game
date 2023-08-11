using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffScript : MonoBehaviour
{
    public Transform spriteTransform;
    public Camera mainCamera;
    public GameObject Player;
    public SpriteRenderer playerRenderer;
    public PlayerMovement playerMovement;
    public SpriteRenderer staffRenderer;
    public GameObject projectilePrefab;
    public Transform bulletSpawnPoint;
    public float projectileForce = 10f;
    public Animator gunAnimator;
    private GameObject currentGun;

    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
    gunAnimator = GameObject.Find("Projectile").GetComponent<Animator>();
    staffRenderer = GetComponent<SpriteRenderer>();
    playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>(); 
    Player = GameObject.FindGameObjectWithTag("Player");
    playerRenderer = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
    spriteTransform = GetComponent<Transform>();
    transform.position = Player.transform.position + offset;
    }

    void Update(){
        if (playerRenderer.sprite == playerMovement.spriteList[0]){
            staffRenderer.sortingOrder = -1;
        }
        else {
            staffRenderer.sortingOrder = 7;
        }
        currentGun = gameObject;
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        } 
    }

    void Shoot(){
    GameObject newProjectile = Instantiate(currentGun.GetComponent<StaffScript>().projectilePrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();

    rb.AddForce(transform.right * currentGun.GetComponent<StaffScript>().projectileForce, ForceMode2D.Impulse);

    Animator projectileAnimator = newProjectile.GetComponent<Animator>();
    projectileAnimator.Play("Fireball");
    Destroy(newProjectile, 5f);
    }

    void FixedUpdate(){
    Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    mousePos.z = 0f;
    Vector3 direction = mousePos - spriteTransform.position;
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    spriteTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
