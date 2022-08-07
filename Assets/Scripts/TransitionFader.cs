using UnityEngine;

public class TransitionFader : MonoBehaviour
{
    public Animator animator; 

    public void FadeIn()
    {
        animator.SetTrigger("Fade");
    }

    public void FadeOut()
    {
        animator.ResetTrigger("Fade");
    }
}
