using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public Camera mainCamera;
    public Transform spriteTransform;

    void Start(){
    spriteTransform = GetComponent<Transform>();
    mainCamera = GameObject.Find("Camera").GetComponent<Camera>();
    PointFunc();
    }

    void PointFunc(){
    Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    mousePos.z = 0f;
    Vector3 direction = mousePos - spriteTransform.position;
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
    spriteTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
