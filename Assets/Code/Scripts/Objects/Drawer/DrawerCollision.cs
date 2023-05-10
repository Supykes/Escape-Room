using UnityEngine;

public class DrawerCollision : MonoBehaviour
{
    void OnCollisionStay(Collision item)
    {
        item.transform.parent = transform;
    }
}