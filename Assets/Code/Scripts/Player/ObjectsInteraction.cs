using UnityEngine;

public class ObjectsInteraction : MonoBehaviour
{
    float interactDistance = 100f;
    CabinetAnimation interactableDoor = null;
    DrawerAnimation interactableDrawer = null;
    bool canInteract;
    public GameObject openText;

    void FixedUpdate()
    {
        CheckInteractions();
    }

    void Update()
    {
        if (GameManager.isInputEnabled)
        {
            if (canInteract)
            {
                if (Input.GetKeyDown("e") && interactableDoor != null)
                {
                    interactableDoor.PlayAnimation();
                    interactableDoor = null;
                }
                else if (Input.GetKeyDown("e") && interactableDrawer != null)
                {
                    interactableDrawer.PlayAnimation();
                    interactableDrawer = null;
                }
            }
        }
    }

    void CheckInteractions()
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo, interactDistance))
        {
            if (hitInfo.transform.tag == "IsDoor")
            {
                canInteract = true;
                interactableDoor = hitInfo.collider.gameObject.GetComponent<CabinetAnimation>();
                interactableDrawer = null;

                interactDistance = 100f;

                openText.SetActive(true);
            }
            else if (hitInfo.transform.tag == "IsDrawer")
            {
                canInteract = true;
                interactableDrawer = hitInfo.collider.gameObject.GetComponent<DrawerAnimation>();
                interactableDoor = null;

                interactDistance = 100f;

                openText.SetActive(true);
            }
            else
            {
                canInteract = false;

                interactDistance = 2f;

                openText.SetActive(false);
            }
        }
    }
}