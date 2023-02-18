using UnityEngine;

public class ItemsInteraction : MonoBehaviour
{
    public Transform pickedUpItemTransform;
    float pickUpDistance = 100f;
    GameObject pickableItem;
    GameObject item;
    bool canPickUp;

    void Update()
    {
        Debug.Log(canPickUp);

        CheckItems();

        if (canPickUp && item == null)
        {
            if (Input.GetKeyDown("e"))
            {
                PickUpItem();
            }
        }

        if (item != null)
        {
            if (Input.GetKeyDown("q"))
            {
                DropItem();
            }
        }
    }

    void CheckItems()
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo, pickUpDistance))
        {
            if (hitInfo.transform.tag == "CanPickUp")
            {
                canPickUp = true;
                pickableItem = hitInfo.transform.gameObject;

                pickUpDistance = 100f;
            }
            else
            {
                canPickUp = false;

                pickUpDistance = 2f;
            }
        }
    }

    void PickUpItem()
    {
        item = pickableItem;

        item.transform.position = pickedUpItemTransform.position;
        item.transform.parent = pickedUpItemTransform;
        item.transform.localEulerAngles = new Vector3(-90f, 0f, 0f);

        item.GetComponent<Rigidbody>().isKinematic = true;
    }

    void DropItem()
    {
        item.transform.parent = null;

        item.GetComponent<Rigidbody>().isKinematic = false;

        item = null;
    }
}