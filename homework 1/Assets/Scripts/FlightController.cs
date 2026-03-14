// FlightController.cs 
// CENG 454 – HW1: Sky-High Prototype 
// Author: Ýlhan Güven Erol | Student ID: 230446016

using UnityEngine;

public class FlightController : MonoBehaviour
{
    [SerializeField] private float pitchSpeed = 45f;  // degrees/second pitch: up/down
    [SerializeField] private float yawSpeed = 45f;  // degrees/second yaw: left/right
    [SerializeField] private float rollSpeed = 45f;  // degrees/second roll: tilt left/right
    [SerializeField] private float thrustSpeed = 5f;   // units/second 

    // TODO (Task 3-A): Declare a private Rigidbody field named 'rb'
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        // TODO (Task 3-B): Cache GetComponent<Rigidbody>() into 'rb'. 
        //                  Then set rb.freezeRotation = true. 
        //                  Why is freezeRotation needed? Answer in your PDF. 
    }

    void Update()// or FixedUpdate() 
    {
        HandleRotation();
        HandleThrust();
    }

    private void HandleRotation()
    {
        // TODO (Task 3-C): 
        // Pitch   
        // Roll    
        rollSpeed = Input.GetAxis("Roll") * rollSpeed; // roll left/right with A/D or Left/Right Arrow keys
        pitchSpeed = Input.GetAxis("Pitch") * pitchSpeed; // pitch up/down with W/S or Up/Down Arrow keys
        yawSpeed = Input.GetAxis("Yaw") * yawSpeed; // yaw left/right with mouse movement

        rb.AddTorque(transform.forward * rollSpeed);
        rb.AddTorque(transform.right * pitchSpeed);
        rb.AddTorque(transform.up * yawSpeed);

    }

    private void HandleThrust()
    {
        // TODO (Task 3-D): 
    }
}