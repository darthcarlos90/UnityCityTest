using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterHandler: MonoBehaviour {

    // These game objects are used to represent the main and tal rotors on the helicopter game object.
    public GameObject mainRotor;
    public GameObject tailRotor;

    public float maxRotorForce = 24000;
    public float maxRotorVelocity = 7200;

    static float rotorVelocity = 0;
    private float rotorRotation = 0;

    public float maxTailRotorForce = 25000;
    public float maxTailRotorVelocity = 22000;

    private float tailRotorVelocity = 0;
    private float tailRotorRotation = 0;

    public float forwardRotorTorqueMultiplier = 0.5f;
    public float sidewayRotorTorqueMultiplier = 0.5f;

    public bool mainRotorActive = true;
    public bool tailRotorActive = true;

    private Rigidbody rb;


    private void Start()
    {
        // Since we will attach this script to a game object, using the get component function will get
        // the rigid body that this attached to this element
        // TODO Check if this is null, if so it is not working
        Debug.Log("Start function");
        rb = GetComponent<Rigidbody>();

        if(rb == null)
        {
            Debug.Log("This element is null");
        }
    }

    /**
     * This peace of code represents the update calls of the physics engine.
     * Since the physics engine is called on a different thread, and it's updates are different 
     * (and some times independent of the graphics engine) physics calls need to be called on a separate method.
     */
    private void FixedUpdate()
    {
        Vector3 torqueValue = new Vector3();
        Vector3 controlTorque = new Vector3(
            Input.GetAxis("Vertical") * forwardRotorTorqueMultiplier,
            1.0f, 
            -Input.GetAxis("Horizontal2") * sidewayRotorTorqueMultiplier);

        if (mainRotorActive)
        {
            torqueValue += (controlTorque * maxRotorForce * rotorVelocity);
            
            // Adds a force in the model space
            rb.AddRelativeForce(Vector3.up * maxRotorForce * rotorVelocity);
        }

        // Transform lower case refers to the transform elements of the current object
        // The Vector3.angle function measures the angle between its parameters
        if (Vector3.Angle(Vector3.up, transform.up) < 80)
        {
            // Slerp is used to interpolate between the two values in the parameters
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0),  // Euler function returns a rotation among certain axis
                Time.deltaTime * rotorVelocity * 2);
        }

        if (tailRotorActive)
        {
            torqueValue -= (Vector3.up * maxTailRotorForce * tailRotorVelocity);
            rb.AddRelativeTorque(torqueValue);
        }

    }


    private void Update()
    {
        if (mainRotorActive)
        {
            mainRotor.transform.rotation = transform.rotation * Quaternion.Euler(270, rotorRotation, 0);
        }

        if (tailRotorActive)
        {
            tailRotor.transform.rotation = transform.rotation * Quaternion.Euler(0, 270, tailRotorRotation);
        }

        // frame rate independency with Time.deltatime
        rotorRotation += maxRotorVelocity * rotorVelocity * Time.deltaTime;

        tailRotorRotation += maxTailRotorVelocity * rotorVelocity * Time.deltaTime;

        float hoverRotorVelocity = (rb.mass * Mathf.Abs(Physics.gravity.y) / maxRotorForce);
        float hoverTailRotorVelocity = (maxRotorForce * rotorVelocity) / maxTailRotorForce;

        if(Input.GetAxis("Vertical2") != 0.0)
        {
            rotorVelocity += Input.GetAxis("Vertical2") * 0.005f;
        }
        else
        {
            rotorVelocity = Mathf.Lerp(rotorVelocity, hoverRotorVelocity, Time.deltaTime * 5);
        }

        tailRotorVelocity = hoverTailRotorVelocity - Input.GetAxis("Horizontal") * 0.01f;

        // clamping
        if(rotorVelocity > 1.0)
        {
            rotorVelocity = 1.0f;
        } 
        else if(rotorVelocity < 0.0)
        {
            rotorVelocity = 0.0f;
        }


    }



}
