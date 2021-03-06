using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    [SerializeField] float controlSpeed = 30f;
    [SerializeField] float xRange = 15f;
    [SerializeField] float yRange = 11f;

    [SerializeField] float positionPitchFactor = 3.5f;
    [SerializeField] float positionYawFactor = 3f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float controlRollFactor = -30f;



    float xThrow;
    float yThrow;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        ProcessTranslation();
        ProcessRotation();

    }

    private void ProcessRotation() {

        float pitchDueToPosition = transform.localPosition.y * -positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        

        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslation() {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float yOffset = yThrow * controlSpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;

        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
