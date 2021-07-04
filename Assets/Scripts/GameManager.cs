using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject LoadedObjects;
    [SerializeField] Transform StartPosition;
    [SerializeField] GameObject[] PlayerCharacters;

    public int helpedPeople = 0;
    int oldHelped = 0;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(PlayerCharacters[GameObject.Find("LoadThings").gameObject.GetComponent<LoadThings>().selectedIndex], StartPosition.position, StartPosition.rotation, StartPosition);
    }

    private void Update()
    {
        if (helpedPeople > oldHelped)
        {
            Debug.Log("Autettu: " + helpedPeople);
        }
        oldHelped = helpedPeople;
    }
}
