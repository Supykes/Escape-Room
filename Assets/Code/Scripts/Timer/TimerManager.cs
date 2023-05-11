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
        timerText.transform.GetComponent<TextMeshProUGUI>().text = "Laikas: " + time;
        timeSpentText.text = "Sprendimo laikas: " + time;

        if (seconds >= 60)
        {
            minutes++;

            seconds %= 60;

            if (minutes >= 60)
            {
                hours++;

                minutes %= 60;
            }
        }
    }
}