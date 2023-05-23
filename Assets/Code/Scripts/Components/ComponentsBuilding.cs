using UnityEngine;

public class ComponentsBuilding : MonoBehaviour
{
    public GameObject itemTransform;
    public bool isMetalInserted = false;
    GameObject pickedUpItem = null;
    bool requiredItem = false;

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
        if (pickedUpItem != null && ((pickedUpItem.name == "Gold Bar" && transform.name == "Chip") || (pickedUpItem.name == "Cobalt Bar" && transform.name == "Battery") ||
        (pickedUpItem.name == "Gallium Bar" && transform.name == "Screen")))
        {
            requiredItem = true;

            transform.gameObject.tag = "IsComponent";
        }
        else
        {
            requiredItem = false;

            transform.gameObject.tag = "CanPickUp";
        }
    }

    public void InsertMetal()
    {
        if (requiredItem)
        {
            Destroy(pickedUpItem);

            isMetalInserted = true;

            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 2f, ForceMode.Impulse);
        }
    }
}