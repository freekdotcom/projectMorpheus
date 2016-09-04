using UnityEngine;
using System.Collections;

public class GunManager : MonoBehaviour {

    private float timeBetweenShots;
    private float reloadTime;
    private float damageMultiplier;
    private GameObject player;
    private PlayerAttackManager playerAttack;
    private TestBulletManager testbulletManager;

    Vector3 gunPosition;
    Vector3 gunScale;
    Quaternion gunRotation;
    GameObject currentlyEquipedItem;

    void Awake()
    {
        gunPosition = transform.position;
        gunRotation = transform.rotation;
        gunScale = transform.localScale;
        currentlyEquipedItem = this.gameObject;
    }

    // Use this for initialization
    void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
        playerAttack = player.GetComponent<PlayerAttackManager>();
        testbulletManager = player.GetComponent<TestBulletManager>();
      
       // testbulletManager.SetDamageMultiplier(damageMultiplier);
       
    }

    void Update()
    {
        playerAttack.SetReloadTime(reloadTime);
        playerAttack.SetTimeBetweenShots(timeBetweenShots);
        Debug.Log("ReloadTime: " + reloadTime);
        Debug.Log("TimeBetweenShots: " + timeBetweenShots);
    }

    public void TransformEquippedItem(int newReloadTime, int newTimeBetweenShots)
    {
        reloadTime = newReloadTime;
        timeBetweenShots = newTimeBetweenShots;
    }

}
