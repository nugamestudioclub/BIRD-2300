using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerPlayerController : MonoBehaviour
{

    private float forwardInput;
    private float sideInput;

    [SerializeField]
    private FirstPersonShooterController camController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isTabbbedOut)
        {
            GetInputs();
            GetGroundFacing();
        }
        else
        {
            ResetInputs();
        }
    }

    private void GetGroundFacing()
    {
        throw new NotImplementedException();
    }

    public void GetInputs()
    {
        forwardInput = Input.GetAxis("Horizontal");
        sideInput = Input.GetAxis("Vertical");
    }

    private void ResetInputs()
    {
        forwardInput = 0;
        sideInput = 0;
    }
}
