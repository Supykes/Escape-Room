using UnityEngine;

public class EndGameScreen : MonoBehaviour
{
    public GameObject endGameView;

    void Start()
    {
        endGameView.SetActive(false);
    }

    void OnTriggerEnter(Collider player)
    {
        GameManager.isInputEnabled = false;
        Cursor.lockState = CursorLockMode.None;

        endGameView.SetActive(true);
    }
}