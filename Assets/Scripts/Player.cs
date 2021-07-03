using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    //Get in the car variables :D
    [SerializeField] GameObject DriverDoor;
    [SerializeField] GameObject DriverSeat;
    [SerializeField] GameObject Car;
    [SerializeField] float AbleToGetInCarDistance;
    bool isGoingToDrive = false;

    //Free moving variables
    public CharacterController controller;
    public float speed = 6f;
    public float turnSmoothTime = 0f;
    public Transform cam;
    float turnSmoothVelocity;

    [SerializeField] GameObject ThirdPersonCamera;

    NavMeshAgent agent;
    Animator anim;

    Vector3 currentPos;
    Vector3 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        currentPos = transform.position;
        lastPos = transform.position;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Car.GetComponent<CarScript>().isRiding)
            return;

        Move();
        DrivingMode();
        Animations();
    }

    void Driving()
    {
        Debug.Log("Nyt ajaa");
        gameObject.transform.parent = Car.transform;
        gameObject.GetComponent<Collider>().enabled = false;
        //gameObject.GetComponentInChildren<Renderer>().enabled = false;
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        gameObject.transform.position = DriverSeat.transform.position;
        isGoingToDrive = false;
        agent.ResetPath();

        ThirdPersonCamera.SetActive(false);

        Car.GetComponent<CarScript>().isRiding = true;
    }

    void Animations()
    {
        currentPos = transform.position;
        if(currentPos != lastPos)
        {
            Debug.Log("Liikkuu");
            anim.SetBool("isRunning", true);
        }
        else
        {

            Debug.Log("Stop");
            anim.SetBool("isRunning", false);
        }
        lastPos = currentPos;
    }

    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }
    void DrivingMode()
    {
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
                if (agent.remainingDistance < 0.1f)
                {
                    Driving();
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
