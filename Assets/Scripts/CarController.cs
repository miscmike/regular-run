using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentbreakForce;
    private bool isBreaking;
    private bool isReset;
    private float dragCoefficient;
    private float scaledMotorForce;
    public static CarController cc;
    public float carCurrentSpeed;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;
    

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    [SerializeField] private Transform carTransform;

    [SerializeField] public Rigidbody carRigidbody;

    private void Start()
    {
        cc = this;
    }

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();

        if (isReset)
        {
            carTransform.rotation = Quaternion.identity;
            carTransform.position = Vector3.zero;
        }

        carCurrentSpeed = (carRigidbody.velocity.magnitude);
    }

       



    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        //verticalInput = Input.GetAxis(VERTICAL);

      

        if (Input.GetKey(KeyCode.W))
        {
            verticalInput = 2;
        }
        if (Input.GetKey(KeyCode.S))
        {
            verticalInput = -2;
        }



        isBreaking = Input.GetKey(KeyCode.Space);
        isReset = Input.GetKey(KeyCode.R);

       // dragCoefficient = carRigidbody.velocity.magnitude/1000000;

        Debug.Log(carRigidbody.velocity.magnitude);

        scaledMotorForce = motorForce * Math.Min(100, 100/carRigidbody.velocity.magnitude);
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * scaledMotorForce;
        frontRightWheelCollider.motorTorque = verticalInput * scaledMotorForce;
        rearLeftWheelCollider.motorTorque = verticalInput * scaledMotorForce;
        rearRightWheelCollider.motorTorque = verticalInput * scaledMotorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }

    private void ApplyBreaking()
    {
        

        frontRightWheelCollider.brakeTorque = currentbreakForce * Math.Max(10*carRigidbody.velocity.magnitude-1, 1);
        frontLeftWheelCollider.brakeTorque = currentbreakForce * Math.Max(10*carRigidbody.velocity.magnitude - 1, 1);
        rearLeftWheelCollider.brakeTorque = currentbreakForce * Math.Max(10*carRigidbody.velocity.magnitude - 1, 1);
        rearRightWheelCollider.brakeTorque = currentbreakForce * Math.Max(10*carRigidbody.velocity.magnitude - 1, 1);


    }


    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);

    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}
