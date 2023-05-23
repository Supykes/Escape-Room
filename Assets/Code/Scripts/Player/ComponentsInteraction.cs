using UnityEngine;

public class ComponentsInteraction : MonoBehaviour
{
    float interactDistance = 2f;
    ComponentsBuilding interactableComponent = null;
    MobileDeviceInteraction interactableMobileDevice = null;
    bool canInteract;
    public GameObject useText;

    void FixedUpdate()
    {
        CheckComponents();
    }

    void Update()
    {
        if (GameManager.isInputEnabled)
        {
            if (canInteract)
            {
                if (Input.GetKeyDown("e") && interactableComponent != null)
                {
                    interactableComponent.InsertMetal();
                    interactableComponent = null;
                }
                else if (Input.GetKeyDown("e") && interactableMobileDevice != null)
                {
                    interactableMobileDevice.InsertComponent();
                    interactableMobileDevice = null;
                }
            }
        }
    }

    void CheckComponents()
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo, interactDistance))
        {
            if (hitInfo.transform.tag == "IsComponent")
            {
                canInteract = true;
                interactableComponent = hitInfo.collider.gameObject.GetComponent<ComponentsBuilding>();
                interactableMobileDevice = null;

                useText.SetActive(true);
            }
            else if (hitInfo.transform.tag == "IsBrokenMobileDevice")
            {
                canInteract = true;
                interactableMobileDevice = hitInfo.collider.gameObject.GetComponent<MobileDeviceInteraction>();
                interactableComponent = null;

                useText.SetActive(true);
            }
            else
            {
                canInteract = false;

                useText.SetActive(false);
            }
        }
        else
        {
            canInteract = false;

            useText.SetActive(false);
        }
    }
}