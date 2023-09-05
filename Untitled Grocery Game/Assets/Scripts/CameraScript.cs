using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Player;
    public Vector3 Offset;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject != null){
            Camera = gameObject;
            Player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null){
            Camera.transform.position = Player.transform.position + Offset;
        }
    }
}
