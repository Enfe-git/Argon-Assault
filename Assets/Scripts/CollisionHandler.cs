using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadLevelDelay = 2f;
    [SerializeField] ParticleSystem exploder;
    void OnCollisionEnter(Collision collision) {
        StartCrashSequence();
    }

    private void StartCrashSequence() {
        exploder.Play();
        GetComponent<PlayerControls>().enabled = false;
        Invoke("ReloadLevel", loadLevelDelay);
    }

    void ReloadLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
