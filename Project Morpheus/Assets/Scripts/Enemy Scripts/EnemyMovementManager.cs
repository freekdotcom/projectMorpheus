﻿using UnityEngine;
using System.Collections;

public class EnemyMovementManager : MonoBehaviour {

    Transform player;
    PlayerHealth playerHealth;
    NavMeshAgent nav;

	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("TestPlayer").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
	    
        //If the player has health left
        if(playerHealth.currentHealth > 0)
        {
            //Set the destination towards the player
            nav.SetDestination(player.position);
        }
        //otherwise
        else
        {
            //Do nothing
            nav.enabled = false;
        }
	}
}
