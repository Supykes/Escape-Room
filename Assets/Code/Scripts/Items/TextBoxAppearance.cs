using UnityEngine;

public class TextBoxAppearance : MonoBehaviour
{
    public GameObject itemInformationBox;
    bool textBoxOnce = false;

    void Start()
    {
        itemInformationBox.SetActive(false);
    }

    void Update()
    {
        if (!GameManager.isInputEnabled)
        {
            if (Input.GetKeyDown("f"))
            {
                itemInformationBox.SetActive(false);

                GameManager.isInputEnabled = true;
            }
        }
    }

    public void ShowTextBox()
    {
        if (!textBoxOnce)
        {
            itemInformationBox.SetActive(true);

            GameManager.isInputEnabled = false;

            textBoxOnce = true;
        }
    }
}