using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {

    [Header("Inscribed")]

    //Prefab for instantilating apples
    public GameObject applePrefab;

    //Speed at which the AppleTree moves
    public float speed = 1f;

    //Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    //Chace that the AppleTree will change directions
    public float changeDirChance = 0.1f;

    //Seconds between Apples instantiations
    public float appleDropDelay = 1f;

    public int applesDropped = 0;

    public int waveNum = 1;

    // Start is called before the first frame update
    void Start(){
        //Start dropping apples
        Invoke("DropApple", 2f);   
    }

    void DropApple() {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        applesDropped++;
        if (applesDropped == 10)
        {
            NextWave();
            Invoke("DropApple", appleDropDelay + 2);
        }
        else
        {
            Invoke("DropApple", appleDropDelay);
        }
    }

    // Update is called once per frame
    void Update(){
        //Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        //Changing Direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //Move Right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); //Move Left
        } 
    }

    private void FixedUpdate()
    {
        //Random direction changes are now time-based due to Fixed Update
        if (Random.value < changeDirChance)
        {
            speed *= -1; //Change direction
        }
    }

    private void NextWave()
    {
        speed = Mathf.Abs(speed) + 5;
        applesDropped = 0;
        waveNum += 1;
    }

    //I was able to get the tree to briefly stop dropping apples and speed up the tree's movement, but I still don't know
    //how to get the tree to stop moving entirely (or if that's even possible) or how to make the apples fall faster.
}
