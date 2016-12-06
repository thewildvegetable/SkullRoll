using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.SceneManagement;
public class GameManagerScript : MonoBehaviour {

    public List<GameObject> handles = new List<GameObject>();
    public List<GameObject> prefabs = new List<GameObject>();
    public List<GameObject> floors = new List<GameObject>();
    public GameObject skull;
    public GameObject fireWall;
    public GameLoop gl;
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

            GameObject temp = Instantiate(prefabs[spawnType]);
            Vector3 position = floors[floors.Count - 1].transform.position;
            position.z = floors.Count * 60;
            position.y = 0;
            temp.transform.SetParent(this.gameObject.transform, false);
            temp.transform.localPosition = position;
            Debug.Log(position);
            
            //Instantiate(temp, temp.transform.position, this.gameObject.transform.rotation);
            floors.Add(temp);
        }

        if (skull != null)
        {

            if (skull.transform.localPosition.y <= -30)
            { //Death by falling 

                if (gl.gameOver == false)
                {
                    gl.gameOver = true;
                    gl.GetComponent<GameLoop>().LoadState(2);
                }
            }


            if (fireWall.transform.position.z > skull.transform.localPosition.z)
            { //checks for z coordinates in the event the player does some sick Melee Super Wavedash tech and flies over the wall
                Debug.Log("Has collided");
                Destroy(skull.gameObject);
                gl.GetComponent<GameLoop>().LoadState(2);

            }
        }

        if (skull == null)
        {
            if (gl.gameOver == false)
            {
                gl.gameOver = true;
                gl.GetComponent<GameLoop>().LoadState(2);
            }
        }

        
    }


}
