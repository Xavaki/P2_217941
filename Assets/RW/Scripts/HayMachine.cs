using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachine : MonoBehaviour
{

    public float movementSpeed;
    public float horizontalBoundary;

    public GameObject hayBalePrefab; //Reference to the Hay Bale prefab.
    public Transform haySpawnpoint; //The point from which the hay will  be shot.
    public float shootInterval; //The smallest amount of time between shots
    private float shootTimer; //A timer that to keep track whether the machine can shoot or not

    // Power-ups 
    public bool canShootSuperHay;
    public bool superSpeedActivated;
    public float superMovementSpeed;
    public float superSpeedDuration;
    public float shortenedShootInterval;
    private float baseShootInterval;
    private float baseMovementSpeed;
    public ParticleSystem smokeParticles;
    public Color boostParticlesColor;


    public Transform modelParent; 

    public GameObject blueModelPrefab;
    public GameObject yellowModelPrefab;
    public GameObject redModelPrefab;
    public GameObject superHayPrefab;

    // Start is called before the first frame update
    void Start()
    {
        LoadModel();
        baseMovementSpeed = movementSpeed;
        baseShootInterval = shootInterval;
    }

    private void LoadModel()
    {
        Destroy(modelParent.GetChild(0).gameObject); // Destroy the current model.

        switch (GameSettings.hayMachineColor) // Instantiate a hay machine model prefab based on the chosen color and parent it to modelParent.
        {
            case HayMachineColor.Blue:
                Instantiate(blueModelPrefab, modelParent);
                break;

            case HayMachineColor.Yellow:
                Instantiate(yellowModelPrefab, modelParent);
                break;

            case HayMachineColor.Red:
                Instantiate(redModelPrefab, modelParent);
                break;
        }
    }


    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateShooting();
        ShootSuperHay();
        ActivateSuperSpeed();
       
    }

    private void UpdateMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput < 0 && transform.position.x > -horizontalBoundary)
        {
            transform.Translate(transform.right * -movementSpeed * Time.deltaTime);
        }
        else if (horizontalInput > 0 && transform.position.x < horizontalBoundary)
        {
            transform.Translate(transform.right * movementSpeed * Time.deltaTime);
        }
    }

    private void UpdateShooting()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0 && Input.GetKey(KeyCode.Space))
        {
            shootTimer = shootInterval;
            ShootHay();
        }
    }


    private void ShootHay()
    {
        Instantiate(hayBalePrefab, haySpawnpoint.position, Quaternion.identity);
        SoundManager.Instance.PlayShootClip();
    }

    public void ShootSuperHay()
    {
        if (canShootSuperHay && Input.GetKey(KeyCode.S))
        {
            Instantiate(superHayPrefab, new Vector3(0f,2.5f,-34f), Quaternion.identity);
            SoundManager.Instance.PlayShootSuperHayClip();
            canShootSuperHay = false;
        }
    }

    private IEnumerator ChangeSpeedRoutine()
    {
        movementSpeed = superMovementSpeed;
        shootInterval = shortenedShootInterval; 
        BoostSmokeParticles();
        superSpeedActivated = false;
        yield return new WaitForSeconds(superSpeedDuration);
        movementSpeed = baseMovementSpeed;
        shootInterval = baseShootInterval;
        
    }

    private void BoostSmokeParticles()
    {
        var smokeParticlesMainColor = smokeParticles.main.startColor.color;
        smokeParticlesMainColor = Color.red;
        Debug.Log(smokeParticlesMainColor);
    }

    public void ActivateSuperSpeed()
    {
        if (superSpeedActivated && Input.GetKey(KeyCode.D))
        {
            SoundManager.Instance.PlayActivateSuperSpeedClip();
            StartCoroutine(ChangeSpeedRoutine());
        }
    }
}
