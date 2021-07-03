using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    [SerializeField] Transform[] CameraTransform;
    [SerializeField] Transform[] Model;
    int index;

    bool isMoving = false;

    [SerializeField] float smoothSpeed = 0.125f;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(index);
        gameObject.transform.position = CameraTransform[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        int oldIndex = index;
        isMoving = true;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            if (index >= CameraTransform.Length - 1)
                index = 0;
            else
                index++;

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isMoving = true;

            if (index <= 0)
                index = CameraTransform.Length - 1;
            else
                index--;

            //ÖÖHH???????
        }

        if (isMoving)
        {
            Vector3 SmoothedPosition = Vector3.Lerp(transform.position, CameraTransform[index].position, smoothSpeed);
            transform.position = SmoothedPosition;

            gameObject.transform.rotation = CameraTransform[index].rotation;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameObject.Find("LoadThings").GetComponent<LoadThings>().selectedIndex = index;
            DontDestroyOnLoad(GameObject.Find("LoadThings").gameObject);
            UnityEngine.SceneManagement.SceneManager.LoadScene("RikunScene");
        }
    }

}
