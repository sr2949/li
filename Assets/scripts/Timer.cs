using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float currentTime = 0f;
    public Text scoreText;
    public static float finalScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameHintMessages.exited == false)
        {
            currentTime += Time.deltaTime;
            finalScore = currentTime;
            scoreText.text = "Time Taken: " + Mathf.RoundToInt(currentTime).ToString();
        }
    }
}
