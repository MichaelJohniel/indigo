using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeValue = 1800f;
    [SerializeField] public bool isOn;
    public TextMesh timeText;
    [SerializeField] private GameManager gm;

    void Update()
    {
        if (isOn && gm.historyTurn > 1) {
            if (timeValue > 0f) {
                timeValue -= Time.deltaTime;
            } else {
                timeValue = 0f;
            }
        }

        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay) {
        if (timeToDisplay <= 0) {
            timeToDisplay = 0;
        } else if (timeToDisplay > 0) {
            //timeToDisplay += 1;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
