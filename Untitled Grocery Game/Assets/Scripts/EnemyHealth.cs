using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{   
    
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        healthBar.SetMaxHealth(maxHealth);
    }
    void TakeDamage(int damage){
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    void Update(){
        if (currentHealth == 0){
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Projectile")){
            animator.SetTrigger("Flash");
            TakeDamage(20);
        }
    }
}
