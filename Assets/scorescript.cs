using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scorescript : MonoBehaviour
{

    public int scoreVal;
    private TextMeshProUGUI scoreCounterText;

    private void Awake()
    {
        scoreCounterText = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        scoreVal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreCounterText.text = "Score:     " + scoreVal.ToString();
    }

    public void raiseScore()
    {
        scoreVal += 100;
    }
}
