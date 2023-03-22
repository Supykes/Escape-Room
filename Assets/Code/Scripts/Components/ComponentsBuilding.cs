using UnityEngine;

public class ComponentsBuilding : MonoBehaviour
{
    public GameObject itemTransform;
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
    }

    void CheckRequiredItem()
    {
        if (pickedUpItem != null && pickedUpItem.name == "Metal 1")
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

            transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        }
    }
}