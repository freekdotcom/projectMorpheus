using UnityEngine;
using System.Collections;

/**
* Class that handles the health of an generic enemy
  TODO: change this class when introducing more enemy types
*/
public class EnemyHealth : MonoBehaviour {
    
    public int startingHealth;
    public int currentHealth;

    private Animator anim;
    private ParticleSystem hitParticiles;
    private CapsuleCollider capsuleCollider;
    private bool isDead;
    private GameObject player;
    private PlayerExperienceAndLevelsManager xpManager;

	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
        hitParticiles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        currentHealth = startingHealth;

        player = GameObject.FindGameObjectWithTag("TestPlayer");
        xpManager = player.GetComponent<PlayerExperienceAndLevelsManager>();

    }

    // Update is called once per frame
    void Update () {
        Debug.Log("Enemy current health: " + currentHealth);
	}

    //Method that handles the taking damage of an enemy unit
    public void takeDamage(int amount)
    {
        //No point of taking damage when the enemy is dead
        if (isDead)
            return;

        //calculates the damage
        currentHealth -= amount;
        
        //Set the particles to where the enemy has been hit
        //hitParticiles.transform.position = hitPoint;

        if(currentHealth <= 0)
        {
            Death();
        }
    }

    //Method that handles the death of an enemy
    private void Death()
    {
        //The enemy is dead
        isDead = true;

        //Now it can no longer be hit
        capsuleCollider.isTrigger = true;

        xpManager.GainExperience(110);
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<EnemyHealth>().enabled = false;
        Destroy(gameObject, 1f);
    }
}
