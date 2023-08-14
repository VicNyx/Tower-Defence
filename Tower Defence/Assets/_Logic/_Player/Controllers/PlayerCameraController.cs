using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    //notes rotation on the X axis is bugged, stuck in place

    [Header("Camera Properties")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float mouseSensX;
    [SerializeField] private float mouseSensY;

    [Header("Camera Follow")]
    [SerializeField] private Transform camPivot;
    [SerializeField] private Transform camTarget;
    [SerializeField] private float lerpAmount;

    private float rotationX = 0f;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        camPivot = transform.parent;
    }

    private void Update()
    {
        HandleCameraControl();
    }

    private void LateUpdate()
    {
        HandleCameraFollow();
    }

    private void HandleCameraControl()
    {
        //multiplied by relevant mouseSens and by 10
        float mouseX = Input.GetAxis("Mouse X") * mouseSensX * 10f;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensY * 10f;

        //clamp camera
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -89f, 89f);

        //rotation of camTarget local rotation
        camPivot.localRotation = Quaternion.Euler(rotationX, camPivot.localRotation.eulerAngles.y + mouseX, 0f);

        //rotate playerTransform left and right
        playerTransform.Rotate(Vector3.up * mouseX);
    }

    private void HandleCameraFollow() 
    {
        //lerp camTarget pos towards playerTransform pos
        camPivot.position = Vector3.Lerp(camPivot.position, camTarget.position, lerpAmount * Time.deltaTime);
    }
}
/*@Tysonn J. Smith 2023
 * 
 * 
 * 
 * 
 */