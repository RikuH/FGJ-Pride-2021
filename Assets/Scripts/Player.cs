using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    //Get in the car variables :D
    [SerializeField] GameObject DriverDoor;
    [SerializeField] GameObject Car;
    [SerializeField] float AbleToGetInCarDistance;
    bool isGoingToDrive = false;

    //Free moving variables
    public CharacterController controller;
    public float speed = 6f;
    public float turnSmoothTime = 0f;
    public Transform cam;
    float turnSmoothVelocity;

    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        float distance = Vector3.Distance(gameObject.transform.position, DriverDoor.transform.position);
        if (distance < AbleToGetInCarDistance)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                agent.SetDestination(DriverDoor.transform.position);
                isGoingToDrive = true;
            }
            if (isGoingToDrive)
            {
                if(agent.remainingDistance < 0.1f)
                {
                    Debug.Log("Nyt ajaa");
                    Car.GetComponent<CarScript>().isRiding = true;
                }
            }
        }
        else
        {
            isGoingToDrive = false;
            agent.ResetPath();
        }
    }
}
