using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffScript : MonoBehaviour
{
    public Transform spriteTransform;
    public float shakeIntensity = 5f;
    public float shakeDuration = 0.1f;
    public Camera mainCamera;
    public Animator coolAnim;
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

    // Cooldown variables
    public float shootCooldown = 1.0f; // Adjust this value for your desired cooldown duration
    private float lastShotTime = 0.0f;
    private bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        staffRenderer = GetComponent<SpriteRenderer>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        Player = GameObject.FindGameObjectWithTag("Player");
        playerRenderer = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        spriteTransform = GetComponent<Transform>();
        transform.position = Player.transform.position + offset;
    }

    void Update()
    {
        if (playerRenderer.sprite == playerMovement.spriteList[0])
        {
            staffRenderer.sortingOrder = -1;
        }
        else
        {
            staffRenderer.sortingOrder = 7;
        }

        currentGun = gameObject;

        // Check if the staff can shoot based on cooldown
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (Time.time - lastShotTime >= shootCooldown)
        {
            coolAnim.SetTrigger("Cooldown");

            GameObject newProjectile = Instantiate(currentGun.GetComponent<StaffScript>().projectilePrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();

            rb.AddForce(transform.right * currentGun.GetComponent<StaffScript>().projectileForce, ForceMode2D.Impulse);

            CinemachineShake.Instance.ShakeCamera(shakeIntensity, shakeDuration);

            Animator projectileAnimator = newProjectile.GetComponent<Animator>();
            projectileAnimator.Play("Fireball");

            // Update the last shot time and set canShoot to false
            lastShotTime = Time.time;
            canShoot = false;

            // Start a cooldown timer to enable shooting again
            StartCoroutine(EnableShooting());
        }
    }

    // Coroutine to enable shooting after the cooldown period
    IEnumerator EnableShooting()
    {
        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    }

    void FixedUpdate()
    {
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        Vector3 direction = mousePos - spriteTransform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        spriteTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
