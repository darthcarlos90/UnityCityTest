using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {


    GameObject mainRotor;
    GameObject tailRotor;

    float maxRotorForce = 24000;
    float maxRotorVelocity = 7200;

    static float rotorVelocity = 0;
    private float rotorRotation = 0;

    float maxTailRotorForce = 25000;
    float maxTailRotorVelocity = 22000;

    private float tailRotorVelocity = 0;
    private float tailRotorRotation = 0;

    float forwardRotorTorqueMultiplier = 0.5f;
    float sidewayRotorTorqueMultiplier = 0.5f;

    bool mainRotorActive = true;
    bool tailRotorActive = true;

    private Rigidbody rb; 




}
