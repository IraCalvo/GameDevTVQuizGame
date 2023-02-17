using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float timerToAnswer;
    [SerializeField] float timerToShowCorrectAnswer;

    public bool loadNextQuestion;
    public bool isAnsweringQuestion = false;
    public float fillFraction;
    float timerValue;
    
    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if(isAnsweringQuestion)
        {
            if(timerValue > 0)
            {
                fillFraction = timerValue / timerToAnswer;
            }
            else
            {
                isAnsweringQuestion = false;
                timerValue = timerToShowCorrectAnswer;
            }
        }
        else
        {
            if(timerValue > 0)
            {
                fillFraction = timerValue / timerToShowCorrectAnswer;
            }
            else
            {
                isAnsweringQuestion = true;
                timerValue = timerToAnswer;
                loadNextQuestion = true;
            }
        }
    }
}
