using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMission : MonoBehaviour
{
    public bool isHelped = false;

    public float distanceToInteract = 5.0f;
    public GameObject Player;

    [SerializeField] GameObject[] Cars;
    [SerializeField] GameObject[] Humans;

    public GameObject Car;
    public GameObject Human;

    [SerializeField] Transform SpawnPos;
    [SerializeField] Transform HumanPos;

    Animator anim;

    public GameObject BlackPanel;

    GameObject gameManager;

    public void InitEvent()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.Find("GameManager").gameObject;
    }

    public void RandomizeCars()
    {
        int rnd = Random.Range(0, Cars.Length - 1);
        Car = Instantiate(Cars[rnd].gameObject, SpawnPos.position, SpawnPos.rotation, transform);
    }
    public void RandomizeHuman()
    {
        int rnd = Random.Range(0, Humans.Length - 1);
        Human = Instantiate(Humans[rnd].gameObject, HumanPos.position, HumanPos.rotation, transform);

        anim = Human.GetComponent<Animator>();
    }

    public bool canHelp()
    {
        if (isHelped)
        {
            anim.SetBool("isHelped", isHelped);
            gameManager.GetComponent<GameManager>().helpedPeople++;
            return false;
        }

        float distance = Vector3.Distance(Human.transform.position, Player.transform.position);
        if (distance < distanceToInteract)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                return true;
            }
        }
        return false;

    }
    void OnDrawGizmosSelected()
    {
        // Draw a semitransparent blue cube at the transforms position
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position, new Vector3(5,2,5));
    }
}
