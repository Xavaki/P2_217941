using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pickup()
    {
        GetComponent<Move>().enabled = true;
        GetComponent<TweenScale>().enabled = true;
        GetComponent<DestroyTimer>().enabled = true;
        SoundManager.Instance.PlayPickupClip();
        PowerupManager.Instance.AssignPowerup();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hay"))
        {
            Pickup();
        }
    }
}
