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
    private int toggleAccel;
    // TODO (Task 3-A): Declare a private Rigidbody field named 'rb'
    [SerializeField] private Rigidbody rb;

    //removed freezerotation as it will prevent physics based rotations which i prefer
    void Start()
    {
         toggleAccel = 0;
    }
    void Update()// or FixedUpdate() 
    {
        HandleRotation();
        HandleThrust();
        ToggleThrust();
    }

    private void HandleRotation()
    {
        // TODO (Task 3-C): 
        // Pitch   
        // Roll    
        float roll = Input.GetAxis("Roll") * rollSpeed; // roll left/right with A/D or Left/Right Arrow keys
        float pitch = Input.GetAxis("Pitch") * pitchSpeed; // pitch up/down with W/S or Up/Down Arrow keys
        float yaw = Input.GetAxis("Yaw") * yawSpeed; // yaw left/right with mouse movement

        transform.Rotate(pitch, roll, yaw, Space.Self);
    } 

    private void HandleThrust()
    {

        Vector3 thrustVector = transform.forward * toggleAccel * thrustSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + thrustVector);
        Debug.Log("Thrust: " + (toggleAccel * thrustSpeed));
    }

    private void ToggleThrust() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            toggleAccel = 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            toggleAccel = 0;
        }
    }
}