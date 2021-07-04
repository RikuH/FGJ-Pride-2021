using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMission : MonoBehaviour
{
    public bool isHelped = false;
    public bool fuelWaiter = false;

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
    public GameObject gameManager;

    public Text DialogyText;
    [SerializeField] GameObject DialogyPanel;

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
        float distance = Vector3.Distance(Human.transform.position, Player.transform.position);
        if (isHelped)
        {
            if (distance < distanceToInteract)
            {
                DialogyText.text = "Thank you very much!\nYou are the best!";
                DialogyPanel.SetActive(true);
                anim.SetBool("isHelped", isHelped);
            }
            else
            {
                DialogyPanel.SetActive(false);

            }
            return false;
        }

        if (distance < distanceToInteract)
        {
            if (gameObject.tag == "StuckEvent")
            {
                DialogyPanel.SetActive(true);
                DialogyText.text = "Hey!\nCould help me my car is stuck?\n\nPress (H) to help";
            }
            else if(gameObject.tag == "TireEvent")
            {

                DialogyPanel.SetActive(true);
                DialogyText.text = "Hey!\nCould help me with my spare wheel?\n\nPress (H) to help";
            }
            else if (gameObject.tag == "RaftEvent")
            {

                DialogyPanel.SetActive(true);
                DialogyText.text = "Hey!\nCould help me push my raft to the sea?\n\nPress (H) to help";
            }
            else if (gameObject.tag == "FuelEvent")
            {

                DialogyPanel.SetActive(true);
                if(!fuelWaiter)
                    DialogyText.text = "Hey!\nCould bring me some fuel?\n\nPress (H) to help";
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                Debug.Log("Yritettäään auttaa?");
                return true;
            }
        }
        else
        {
           DialogyPanel.SetActive(false);

        }
        return false;

    }
    void OnDrawGizmosSelected()
    {
        // Draw a semitransparent blue cube at the transforms position
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position, new Vector3(5, 2, 5));
    }
}
