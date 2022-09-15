using UnityEngine;

public class TransitionFader : MonoBehaviour
{
    public Animator animator; 

    public void SetFadeInOut()
    {
        animator.SetTrigger("Fade");
    }

    public void ResetFadeInOut()
    {
        animator.ResetTrigger("Fade");
    }
}
