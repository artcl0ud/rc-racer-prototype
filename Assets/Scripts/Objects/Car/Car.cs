using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public WheelCollider wheelColliderFrontLeft;
    public WheelCollider wheelColliderFrontRight;
    public WheelCollider wheelColliderRearLeft;
    public WheelCollider wheelColliderRearRight;

    public Transform wheelFrontLeft;
    public Transform wheelFrontRight;
    public Transform wheelRearLeft;
    public Transform wheelRearRight;

    public float motorTorque = 100f;
    public float maxSteer = 20f;

    void FixedUpdate()
    {
        wheelColliderRearLeft.motorTorque = Input.GetAxis("Vertical") * motorTorque;
        wheelColliderRearRight.motorTorque = Input.GetAxis("Vertical") * motorTorque;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var pos = Vector3.zero;
        var rot = Quaternion.identity;

        wheelColliderFrontLeft.GetWorldPose(out pos, out rot);
        wheelFrontLeft.position = pos;
        wheelFrontLeft.rotation = rot * Quaternion.Euler(0,180,0);

        wheelColliderFrontRight.GetWorldPose(out pos, out rot);
        wheelFrontRight.position = pos;
        wheelFrontRight.rotation = rot;

        wheelColliderRearLeft.GetWorldPose(out pos, out rot);
        wheelRearLeft.position = pos;
        wheelRearLeft.rotation = rot * Quaternion.Euler(0,90,0);

        wheelColliderRearRight.GetWorldPose(out pos, out rot);
        wheelRearRight.position = pos;
        wheelRearRight.rotation = rot;
    }
}
