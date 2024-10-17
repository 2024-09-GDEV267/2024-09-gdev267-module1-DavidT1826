using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    static public int score = 0;
    public Text gt;

    private void Awake()
    {
        gt = this.GetComponent<Text>();
    }

    private void Update()
    {
        print(gt);
        gt.text = "Score: " + score;
        
    }

}
