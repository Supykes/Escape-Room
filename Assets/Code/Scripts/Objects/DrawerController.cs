using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerController : MonoBehaviour
{
    private Animator drawerAnim;
    private string objectName=null;
    private bool drawerOpen=false;

    private void Awake()
    {
        drawerAnim=gameObject.GetComponent<Animator>();
        objectName=gameObject.name;
    }
    public void PlayAnimation()
    {
        if (!drawerOpen)
        {
            drawerAnim.Play(objectName + "Open", 0, 0.0f);
            drawerOpen = true;
        }
        else
        {
            drawerAnim.Play(objectName + "Close", 0, 0.0f);
            drawerOpen = false;
        }
    }
}
