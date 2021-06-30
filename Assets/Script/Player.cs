using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [SerializeField] float rcsThrust = 4f;
    [SerializeField] float xLimit = 5f;
    [SerializeField] float yLimit = 5f;
    [SerializeField] float pitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float yawFactor = 6f;
    [SerializeField] float controlRollFactor = -20;

    [SerializeField] GameObject[] guns;


    float horizontalThrow;
    float verticalThrow;
    bool isDead = false;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update ()
    {
        if (!isDead)
        {
            RespondToMove();
            ProcessRotation();
            ProcessFiring();
        }

    }

    void Death() // called by string
    {
        isDead = true;
    }
    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * pitchFactor + verticalThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * yawFactor;
        float roll = horizontalThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void RespondToMove()
    {
        horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = rcsThrust * Time.deltaTime * horizontalThrow;
        float newXPos = transform.localPosition.x + xOffset;
        float posX = Mathf.Clamp(newXPos, -xLimit, xLimit);

        float yOffset = rcsThrust * Time.deltaTime * verticalThrow;
        float newYPos = transform.localPosition.y + yOffset;
        float posY = Mathf.Clamp(newYPos, -yLimit, yLimit);

        transform.localPosition = new Vector3(posX, posY, transform.localPosition.z);
    }
    void ProcessFiring()
    {
        if(CrossPlatformInputManager.GetButton("Fire1"))
        {
            ActivateGuns();
        }
        else
        {
            DeactivateGuns();
        }
    }

    void DeactivateGuns()
    {
        foreach(GameObject gun in guns)
        {
            gun.SetActive(false);
        }
    }

    void ActivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(true);
        }
    }
}
