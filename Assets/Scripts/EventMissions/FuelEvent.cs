using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelEvent : CarMission
{
    bool isGettingFuel = false;
    public GameObject[] GasStations;
    // Start is called before the first frame update
    void Awake()
    {
        RandomizeCars();
        RandomizeHuman();
    }

    private void Start()
    {
        GasStations = GameObject.FindGameObjectsWithTag("GasStation");
    }

    // Update is called once per frame
    void Update()
    {
        if (canHelp())
        {
            GetFuel();
        }
    }
    void GetFuel()
    {
        isGettingFuel = true;
    }
}
