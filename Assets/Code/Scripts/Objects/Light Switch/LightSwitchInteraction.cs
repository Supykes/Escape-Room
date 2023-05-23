using UnityEngine;

public class LightSwitchInteraction : MonoBehaviour
{
    public GameObject lampLight;
    public GameObject switchOn;
    public GameObject switchOff;
    public GameObject hiddenCodeText;

    public void SwitchLight()
    {
        if (lampLight.activeSelf)
        {
            switchOn.SetActive(false);
            switchOff.SetActive(true);

            lampLight.SetActive(false);

            hiddenCodeText.SetActive(true);
        }
        else
        {
            switchOn.SetActive(true);
            switchOff.SetActive(false);

            lampLight.SetActive(true);

            hiddenCodeText.SetActive(false);
        }
    }
}