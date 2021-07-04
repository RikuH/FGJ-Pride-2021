using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftEvent : CarMission
{
    [SerializeField] Transform ReadyPosition;
    // Start is called before the first frame update
    void Awake()
    {
        RandomizeCars();
        RandomizeHuman();
        InitEvent();
    }
    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (canHelp())
        {

            gameManager.GetComponent<GameManager>().helpedPeople++;
            StartCoroutine(SmoothDelay());
            isHelped = true;
        }
    }
    IEnumerator SmoothDelay()
    {
        BlackPanel.SetActive(true);
        BlackPanel.GetComponent<Animator>().Play("Blacking");
        yield return new WaitForSeconds(0.1f);

        Car.transform.position = ReadyPosition.position;
        Car.transform.rotation = ReadyPosition.rotation;

        Human.transform.position =new Vector3 (Car.transform.position.x, Car.transform.position.y + 0.5f, Car.transform.position.z);
        Human.transform.SetParent(Car.transform);

        yield return new WaitForSeconds(0.8f);
        BlackPanel.SetActive(false);
    }
}
