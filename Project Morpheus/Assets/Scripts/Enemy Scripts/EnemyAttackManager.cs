using UnityEngine;
using System.Collections;

public class EnemyAttackManager : MonoBehaviour
{

    public float timeBetweenAttacks;
    public int attackDamage;

    private Animator anim;
    private GameObject player;
    private PlayerHealth playerHealth;
    private bool playerInRange;
    private float timer;

    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("TestPlayer");
        playerHealth = player.GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
    }


    // Checks if the object that was triggered is the player
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("player detected");
            playerInRange = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject == player)
        {
            //The player is no longer in range
            playerInRange = false;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        //If the player is in Range, the timer exceeds the time between attacks and this enemy is alive
        //TODO: add enemy health to this
        Debug.Log(playerInRange);
        if (timer >= timeBetweenAttacks && playerInRange)
        {
            //The enemy can attack
            Attack();
        }
    }

    private void Attack()
    {
        timer = 0f;

        //If the player is not dead
        if (playerHealth.currentHealth > 0)
        {
            //Damage the player
            playerHealth.takeDamage(attackDamage);
        }
    }

}
