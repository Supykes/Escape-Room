using UnityEngine;

public class DrawerCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision item)
    {
        item.transform.parent = transform;
    }
}