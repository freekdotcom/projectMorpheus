using UnityEngine;
using System.Collections;
using System.Linq;

//Within this class, the core mechanic will be handled
public class PlayerAttackManager : MonoBehaviour {

    private int damagePerShot;
    private float timeBetweenShots;
    private float range;
    private int bulletSpeed;

    //For reloading the gun
    public int ammo;
    private int bulletType = 0;
    private float reloadTime;
    private float canReload;
    private bool reloading;

    private float timer;
    private Ray shootRay;
    private RaycastHit shootHit;
    public GameObject[] bulletPrefabs;
    public Transform transform;
    private float effectsDislpayTime = 0.2f;

    public void SetDamagePerShot(int damagePerShot)
    {
        this.damagePerShot = damagePerShot;
    }

    public void SetTimeBetweenShots(float timeBetweenShots)
    {
        this.timeBetweenShots = timeBetweenShots;
    }

    public void SetRange(float range)
    {
        this.range = range;
    }

    public int GetDamagePerShot()
    {
        return damagePerShot;
    }

    public float GetTimeBetweenShots()
    {
        return timeBetweenShots;
    }

    public float GetRange()
    {
        return range;
    }

    public void SetBulletSpeed(int bulletSpeed)
    {
        this.bulletSpeed = bulletSpeed;
    }
   
    public float GetBulletSpeed()
    {
        return bulletSpeed;
    }

    public void SetReloadTime(float reloadTime)
    {
        this.reloadTime = reloadTime;
    }

    public float GetReloadTime()
    {
        return reloadTime;
    }

	// Use this for initialization
	void Awake () {
        SetTimeBetweenShots(GetTimeBetweenShots());
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        canReload += Time.deltaTime;

        //Make sure that the player can't reload multiple times
        //If the fire button is pressed and the timer allows for shooting
        if (Input.GetButtonDown("Fire1") && timer >= timeBetweenShots && ammo > 0)
        {
            //Shoot an projectile
            Shoot();
        }

        if(timer >= timeBetweenShots * effectsDislpayTime)
        {
            //Disable any effects when the timer has exeeded the other objects
        }

        if(Input.GetButtonDown("Reload") && ammo == 0 )
        {
            StartCoroutine(Reload());
        }
	}

    private void Shoot()
    {
        timer = 0f;
        canReload = 0f;

        //Sets the origin and the direction of the shootray
        shootRay.origin = base.transform.position;
        shootRay.direction = base.transform.position;

        //From here, the array thing with the different bullets will be handled
        var bullet = (GameObject)Instantiate(
            bulletPrefabs[bulletType],
            transform.position,
            transform.rotation
            );

        Debug.Log("bulletspeed: " + GetBulletSpeed());
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * GetBulletSpeed();

        if (bulletPrefabs[bulletType].transform.position.x > Screen.width || bulletPrefabs[bulletType].transform.position.z > Screen.height)
        {
            Destroy(bullet, 5.0f);
        }

        bulletType += 1;
        ammo -= 1;
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(GetReloadTime());
        reloading = true;
        bulletType = 0;
        ammo = bulletPrefabs.Length;
    }



}
