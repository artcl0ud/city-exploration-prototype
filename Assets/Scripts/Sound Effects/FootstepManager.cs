using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class FootstepManager : MonoBehaviour
{
    public ThirdPersonController thirdPersonController;
    public Animator animator;

    public AudioClip[] Footsteps_General;
    public AudioClip[] Footsteps_Water;
    public AudioClip[] Footsteps_Grass;

    public AudioSource audioSource;

    public string SurfaceIndicator;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        thirdPersonController = GameObject.Find("PlayerArmature").GetComponent<ThirdPersonController>();
        animator = GameObject.Find("PlayerArmature").GetComponent<Animator>();
    }

    public void OnFootstepAudio(AnimationEvent animationEvent)
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hitData;
        Debug.DrawRay(ray.origin, ray.direction * 1);
        Physics.Raycast(ray, out hitData);

        SurfaceIndicator = hitData.collider.gameObject.tag;

        if (SurfaceIndicator == "Surface_General" && animationEvent.animatorClipInfo.weight > 0.5f)
        {
            if (Footsteps_General.Length > 0)
            {
                var index = Random.Range(0, Footsteps_General.Length);
                AudioSource.PlayClipAtPoint(Footsteps_General[index], transform.TransformPoint(thirdPersonController._controller.center), thirdPersonController.FootstepAudioVolume);
            }
        }

        if (SurfaceIndicator == "Surface_Grass" && animationEvent.animatorClipInfo.weight > 0.5f)
        {
            if (Footsteps_Grass.Length > 0)
            {
                var index = Random.Range(0, Footsteps_Grass.Length);
                AudioSource.PlayClipAtPoint(Footsteps_Grass[index], transform.TransformPoint(thirdPersonController._controller.center), thirdPersonController.FootstepAudioVolume);
            }
        }

        if (SurfaceIndicator == "Surface_Water" && animationEvent.animatorClipInfo.weight > 0.5f)
        {
            if (Footsteps_Water.Length > 0)
            {
                var index = Random.Range(0, Footsteps_Water.Length);
                AudioSource.PlayClipAtPoint(Footsteps_Water[index], transform.TransformPoint(thirdPersonController._controller.center), thirdPersonController.FootstepAudioVolume);
            }
        }
    }
}