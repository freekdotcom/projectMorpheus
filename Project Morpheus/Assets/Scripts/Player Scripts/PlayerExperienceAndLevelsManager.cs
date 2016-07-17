using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerExperienceAndLevelsManager : MonoBehaviour {

    public Slider experienceSlider;

    public int currentExperience;
    public int maxExperienceForNextLevel;

    private int Level = 1;
    private GameObject player;
    private PlayerHealth playerHealth;
    private GunManager gunManager;
    

	// Use this for initialization
	void Awake () {

        player = GameObject.FindGameObjectWithTag("TestPlayer");
        playerHealth = player.GetComponent<PlayerHealth>();

        experienceSlider.value = 0;

    }

    // Update is called once per frame
    void Update () {
        Debug.Log("player level: " +Level);
        Debug.Log("xp needed for nextr lvl: " + maxExperienceForNextLevel);
	}
    
    //Method that is called whenever experience is gained
    public void GainExperience(int amount)
    {
        //Gives the newly gained experience to the current experience
        currentExperience += amount;

        experienceSlider.value = currentExperience;

        if(experienceSlider.value > maxExperienceForNextLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        experienceSlider.value -= maxExperienceForNextLevel;
        playerHealth.healthSlider.maxValue = 150;
        playerHealth.SetStartingHealth(150);
        maxExperienceForNextLevel *= 2;
        Level += 1;
    }

}
