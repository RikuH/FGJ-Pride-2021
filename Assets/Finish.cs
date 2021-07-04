using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject gameManager;

    [SerializeField] GameObject MainCamera;
    [SerializeField] GameObject FinishCamera;

    [SerializeField] GameObject FadePaneL;
    [SerializeField] GameObject FadePaneEnd;

    bool winned = false;

    [SerializeField]
    Text EndText;
    [SerializeField]
    Text helppedText;
    [SerializeField]
    GameObject EndPanel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(gameObject.transform.position, Player.transform.position);
        if (distance < 25)
        {
            if (!winned)
            {

                MainCamera.SetActive(false);
                StartCoroutine(SmoothDelay());
                FinishCamera.SetActive(true);
                Debug.Log("Voitit" + gameManager.GetComponent<GameManager>().helpedPeople);
                winned = true;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a semitransparent blue cube at the transforms position
        Gizmos.color = new Color(0, 0, 1, 0.5f);
        Gizmos.DrawCube(transform.position, new Vector3(50,5,50));
    }

    IEnumerator SmoothDelay()
    {

        FadePaneL.SetActive(true);
        FadePaneL.GetComponent<Animator>().Play("Blacking");
        yield return new WaitForSeconds(0.1f);

        yield return new WaitForSeconds(0.8f);
        FadePaneL.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        EndPanel.SetActive(true);

        if(gameManager.GetComponent<GameManager>().helpedPeople == 0)
        {
            EndText.text = "Player:\nHi Mom! Sorry that I'm late. I came as fast as I could.\nThere was some hooligans who waved next to the road and trying to block my way.";
        }
        else if (gameManager.GetComponent<GameManager>().helpedPeople > 0)
        {
            EndText.text = "Player:\nHi Mom! Sorry that I'm late. I came as fast as I could.\nI helpped " + gameManager.GetComponent<GameManager>().helpedPeople + " people who needed me.";
        }

        yield return new WaitForSeconds(3f);
        EndText.text = "Mom:\nHoney, remember that it's not about the destination. It's acctually about the journey that you travel.";

        yield return new WaitForSeconds(3f);
        EndPanel.SetActive(false);
        FadePaneEnd.SetActive(true);
        FadePaneEnd.GetComponent<Animator>().Play("EndBlack");
        helppedText.text = "You helpped in your game session " + gameManager.GetComponent<GameManager>().helpedPeople + " many people.";


        yield return new WaitForSeconds(8);
        //Debug.Log("Mainiin");
        //Muista hakea mainin numero
        SceneManager.LoadScene(0);
    }
}
