using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;


public class GameLoop : MonoBehaviour
{
    public int value; //Checks the current state

    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

        //Code to ignore keys

        //while (value == 2) {
        //    //DisableKey(Keycode.r);
        //    //DisableKey(Keycode.p);
        //}

    }

    bool LoadSceneOkay() { //To be finished method

        

        return false;
    }

   public void LoadState(int load)
    {

        switch (load)
        {
            case 0: SceneManager.LoadScene("test_level"); //Loads level (Change name of level as needed)
                break;

            case 1:
                SceneManager.LoadScene("Menu"); //Opens start screen
                break;

            case 2:
                SceneManager.LoadScene("GameOver"); //Currently loads game over screen
                break;
        }
    }


    static void DisableKeys(KeyCode[] keys)
    {
        if (!Event.current.isKey)
        {
            return;
        }

        foreach (KeyCode key in keys)
        {
            if (Event.current.keyCode == key)
            {
                Event.current.Use();
            }
        }
    }



    static void DisableKey(KeyCode key)
    {
        DisableKeys(new KeyCode[] { key });
    }
}
