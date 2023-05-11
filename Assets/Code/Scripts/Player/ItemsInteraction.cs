using UnityEngine;

public class ItemsInteraction : MonoBehaviour
{
    public Transform pickedUpItemTransform;
    float pickUpDistance = 2f;
    GameObject pickableItem;
    GameObject item;
    bool canPickUp;
    public GameObject pickUpText;
    bool textBox;

    void FixedUpdate()
    {
        CheckItems();
    }

    void Update()
    {
        if (GameManager.isInputEnabled)
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
                pickUpText.SetActive(false);

                if (Input.GetKeyDown("q"))
                {
                    DropItem();
                }
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

                pickUpText.SetActive(true);
            }
            else if (hitInfo.transform.tag == "CanPickUpAndText")
            {
                textBox = true;
                canPickUp = true;
                pickableItem = hitInfo.transform.gameObject;

                pickUpText.SetActive(true);
            }
            else
            {
                canPickUp = false;

                pickUpText.SetActive(false);
            }
        }
        else
        {
            canPickUp = false;

            pickUpText.SetActive(false);
        }
    }

    void PickUpItem()
    {
        item = pickableItem;

        item.transform.parent = pickedUpItemTransform;
        item.transform.position = pickedUpItemTransform.position;
        item.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        item.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);

        item.GetComponent<Rigidbody>().isKinematic = true;

        if (textBox)
        {
            item.GetComponent<TextBoxAppearance>().ShowTextBox();
        }
    }

    void DropItem()
    {
        item.transform.parent = null;
        item.transform.localScale = new Vector3(1f, 1f, 1f);

        item.GetComponent<Rigidbody>().isKinematic = false;
        item.GetComponent<Rigidbody>().AddForce(transform.forward * 1.5f, ForceMode.Impulse);

        item = null;
    }
}