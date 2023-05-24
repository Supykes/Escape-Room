using UnityEngine;

public class UnreachableCollision : MonoBehaviour
{
    public Transform pickedUpItemTransform;

    void OnTriggerStay(Collider item)
    {
        if (item.tag == "CanPickUp" || item.tag == "CanPickUpAndText")
        {
            item.gameObject.transform.position = pickedUpItemTransform.position;
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}