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
            Destroy(col.gameObject);
        }
    }
}
