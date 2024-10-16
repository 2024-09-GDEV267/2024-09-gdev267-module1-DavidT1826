using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    static public int score = 0;

    private void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "Score: " + score;
    }

}
