using UnityEngine;
using System.Collections;

public class TestBulletManager : MonoBehaviour {

    public GameObject Bullet;

    public int range;
    public int damage;
    public int bulletSpeed;

    private GameObject player;
    private float damageMultiplier;
    private PlayerAttackManager playerAttack;

	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAttack = player.GetComponent<PlayerAttackManager>();
        playerAttack.SetDamagePerShot(damage * (int)damageMultiplier);
        playerAttack.SetRange(range);
        playerAttack.SetBulletSpeed(bulletSpeed);
    }

    public void SetDamageMultiplier(float damageMultiplier)
    {
        this.damageMultiplier = damageMultiplier;
    }

    public float GetDamageMultiplier()
    {
        return damageMultiplier;
    }

    public GameObject GetBullet()
    {
        return Bullet;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject)
        {
            Destroy(Bullet);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
