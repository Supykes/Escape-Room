using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    Animator doorAnimator;

    void Awake()
    {
        doorAnimator = gameObject.GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        doorAnimator.Play("Open", 0, 0f);
    }
}