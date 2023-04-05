using UnityEngine;

public class ObjectsInteraction : MonoBehaviour
{
    float interactDistance = 100f;
    CabinetAnimation interactableDoor = null;
    DrawerAnimation interactableDrawer = null;
    FurnaceInteraction interactableFurnace = null;
    LightSwitchInteraction interactableSwitch = null;
    bool canInteract;
    public GameObject openText;
    public GameObject useText;

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
                else if (Input.GetKeyDown("e") && interactableFurnace != null && !FurnaceInteraction.startTimer)
                {
                    interactableFurnace.ProcessRawMaterial();
                    interactableFurnace = null;
                }
                else if (Input.GetKeyDown("e") && interactableSwitch != null)
                {
                    interactableSwitch.SwitchLight();
                    interactableSwitch = null;
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
                interactableFurnace = null;
                interactableSwitch = null;

                interactDistance = 100f;

                openText.SetActive(true);
                useText.SetActive(false);
            }
            else if (hitInfo.transform.tag == "IsDrawer")
            {
                canInteract = true;
                interactableDrawer = hitInfo.collider.gameObject.GetComponent<DrawerAnimation>();
                interactableDoor = null;
                interactableFurnace = null;
                interactableSwitch = null;

                interactDistance = 100f;

                openText.SetActive(true);
                useText.SetActive(false);
            }
            else if (hitInfo.transform.tag == "IsFurnace")
            {
                canInteract = true;
                interactableFurnace = hitInfo.collider.gameObject.GetComponent<FurnaceInteraction>();
                interactableDoor = null;
                interactableDrawer = null;
                interactableSwitch = null;

                interactDistance = 100f;

                openText.SetActive(false);
                useText.SetActive(true);
            }
            else if (hitInfo.transform.tag == "IsLightSwitch")
            {
                canInteract = true;
                interactableSwitch = hitInfo.collider.gameObject.GetComponent<LightSwitchInteraction>();
                interactableFurnace = null;
                interactableDoor = null;
                interactableDrawer = null;

                interactDistance = 100f;

                openText.SetActive(true);
                useText.SetActive(false);
            }
            else
            {
                canInteract = false;

                interactDistance = 2f;

                openText.SetActive(false);
                useText.SetActive(false);
            }
        }
    }
}