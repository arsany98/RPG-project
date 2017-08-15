using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;

    public Vector3 offset;
    float currentRotate=0f;
    public float rotateSpeed=100f;

    float currentZoom = 10f;
    public float zoomSpeed = 5f;
    public float minZoom = 5f;
    public float maxZoom = 15f;
    private void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel")*zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        currentRotate -= Input.GetAxis("Horizontal")*rotateSpeed*Time.deltaTime;
    }
    private void LateUpdate()
    {
        transform.position = target.position + offset * currentZoom;
        transform.RotateAround(target.position, Vector3.up, currentRotate);
        transform.LookAt(target.position + Vector3.up * 2f);
    }
}
