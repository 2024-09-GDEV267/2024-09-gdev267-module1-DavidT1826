using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -20f)
        {
            Score.score = (int)this.transform.position.x + 10;
            Destroy(this.gameObject);
        }
    }
}
