using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class FootstepManager : MonoBehaviour
{
    public ThirdPersonController thirdPersonController; 

    public AudioClip[] Footsteps_General;
    public AudioClip[] Footsteps_Water;
    public AudioClip[] Footsteps_Grass;

    public AudioSource audioSource;

    public string SurfaceIndicator;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void FootstepSoundSwitcher()
    {
        //SurfaceIndicator = hitData.collider.gameObject.tag;
        
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hitData;
        Debug.DrawRay(ray.origin, ray.direction * 1);

        Physics.Raycast(ray, out hitData);

        if (Physics.Raycast(ray, out hitData) && SurfaceIndicator == hitData.collider.gameObject.tag);
        {
            if(SurfaceIndicator == "Footsteps_General")
            {
                var index = Random.Range(0, Footsteps_General.Length);
                audioSource.PlayOneShot(Footsteps_General[index]);
            }

            if(SurfaceIndicator == "Footsteps_Water")
            {
                var index = Random.Range(0, Footsteps_General.Length);
                audioSource.PlayOneShot(Footsteps_General[index]);
            }

            if(SurfaceIndicator == "Footsteps_Grass")
            {
                var index = Random.Range(0, Footsteps_General.Length);
                audioSource.PlayOneShot(Footsteps_General[index]);
            }
        }
    }
}