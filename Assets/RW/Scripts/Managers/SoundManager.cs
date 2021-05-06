using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;

    public AudioClip shootClip;
    public AudioClip sheepHitClip;
    public AudioClip sheepDroppedClip;
    public AudioClip shootSuperHayClip;
    public AudioClip activateSuperSpeedClip;
    public AudioClip pickupClip;

    private Vector3 cameraPosition;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        cameraPosition = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlaySound(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, cameraPosition);
    }

    public void PlayShootClip()
    {
        PlaySound(shootClip);
    }

    public void PlaySheepHitClip()
    {
        PlaySound(sheepHitClip);
    }

    public void PlaySheepDroppedClip()
    {
        PlaySound(sheepDroppedClip);
    }
    public void PlayShootSuperHayClip()
    {
        PlaySound(shootSuperHayClip);
    }
    public void PlayActivateSuperSpeedClip()
    {
        PlaySound(activateSuperSpeedClip);
    }
    public void PlayPickupClip()
    {
        PlaySound(pickupClip);
    }
}
