using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Transform centerOfMass;
    public float motorTorque = 1500f;
    public float maxSteer = 30f;

    public float Steer { get; set; }
    public float Throttle { get; set; }

    private Rigidbody rigidBody;
    private Wheel[] wheels;
    
    void Start() 
    {
        wheels = GetComponentsInChildren<Wheel>();
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.centerOfMass = centerOfMass.localPosition;
    }

    void Update()
    {
        Steer = GameManager.Instance.inputController.SteerInput;
        Throttle = GameManager.Instance.inputController.ThrottleInput;

        foreach (var wheel in wheels)
        {
            wheel.SteerAngle = Steer * maxSteer;
            wheel.Torque = Throttle * motorTorque;
        }
    }
}