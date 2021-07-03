using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuckEvent : CarMission
{
    [SerializeField] Transform ReadyPosition;
    // Start is called before the first frame update
    void Awake()
    {
        RandomizeCars();
        RandomizeHuman();
    }

    // Update is called once per frame
    void Update()
    {
        if (canHelp())
        {
            //Joku kamera feidaus
            Car.transform.position = ReadyPosition.position;
            Car.transform.rotation = ReadyPosition.rotation;
        }
    }
}
