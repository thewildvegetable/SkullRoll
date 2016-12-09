using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour {

    // Use this for initialization
    public Canvas mainCanvas;
    public Button backGame;
    private bool isPaused;
    public GameObject Player;
  
    void Start () {
        Time.timeScale = 1;
        backGame = backGame.GetComponent<Button>();
        mainCanvas = mainCanvas.GetComponent<Canvas>();
        isPaused = false;
        mainCanvas.enabled = false;
        backGame.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
	if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = true;
            Time.timeScale = 0;
            mainCanvas.enabled = true;
            backGame.enabled = true;
            Cursor.visible = true;
            GameObject.FindGameObjectWithTag("Fire").GetComponent<FireWallScript>().enabled = false;
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().enabled = false;
        }
        else if (Time.timeScale == 0 && isPaused == false)
        {
            Time.timeScale = 1;
            Cursor.visible = false;
            mainCanvas.enabled = false;
            backGame.enabled = false;
            GameObject.FindGameObjectWithTag("Fire").GetComponent<FireWallScript>().enabled = true;
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().enabled = true;
        }
    }

    /// <summary>
    /// Returning back to the game
    /// by pressing back button
    /// </summary>
    public void BackToGame()
    {
        isPaused = false;
    }

}
