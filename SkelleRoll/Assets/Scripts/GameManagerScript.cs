using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManagerScript : MonoBehaviour {

    public List<GameObject> handles = new List<GameObject>();
    public List<GameObject> prefabs = new List<GameObject>();
    public List<GameObject> floors = new List<GameObject>();
    private int timer = 0;

	// Use this for initialization
	void Start () {
       //handles.AddRange(GameObject.FindGameObjectsWithTag("rearHandle"));
        handles.AddRange(GameObject.FindGameObjectsWithTag("frontHandle"));
	}
	
	// Update is called once per frame
	void Update () {
        timer++;
        if (timer % 60 == 0) {
            int spawnType = Random.Range(0, prefabs.Count);

            GameObject temp = prefabs[spawnType];
            Vector3 position = floors[floors.Count - 1].transform.position;
            position.z += 60;
            temp.transform.position = position;
            Instantiate(temp, temp.transform.position, floors[floors.Count - 1].transform.rotation);
            floors.Add(temp);
        }
	}
}
