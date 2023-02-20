using UnityEngine;

public class TextBoxAppearance : MonoBehaviour
{
    bool textBoxOnce = false;

    public void ShowTextBox()
    {
        if (!textBoxOnce)
        {
            Debug.Log("Sample text box");

            textBoxOnce = true;
        }
    }
}