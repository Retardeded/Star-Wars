using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject EnemyDeathFX;
    [SerializeField] Transform parent;
    [SerializeField] int hitPoints = 3;
    [SerializeField] int scoreFactor = 10;
    ScoreBoard scoreBoard;
	void Start () {
        AddNonTriggerBox();
        scoreBoard = FindObjectOfType<ScoreBoard>();
	}

    private void AddNonTriggerBox()
    {
        Collider ship = gameObject.AddComponent<BoxCollider>();
        ship.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        scoreBoard.ScoreHit(scoreFactor);
        hitPoints = hitPoints - 1;
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(EnemyDeathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
