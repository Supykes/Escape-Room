using UnityEngine;

public class ComponentsInteraction : MonoBehaviour
{
    float interactDistance = 2f;
    ComponentsBuilding interactableComponent = null;
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