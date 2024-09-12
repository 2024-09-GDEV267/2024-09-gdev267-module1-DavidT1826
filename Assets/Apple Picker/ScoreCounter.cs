using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //This line enables use of uGUI classes like Text
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [Header("Dynamic")]
    public int score = 0;
    private Text uiText;
    public TextMeshProUGUI otherText;


    // Start is called before the first frame update
    void Start()
    {
        uiText = GetComponent<Text>(); 
        otherText = GetComponent<TextMeshProUGUI>(); //This is what to do if you use TextMeshPro instead of Text
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = score.ToString("#,0"); //This 0 is a zero
    }
}
