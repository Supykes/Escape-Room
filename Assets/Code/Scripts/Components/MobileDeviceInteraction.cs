using UnityEngine;

public class MobileDeviceInteraction : MonoBehaviour
{
    public GameObject fixedMobileDevice;
    public GameObject itemTransform;
    GameObject pickedUpItem = null;
    ComponentsBuilding componentsBuilding = null;
    bool requiredItem = false;
    int componentsInsertedCount = 0;

    void Start()
    {
        fixedMobileDevice.SetActive(false);
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

    void CheckMobileDeviceRepairStatus()
    {
        if (componentsInsertedCount == 3)
        {
            fixedMobileDevice.SetActive(true);

            Destroy(gameObject);
        }
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