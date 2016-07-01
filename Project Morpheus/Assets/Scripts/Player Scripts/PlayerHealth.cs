using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth;
    public int currentHealth;
    public Slider healthSlider;
    public float flashSpeed;
    public Image damageImage;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);

    private Animator anim;
    private PlayerMovement movement;
    private bool damaged;
    private bool isDead;

	// Use this for initialization
	void Awake () {
        //Getting the compoments
        movement = GetComponent<PlayerMovement>();

        //set the initial health of the player
        currentHealth = startingHealth;

	}
	
	// Update is called once per frame
	void Update () {
        //Checks if the player is damaged
        if (damaged)
        {
            damageImage.color = flashColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
	}

    /*
    *   Public method that will handle the damage
    */
    public void takeDamage(int amount)
    {
        //Sets the flag so the sreen will flash
        damaged = true;

        //Reduces the health of the player
        currentHealth -= amount;

        //Sets the healthbars value to the current health
        healthSlider.value = currentHealth;

        //if the Hp is less than zero, death will occur
        if(currentHealth <= 0 && !isDead)
        {
            //Death has begun
            Death();
        }
    }

    /*
     Private method that will handle the death of the player.
    */
    private void Death()
    {
        isDead = true;
        movement.enabled = false;

    }
}
