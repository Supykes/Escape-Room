using UnityEngine;

public class FurnaceAnimation : MonoBehaviour
{
    Animator furnaceAnimator;

    void Awake()
    {
        furnaceAnimator = gameObject.GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        furnaceAnimator.Play("Open", 0, 0f);
    }
}