using UnityEngine;
using System.Collections;

public class HealingItemsManager : CoreItemManager {

    public int healDamage;

    private GameObject player;
    private PlayerHealth playerHealth;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("TestPlayer");
        playerHealth = player.GetComponent<PlayerHealth>();
        setId(1);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("TestPlayer"))
        {
            Destroy(gameObject);
        }
    }
}
