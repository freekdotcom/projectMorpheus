﻿using UnityEngine;
using System.Collections;

public class TestBulletManager : MonoBehaviour {

    public GameObject Bullet;

    public int range;
    public float timeBetweenShots;
    public int damage;
    public int bulletSpeed;

    private GameObject player;
    private PlayerAttackManager playerAttack;
	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("TestPlayer");
        playerAttack = player.GetComponent<PlayerAttackManager>();

        playerAttack.SetDamagePerShot(damage);
        playerAttack.SetTimeBetweenShots(timeBetweenShots);
        playerAttack.SetRange(range);
        playerAttack.SetBulletSpeed(bulletSpeed);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject)
        {
            Destroy(Bullet);
        }
    }
}