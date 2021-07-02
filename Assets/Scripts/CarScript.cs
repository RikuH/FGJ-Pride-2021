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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRiding)
            return;

        GetInputs();
    }
    private void LateUpdate()
    {
        if (!isRiding)
            return;

        Move();
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
}
