using UnityEngine;

public class LightSwitchInteraction : MonoBehaviour
{
    public GameObject lampLight;
    public GameObject switchOn;
    public GameObject switchOff;

    void Start()
    {
        switchOff.SetActive(false);
    }

    public void SwitchLight()
    {
        if (lampLight.activeSelf)
        {
            switchOn.SetActive(false);
            switchOff.SetActive(true);

            lampLight.SetActive(false);
        }
        else
        {
            switchOn.SetActive(true);
            switchOff.SetActive(false);

            lampLight.SetActive(true);
        }
    }
}