using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMission : MonoBehaviour
{
    public float distanceToInteract = 5.0f;
    public GameObject Player;

    public bool DebugMode = true;

    [SerializeField] GameObject[] Cars;
    [SerializeField] GameObject[] Humans;

    public GameObject Car;
    public GameObject Human;

    [SerializeField] Transform SpawnPos;
    [SerializeField] Transform HumanPos;

    public void RandomizeCars()
    {
        int rnd = Random.Range(0, Cars.Length-1);
        Car = Instantiate(Cars[rnd].gameObject, SpawnPos.position, SpawnPos.rotation);
    }
    public void RandomizeHuman()
    {
        int rnd = Random.Range(0, Humans.Length - 1);
        Human = Instantiate(Humans[rnd].gameObject, HumanPos.position, HumanPos.rotation);
    }

    public bool canHelp()
    {
        if (!DebugMode)
        {

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

        else
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                Debug.Log("Helpp");
                return true;
            }
        }
        return false;
    }

}
