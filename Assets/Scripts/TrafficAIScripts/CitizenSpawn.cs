using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenSpawn : MonoBehaviour
{
    public GameObject CitizenPrefab;
    public int CitizensToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        int count = 0;
        while(count < CitizensToSpawn)
        {
            GameObject obj = Instantiate(CitizenPrefab);
            Transform child = transform.GetChild(Random.Range(0, transform.childCount - 1));
            obj.GetComponent<WaypointNavigator>().currentWaypoint = child.GetComponent<Waypoint>();
            obj.transform.position = child.position;

            yield return new WaitForEndOfFrame();

            count++;
        }
    }
}
