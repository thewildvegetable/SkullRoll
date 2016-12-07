using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class TestCollision : MonoBehaviour {

    GameLoop gl;

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Obstacle") {

            //Am using these to figure things out
            //            gl.LoadState(2);
            //Destroy(col.gameObject);
            Destroy(gameObject);    
        //Time.timeScale = 0;
            //SceneManager.LoadScene("GameOver"); //Not using LoadState at the moment. Trying to figure out why it isn't calling.
        }

    }
}
