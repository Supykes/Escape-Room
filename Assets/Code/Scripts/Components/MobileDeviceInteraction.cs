using UnityEngine;
using System.Collections;
using TMPro;

public class MobileDeviceInteraction : MonoBehaviour
{
    public GameObject fixedMobileDevice;
    public GameObject itemTransform;
    public TMP_Text repairStatusText;
    GameObject pickedUpItem = null;
    ComponentsBuilding componentsBuilding = null;
    bool requiredItem = false;
    int componentsInsertedCount = 0;

    void Start()
    {
        fixedMobileDevice.SetActive(false);
        repairStatusText.gameObject.SetActive(false);
    }

    void Update()
    {
        GetChild();
        CheckRequiredItem();
        CheckMobileDeviceRepairStatus();
    }

    void GetChild()
    {
        if (itemTransform.transform.childCount > 0)
        {
            pickedUpItem = itemTransform.transform.GetChild(0).gameObject;
            componentsBuilding = pickedUpItem.GetComponent<ComponentsBuilding>();
        }
        else
        {
            pickedUpItem = null;
        }
    }

    void CheckRequiredItem()
    {
        if (pickedUpItem != null && componentsBuilding != null)
        {
            if (componentsBuilding.isMetalInserted == true)
            {
                requiredItem = true;
            }
        }
        else
        {
            requiredItem = false;
        }
    }

    IEnumerator SpawnFixedMobileDevice(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        fixedMobileDevice.SetActive(true);

        Destroy(gameObject);
    }

    void CheckMobileDeviceRepairStatus()
    {
        if (componentsInsertedCount == 3)
        {
            StartCoroutine(SpawnFixedMobileDevice(1.5f));
        }

        if (componentsInsertedCount == 1)
        {
            repairStatusText.gameObject.SetActive(true);
        }

        repairStatusText.text = componentsInsertedCount + "/3";
    }

    public void InsertComponent()
    {
        if (requiredItem)
        {
            Destroy(pickedUpItem);

            componentsInsertedCount++;
        }
    }
}