using UnityEngine;

public class ObjectsInteraction : MonoBehaviour
{
    private float interactDistance = 100f;
    private DoorController interactableDoor=null;
    private DrawerController interactableDrawer = null;
    private bool canInteract;

    private void FixedUpdate()
    {
        CheckInteractions();
    }

    private void Update()
    {
        if (GameManager.isInputEnabled)
        {
            if (canInteract)
            {
                if (Input.GetKeyDown("e") && interactableDoor!=null)
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

    private void CheckInteractions()
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo, interactDistance))
        {
            if (hitInfo.transform.tag == "IsDoor")
            {
                canInteract = true;
                interactableDoor = hitInfo.collider.gameObject.GetComponent<DoorController>();
                interactableDrawer = null;
                interactDistance = 100f;
            }
            else if (hitInfo.transform.tag == "IsDrawer")
            {
                canInteract = true;
                interactableDrawer=hitInfo.collider.gameObject.GetComponent<DrawerController>();
                interactableDoor = null;
                interactDistance = 100f;
            }
            else
            {
                canInteract = false;

                interactDistance = 2f;
            }
        }
    }
}