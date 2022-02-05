using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonShooterController : MonoBehaviour
{
    public float turnSpeed = 4.0f;
    public float moveSpeed = 2.0f;
    public float minTurnAngle = -90.0f;
    public float maxTurnAngle = 90.0f;
    private float rotX;


    private float xInput;
    private float yInput;
    private float forwardInput;
    private float sideInput;

    void Update()
    {
        
        if(!GameManager.Instance.isTabbbedOut) {
            GetInputs();
        } else
        {
            ResetInputs();
        }
        TranslateInputs();
        KeyboardMovement();
    }
    void TranslateInputs()
    {
        // get the mouse inputs
        float y = xInput * turnSpeed * Time.deltaTime * 100;
        rotX += yInput * turnSpeed * Time.deltaTime * 100;
        // clamp the vertical rotation
        rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);
        // rotate the camera
        transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);
    }
    void KeyboardMovement()
    {
        Vector3 dir = new Vector3(0, 0, 0);
        dir.x = forwardInput;
        dir.z = sideInput;
        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }

    public void GetInputs()
    {
        xInput = Input.GetAxis("Mouse X");
        yInput = Input.GetAxis("Mouse Y");
        forwardInput = Input.GetAxis("Horizontal");
        sideInput = Input.GetAxis("Vertical");
    }

    private void ResetInputs()
    {
        xInput = 0;
        yInput = 0;
        forwardInput = 0;
        sideInput = 0;
}
}
