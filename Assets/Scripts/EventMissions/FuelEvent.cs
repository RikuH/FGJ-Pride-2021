using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelEvent : CarMission
{
    bool isGettingFuel = false;
    bool hasFuel = false;
    public GameObject[] GasStations;
    // Start is called before the first frame update
    void Awake()
    {
        RandomizeCars();
        RandomizeHuman();

    }

    private void Start()
    {
        InitEvent();
        GasStations = GameObject.FindGameObjectsWithTag("GasStation");
    }

    // Update is called once per frame
    void Update()
    {
        if (canHelp())
        {
            if (hasFuel)
            {
                Debug.Log("Bensa Tuotu");
                isHelped = true;
            }
            else
            {
                isGettingFuel = true;
                Debug.Log("Hae Bensaa");
            }


        }

        if (isGettingFuel)
        {
            GetFuel();
        }

    }
    void GetFuel()
    {
        for(int i = 0; i < GasStations.Length; i++)
        {
            float distance = Vector3.Distance(Player.transform.position, GasStations[i].transform.position);
            //Debug.Log("Distance between gastations: " + distance);

            if(distance < 5)
            {
                hasFuel = true;
                isGettingFuel = false;
                Debug.Log("Bensaa saatu");
            }
        }
    }

}
