using UnityEngine;

public class EndGameScreen : MonoBehaviour
{
    public GameObject endGameView;
    public GameObject timerText;

    void Start()
    {
        endGameView.SetActive(false);
    }

    void OnTriggerEnter(Collider player)
    {
        GameManager.isGameOver = true;
        GameManager.isInputEnabled = false;
        Cursor.lockState = CursorLockMode.None;

        timerText.SetActive(false);
        endGameView.SetActive(true);
    }
}