using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit= 15;
    [SerializeField] int hitPoints = 4;

    ScoreBoard scoreBoard;

    void Start() {
        AddRigidbody();

    }

    private void AddRigidbody() {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other) {
        ProcessHit();
    }

    void ProcessHit() {
        scoreBoard.IncreaseScore(scorePerHit);
        hitPoints--;
        if(hitPoints < 1) {
            KillEnemy();
        }
    }

    void KillEnemy() {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }

}
