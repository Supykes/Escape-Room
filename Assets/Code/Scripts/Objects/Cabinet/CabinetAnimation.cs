using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetAnimation : MonoBehaviour
{
    private Animator doorAnim;
    private bool doorOpen = false;

    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        if (!doorOpen)
        {
            if (doorAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                doorAnim.Play("Open", 0, 0f);
                doorOpen = true;
            }
        }
        else
        {
            if (doorAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {
                doorAnim.Play("Close", 0, 0f);
                doorOpen = false;
            }
        }
    }
}