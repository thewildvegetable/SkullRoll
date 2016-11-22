using UnityEngine;
using System.Collections;

public class MultiDirectionPlat : MonoBehaviour {
    /// <summary>
    /// 1- Up and down
    /// 2- Side to side
    /// 3- back and forth
    /// This relates to the dirCase and controlling the movement of the platform
    /// </summary>
    // Use this for initialization
    public float frequency;//frequency of the object moving either up and down, side to side, back and forth
    public float amp;//the amplitude
    private Vector3 posVect;//the vector that will be applied to the position

    public int dirCase;//the int for the switch that will determine the direction

    void Start()
    {
        posVect = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        switch (dirCase)
        {
            case 1://up and down
                float nextY = posVect.y + amp * Mathf.Sin(frequency * Time.time);
                transform.position = new Vector3(transform.localPosition.x, nextY, transform.localPosition.z);
                break;
            case 2://side to side
                float nextX = posVect.x + amp * Mathf.Sin(frequency * Time.time);
                transform.position = new Vector3(nextX, transform.localPosition.y, transform.localPosition.z);
                break;
            case 3://back and forth
                float nextZ = posVect.z + amp * Mathf.Sin(frequency * Time.time);
                transform.position = new Vector3(transform.localPosition.x, transform.localPosition.y, nextZ);
                break;
            default:
                break;

        }

    }
}
