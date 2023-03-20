using UnityEngine;

public class RoomCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision item)
    {
        item.transform.parent = null;
    }
}