using UnityEngine;

public class UnreachableCollision : MonoBehaviour
{
    public Transform pickedUpItemTransform;

    void OnTriggerStay(Collider item)
    {
        item.gameObject.transform.position = pickedUpItemTransform.position;
    }
}