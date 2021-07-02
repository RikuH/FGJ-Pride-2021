using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Axel
{
    Front,
    Rear
}
[Serializable]
public struct Wheel
{
    public GameObject Model;
    public WheelCollider collider;
    public Axel axel;
}

public class CarScript : MonoBehaviour
{

    public bool isRiding = false;

    [SerializeField] float maxAcceleration = 20.0f;
    [SerializeField] float turnSensitivity = 1.0f;
    [SerializeField] float maxSteerAngle = 45.0f;
    [SerializeField] List<Wheel> Wheels;

    private float inputX, inputY;
    Rigidbody rb;

    [SerializeField] GameObject ThirdPersonCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRiding)
            return;

        ThirdPersonCamera.SetActive(true);

        AnimateWheels();
        GetInputs();
    }
    private void LateUpdate()
    {
        if (!isRiding)
            return;

        Move();
        Turn();
    }
    void GetInputs()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
    }
    private void Move()
    {
        foreach(var wheel in Wheels)
        {
            wheel.collider.motorTorque = inputY * maxAcceleration * 500 * Time.deltaTime;
        }
    }
    void Turn()
    {
        foreach(var wheel in Wheels)
        {
            if(wheel.axel == Axel.Front)
            {
                var _steerAngle = inputX * turnSensitivity * maxSteerAngle;
                wheel.collider.steerAngle = Mathf.Lerp(wheel.collider.steerAngle,_steerAngle,0.5f);
            }
        }
    }
    void AnimateWheels()
    {
        foreach(var wheel in Wheels)
        {
            Quaternion rot;
            Vector3 pos;
            wheel.collider.GetWorldPose(out pos, out rot);
            wheel.Model.transform.rotation = rot;
            wheel.Model.transform.position = pos;
        }
    }
}
