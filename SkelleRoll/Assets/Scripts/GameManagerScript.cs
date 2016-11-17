using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManagerScript : MonoBehaviour {

    public List<GameObject> handles = new List<GameObject>();
    public List<GameObject> prefabs = new List<GameObject>();
    public List<GameObject> floors = new List<GameObject>();

	// Use this for initialization
	void Start () {
       //handles.AddRange(GameObject.FindGameObjectsWithTag("rearHandle"));
        handles.AddRange(GameObject.FindGameObjectsWithTag("frontHandle"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
