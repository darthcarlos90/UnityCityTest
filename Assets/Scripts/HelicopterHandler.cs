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



}
