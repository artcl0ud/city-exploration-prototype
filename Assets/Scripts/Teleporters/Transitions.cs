using UnityEngine;

public class Transitions : MonoBehaviour
{
    public Animator BlackFadeAnimator;
    public Animator CinematicBarsAnimator;

    public void BlackFadeIn()
    {
        BlackFadeAnimator.SetTrigger("Fade");
    }

    public void BlackFadeOut()
    {
        BlackFadeAnimator.SetTrigger("Fade");
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
