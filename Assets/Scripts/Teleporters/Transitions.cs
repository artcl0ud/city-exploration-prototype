using UnityEngine;

public class Transitions : MonoBehaviour
{
    public Animator FadeAnimator;
    public Animator CinematicBarsAnimator;

    public void SetFadeInOut()
    {
        FadeAnimator.SetTrigger("Fade");
    }

    public void ResetFadeInOut()
    {
        FadeAnimator.ResetTrigger("Fade");
    }

    public void ActivateCutsceneBars()
    {
        CinematicBarsAnimator.SetTrigger("Fade");
    }

    public void DeactivateCutsceneBars()
    {
        CinematicBarsAnimator.SetTrigger("Fade");
    }
}
