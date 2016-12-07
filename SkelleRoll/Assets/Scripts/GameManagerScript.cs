using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.SceneManagement;
public class GameManagerScript : MonoBehaviour {

    public List<GameObject> handles = new List<GameObject>();
    public List<GameObject> prefabs = new List<GameObject>();
    public List<GameObject> floors = new List<GameObject>();
    public List<GameObject> powerUps = new List<GameObject>();
    public List<GameObject> enemies = new List<GameObject>();
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
        if (skull != null)
        {
            //spawn stuff
            timer++;
            if (timer % 60 == 0)
            {
                int spawnVal = Random.Range(0, prefabs.Count);

                GameObject floorTemp = Instantiate(prefabs[spawnVal]);
                Vector3 position = floors[floors.Count - 1].transform.position;
                position.z = floors.Count * 60;
                position.y = 0;
                floorTemp.transform.SetParent(this.gameObject.transform, false);
                floorTemp.transform.localPosition = position;
                //Debug.Log(position);

                //decide if a pick up or enemy is to be spawned
                spawnVal = Random.Range(0, 10);

                if (spawnVal < 3)
                {
                    //spawn coin
                    spawnVal = Random.Range(0, floorTemp.GetComponent<FloorScript>().spawners.Count);
                    GameObject spawnLoc = floorTemp.GetComponent<FloorScript>().spawners[spawnVal];
                    GameObject powerUp = Instantiate(powerUps[0]);
                    powerUp.transform.SetParent(floorTemp.transform);
                    powerUp.transform.position = spawnLoc.transform.position;
                    Debug.Log(powerUp);

                }
                else if (spawnVal < 5)
                {
                    //spawn enemy
                    spawnVal = Random.Range(0, floorTemp.GetComponent<FloorScript>().spawners.Count);
                    GameObject spawnLoc = floorTemp.GetComponent<FloorScript>().spawners[spawnVal];
                    spawnVal = Random.Range(0, enemies.Count);
                    GameObject enemy = Instantiate(enemies[spawnVal]);
                    enemy.transform.SetParent(floorTemp.transform);
                    enemy.transform.position = spawnLoc.transform.position;
                }
                else if (spawnVal < 7)
                {
                    //spanw powerup
                    spawnVal = Random.Range(0, floorTemp.GetComponent<FloorScript>().spawners.Count);
                    GameObject spawnLoc = floorTemp.GetComponent<FloorScript>().spawners[spawnVal];
                    spawnVal = Random.Range(1, powerUps.Count);
                    GameObject powerUp = Instantiate(powerUps[spawnVal]);
                    powerUp.transform.SetParent(floorTemp.transform);
                    powerUp.transform.position = spawnLoc.transform.position;
                    Debug.Log(powerUp);
                }

                //Instantiate(temp, temp.transform.position, this.gameObject.transform.rotation);
                floors.Add(floorTemp);
            }

            //player death
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
    }


}
