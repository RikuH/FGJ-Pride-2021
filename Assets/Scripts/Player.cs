using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject DriverDoor;
    [SerializeField] float AbleToGetInCarDistance;

    NavMeshAgent agent;
    bool isGoingToDrive = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
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
                if(agent.remainingDistance < 0.1f)
                {
                    Debug.Log("Nyt ajaa");
                }
            }
        }
    }
}
