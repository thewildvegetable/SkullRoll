using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class SkullpowerUps : MonoBehaviour
{

	// Use this for initialization

    private float currInvinsTime;//current time invinsible

    private int score;//the current score
    public int scoreIncr;//the number to increase the score by
    public Text scoreText;//displaying the score


    public Light glowInvins;//the glow invinsibility effect
    public List<bool> powerupActive;//a bunch of bools to tell which powerup is active
    public List<float> powerupTime;//tells how long the powerup corresponding is active for
                                   // private float[] powerCurrTime;

    private bool canBeHit;//tells if user can take damage in this state
    private List<float> powerCurrTime = new List<float>();//tells how long the powerup has been active for
                                      /// <summary>
                                      /// In array index:
                                      /// 0 is invinsibility
                                      /// 1 is double pickup score
                                      /// </summary>
    void Start () {
        powerupActive[0] = false;
        powerupActive[1] = false;


        glowInvins.enabled = false;
        canBeHit = true;//the user can take damage
        powerCurrTime.Add(0);
        powerCurrTime.Add(0);

        DisplayScore();

    }

    public int Score
    {
        get { return score; }
        set { score = value; }
    }


	// Update is called once per frame
	void Update () {
        //this can be replaced by a for loop in the future.
        if(powerupActive[0]==true)
        {
            Invinsible();
        }
	
	}


    /// <summary>
    /// This method is for making the player unable to get
    /// hurt by the enemies
    /// </summary>
    private void Invinsible()
    {

        if (powerCurrTime[0] < powerupTime[0])
        {
            powerCurrTime[0]++;
            canBeHit = false;
            glowInvins.enabled = true;
        }
        else if (powerCurrTime[0] >= powerupTime[0])
        {
            powerCurrTime[0] = 0;
            powerupActive[0] = false;
            glowInvins.enabled = false;
            canBeHit = true;
        }
    }

    /// <summary>
    /// This will increase the score when a coin is collected
    /// </summary>
    public void IncreaseScore()
    {
        if(powerupActive[1]==false)
        {
            score += scoreIncr;
        }
        else if(powerupActive[1]==true)
        {
            score += (scoreIncr * 2);
        }
       // DisplayScore();

    }

    public void DisplayScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

}
