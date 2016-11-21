using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;


public class GameLoop : MonoBehaviour
{
    public int value;

    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {



    }

   public void LoadState(int load)
    {

        if (load == 0) //Menu State
        {
            SceneManager.LoadScene("Menu");
        }

        if (load == 1) //Gameplay State
        { 

            //Set a canPause = true
            SceneManager.LoadScene("test_level");
   
        }

        if (load == 2) //Game Over State
        { 

            SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
            //Set a canPause = false

        }
    }
}
