using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    // Start is called before the first frame update
    void Start()
    {
        //Find a GameObject named ScoreCounter in the Scene Hierarchy
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        //Get the ScoreCounter (Script) component of scoreGo
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get the current screen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;

        //The Camera's z position sets how far to push the mouse into 3D
        //If this line causes a NullReferenceExcpetion, selecty the Main Camera
        // in the Hierarchy and set its tag to MainCamera oin the Inspector.
        mousePos2D.z = -Camera.main.transform.position.z;

        //Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //Move the position of this Basket to the x position of the Mouse;
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        pos.y = mousePos3D.y;
        this.transform.position = pos;
        //Here I was able to make one of the baskets follow the cursor, but I was not able to make the stack do so. 
    }

    void OnCollisionEnter(Collision coll)
    {
        //Find out what hit this basket
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Apple"))
        {
            Destroy(collidedWith);
            //Increase the score
            scoreCounter.score += 100;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        }
    }
}
