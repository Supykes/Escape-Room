using UnityEngine;

public class TimerToggler : MonoBehaviour
{
    void Awake()
    {
        PlayerPrefs.DeleteAll();
    }

    public void SendTimerToggleState(bool timerToggleState)
    {
        PlayerPrefs.SetInt("isTimerToggled", (timerToggleState ? 1 : 0));
    }
}