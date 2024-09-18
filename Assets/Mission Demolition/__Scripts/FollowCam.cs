using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI; //The static point of interest

    [Header("Set in Inspector")]
    public float easing = 0.05f;
    public Vector2 minXY = Vector2.zero;

    [Header("Set Dynamically")]
    public float camZ; //The desired Z pos of the camera

    private void Awake()
    {
        camZ = this.transform.position.z;
    }

    private void FixedUpdate()
    {
        //If there's only one line following an if, it doesn't need braces
        if (POI == null) return; //return if there's no poi

        //Get the position of the poi
        Vector3 destination = POI.transform.position;
        //Limite the X and Y to minimum values
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        //Interpolate from teh current camera position toward destination
        destination = Vector3.Lerp(transform.position, destination, easing);
        //For destination.z to be camZ to keep teh camear far enough away
        destination.z = camZ;
        //Set the camear to the destination
        transform.position = destination;
        //Set the orthographhicSiz of the Camera to keep Ground in view
        Camera.main.orthographicSize = destination.y + 10;
    }
}
