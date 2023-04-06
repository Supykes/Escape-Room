using UnityEngine;

public class RecyclingBoxInteraction : MonoBehaviour
{
    public GameObject itemTransform;
    public GameObject door;
    GameObject pickedUpItem = null;
    bool requiredItem = false;
    DoorAnimation doorAnimation;

    void Start()
    {
        doorAnimation = door.GetComponent<DoorAnimation>();
    }

    void Update()
    {
        GetChild();
        CheckRequiredItem();
    }

    void GetChild()
    {
        if (itemTransform.transform.childCount > 0)
        {
            pickedUpItem = itemTransform.transform.GetChild(0).gameObject;
        }
        else
        {
            pickedUpItem = null;
        }
    }

    void CheckRequiredItem()
    {
        if (pickedUpItem != null && pickedUpItem.name == "Mobile Device")
        {
            requiredItem = true;
        }
        else
        {
            requiredItem = false;
        }
    }

    public void RecycleMobileDevice()
    {
        if (requiredItem)
        {
            Destroy(pickedUpItem);

            doorAnimation.OpenDoor();
        }
    }
}