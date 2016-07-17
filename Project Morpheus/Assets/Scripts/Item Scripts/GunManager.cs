using UnityEngine;
using System.Collections;

public class GunManager : MonoBehaviour {

    public float timeBetweenShots;
    public float reloadTime;

    private GameObject player;
    private PlayerAttackManager playerAttack;

    // Use this for initialization
    void Start () {

        player = GameObject.FindGameObjectWithTag("TestPlayer");
        playerAttack = player.GetComponent<PlayerAttackManager>();

        playerAttack.SetReloadTime(reloadTime);
        playerAttack.SetTimeBetweenShots(timeBetweenShots);

    }

}
