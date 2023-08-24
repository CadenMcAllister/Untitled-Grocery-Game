using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Enemies;
    private float timer;
    // Start is called before the first frame update
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 10){
            timer = 0;
            Spawn();
        }
    }

    public void Spawn(){
         int enemyIndex = Random.Range(0, Enemies.Length);
        Instantiate(Enemies[enemyIndex], transform.position, Quaternion.identity);
    }


}
