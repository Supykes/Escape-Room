using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public GameObject timerText;
    public TMP_Text timeSpentText;
    int isTimerToggled;
    string time;
    float seconds;
    int minutes;
    int hours;

    void Awake()
    {
        isTimerToggled = PlayerPrefs.GetInt("isTimerToggled");

        if (isTimerToggled == 1)
        {
            timerText.SetActive(true);
        }
        else
        {
            timerText.SetActive(false);
        }
    }

    void Update()
    {
        if (!GameManager.isGameOver)
        {
            CountTime();
        }
    }

    void CountTime()
    {
        seconds += Time.deltaTime;

        time = hours.ToString("00") + ":" + minutes.ToString("00") + ":" + ((int)seconds).ToString("00");
        timerText.transform.GetComponent<TextMeshProUGUI>().text = "Timer: " + time;
        timeSpentText.text = "Time spent solving the room: " + time;

        if (seconds >= 60f)
        {
            minutes++;

            seconds %= 60f;

            if (minutes >= 60f)
            {
                hours++;

                minutes %= 60;
            }
        }
    }
}