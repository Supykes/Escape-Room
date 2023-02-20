using UnityEngine;

public class ItemsInteraction : MonoBehaviour
{
    public Transform pickedUpItemTransform;
    float pickUpDistance = 100f;
    GameObject pickableItem;
    GameObject item;
    bool canPickUp;
    public GameObject pickUpText;
    bool textBox;

    void FixedUpdate()
    {
        CheckItems();

        //Debug.Log(canPickUp);
    }

    void Update()
    {
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
                textBox = false;
                canPickUp = true;
                pickableItem = hitInfo.transform.gameObject;

                pickUpDistance = 100f;

                pickUpText.SetActive(true);
            }
            else if (hitInfo.transform.tag == "CanPickUpAndText")
            {
                textBox = true;
                canPickUp = true;
                pickableItem = hitInfo.transform.gameObject;

                pickUpDistance = 100f;

                pickUpText.SetActive(true);
            }
            else
            {
                canPickUp = false;

                pickUpDistance = 2f;

                pickUpText.SetActive(false);
            }
        }
    }

    void PickUpItem()
    {
        item = pickableItem;

        item.transform.parent = pickedUpItemTransform;
        item.transform.position = pickedUpItemTransform.position;
        item.transform.localEulerAngles = new Vector3(-90f, 0f, 0f);

        item.GetComponent<Rigidbody>().isKinematic = true;

        if (textBox)
        {
            item.GetComponent<TextBoxAppearance>().ShowTextBox();
        }
    }

    void DropItem()
    {
        item.transform.parent = null;

        item.GetComponent<Rigidbody>().isKinematic = false;

        item = null;
    }
}