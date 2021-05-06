using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public static PowerupManager Instance;
    HayMachine hayMachine;
    PowerupSpawner powerupSpawner;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        hayMachine = FindObjectOfType<HayMachine>();
        powerupSpawner = FindObjectOfType<PowerupSpawner>();

    }

    // Update is called once per frame
    void Update()
    {
        ResumePowerupSpawning();
    }

    public void AssignPowerup()
    {
        hayMachine.canShootSuperHay = true;
        hayMachine.superSpeedActivated = true;
    }

    private void ResumePowerupSpawning()
    {
        if (!hayMachine.canShootSuperHay && !hayMachine.superSpeedActivated && powerupSpawner.canSpawn)
        {
            powerupSpawner.canSpawn = true;
        }
    }
}
