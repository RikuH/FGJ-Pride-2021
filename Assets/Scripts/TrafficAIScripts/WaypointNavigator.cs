using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointNavigator : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    public Waypoint currentWaypoint;
    int walkingSpeed;
    int direction;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        agent.SetDestination(currentWaypoint.GetPosition());

        walkingSpeed = Random.Range(1, 3);
        agent.speed = walkingSpeed;
        anim.speed = walkingSpeed;

        direction = Mathf.RoundToInt(Random.Range(0, 1));
        Debug.Log(direction);
        //int rndScale = Random.Range(1, 3);
        //transform.localScale = new Vector3(transform.localScale.x * (rndScale*0.7f), transform.localScale.y * (rndScale * 0.7f), transform.localScale.z * (rndScale * 0.7f));
    }

    // Update is called once per frame
    void Update()
    {
        Animations();

        if (agent.remainingDistance < 0.1f)
        {
            if (direction == 0)
            {
                currentWaypoint = currentWaypoint.nextWaypoint;
            }
            else
            {
                currentWaypoint = currentWaypoint.previousWaypoint;
            }


            agent.SetDestination(currentWaypoint.GetPosition());
        }
    }
    void Animations()
    {
        if (transform.hasChanged)
        {
            anim.SetBool("isWalking", true);
            transform.hasChanged = false;
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }
}
