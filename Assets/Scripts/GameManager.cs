using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject LoadedObjects;
    [SerializeField] Transform StartPosition;
    [SerializeField] GameObject[] PlayerCharacters;

    bool waitPlz = true;
    // Start is called before the first frame update
    void Start()
    {

        Instantiate(PlayerCharacters[GameObject.Find("LoadThings").gameObject.GetComponent<LoadThings>().selectedIndex], StartPosition.position, StartPosition.rotation, StartPosition);
        //Joku mättää? Äijä pyörii ulos keskiöstään :DDDD
    }
}
