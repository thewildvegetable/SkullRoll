using UnityEngine;
using System.Collections;

public class MultipleWaypoints : MonoBehaviour {
    //this is for a platform with multiple waypoints
    //HOW THIS WORKS
    //NEED ATLEAST 2 EMPTY GAME OBJECTS TO SET AS WAYPOINTS(Can use 2 if you want platform to go back and forwth
    //(--this will replace the other script of the moving platform--)
    //THE ORDER OF WAYPOINTS IN THE ARRAY(YOU PLACE IN ARRAY FROM INSPECTOR) IS THE ORDER THE PLATFORM WILL MOVE.
    //THE FIRST WAYPOINT WILL BE THE STARTING LOCATION OF THE PLATFORM
    //THE LAST WAYPOINT IN THE ARRAY IS LAST POINT
    //THE PLATFORM WILL RETURN BACK TO THE START(GOING IN ORDER THROUGH EACH POINT BACKWARDS) WHEN REACHES FINAL POINT



    public Transform[] wayP;//waypoints the platform will move to. (first one in array is starting position)
    private Transform startWP;//starting position
    private Transform next;//the next waypoint

    private int index = 0;//the current waypoint(index) the platform is on
    public float moveSpd;//the moving speed of the platform
    private float timeMove;//the time it takes from one point to the next
    private bool goingForward;

    // Use this for initialization
    void Start () {

        this.transform.position =wayP[0].position;//setting the platform's position to the starting point
        goingForward = true;

    }
	
	// Update is called once per frame
	void Update () {
        PlatformMove();
	}

    //for moving the platforms
    void PlatformMove()
    {
      
            if (goingForward==true)
            {
                next = wayP[index];
                if (this.transform.position == next.position)
                {
                    index++;
                }
                transform.position = Vector3.MoveTowards(transform.position, next.position, moveSpd * Time.deltaTime);

                if(this.transform.position==wayP[wayP.Length-1].position)
                {
                    goingForward = false;
                }
                //reach an end, go other way

            }
            else if (goingForward == false)
            {
                //going back
                next = wayP[index];
                if (this.transform.position == next.position)
                {
                    index--;
                }
                transform.position = Vector3.MoveTowards(transform.position, next.position, moveSpd * Time.deltaTime);
                //reached an end, go other way
                if (this.transform.position== wayP[0].position)
                {
                    goingForward = true;
                }
            }
        }

    

}
