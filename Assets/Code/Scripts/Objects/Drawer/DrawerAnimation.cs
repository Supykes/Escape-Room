using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerAnimation : MonoBehaviour
{
    private Animator drawerAnim;
    private bool drawerOpen = false;

    private void Awake()
    {
        drawerAnim = gameObject.GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        if (!drawerOpen)
        {
            if (drawerAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                drawerAnim.Play("Open", 0, 0f);
                drawerOpen = true;
            }
        }
        else
        {
            if (drawerAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {
                drawerAnim.Play("Close", 0, 0f);
                drawerOpen = false;
            }
        }
    }
}