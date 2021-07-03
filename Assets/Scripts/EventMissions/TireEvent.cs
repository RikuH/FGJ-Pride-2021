using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireEvent : CarMission
{
    public GameObject Wheel;
    GameObject wheelMesh;
    GameObject wheelCol;

    // Start is called before the first frame update
    void Awake()
    {
        RandomizeCars();
        RandomizeHuman();
        InitEvent();
    }

    private void Start()
    {
        wheelMesh = gameObject.transform.GetChild(3).GetChild(2).GetChild(1).gameObject;
        wheelCol = gameObject.transform.GetChild(3).GetChild(1).GetChild(0).gameObject;

        wheelMesh.SetActive(false);
        wheelCol.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (canHelp())
        {
            StartCoroutine(SmoothDelay());
            isHelped = true;
        }
    }

    IEnumerator SmoothDelay()
    {
        BlackPanel.SetActive(true);
        BlackPanel.GetComponent<Animator>().Play("Blacking");
        yield return new WaitForSeconds(0.1f);

        Car.transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
        Wheel.SetActive(false);
        wheelMesh.SetActive(true);
        wheelCol.SetActive(true);

        yield return new WaitForSeconds(0.9f);
        BlackPanel.SetActive(false);
    }
}
