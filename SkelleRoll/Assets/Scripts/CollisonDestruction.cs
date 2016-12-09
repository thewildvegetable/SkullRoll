using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class CollisonDestruction : MonoBehaviour {

    //public GameObject 

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
       
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("player"))
        {
            if (col.gameObject.GetComponent<SkullpowerUps>().canBeHit)
            {
                GameObject manager = GameObject.FindGameObjectWithTag("GameManager");
                Destroy(col.gameObject);
                manager.GetComponent<GameManagerScript>().gl.gameOver = true;
                manager.GetComponent<GameManagerScript>().gl.GetComponent<GameLoop>().LoadState(2);
            }
        }
    }
}
