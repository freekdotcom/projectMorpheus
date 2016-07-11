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
    private bool reloading;

    private float timer;
    private Ray shootRay;
    private RaycastHit shootHit;
    private int shootableMask;
    private ParticleSystem gunParticles;
    private LineRenderer gunLine;
    private Light gunLight;
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

	// Use this for initialization
	void Awake () {
        shootableMask = LayerMask.GetMask("shootable");
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunLight = GetComponent<Light>();
        SetTimeBetweenShots(GetTimeBetweenShots());
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
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
            DisableEffects();
        }

        if(Input.GetButtonDown("Reload") && ammo == 0)
        {
            Reload();
        }
	}

    private void DisableEffects()
    {
        //Disables the shoot stuff
        gunLine.enabled = false;
        gunLight.enabled = false;
    }

    private void Shoot()
    {
        timer = 0f;
        //TODO: remove this line
        SetRange(GetRange());
        gunLight.enabled = true;
       
        //Allows to create the gun particles
        gunParticles.Stop();
        gunParticles.Play();

        //Enables the line renderer and sets the position of the gunline at the barrel of the gun
        gunLine.enabled = true;
        gunLine.SetPosition(0, base.transform.position);

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

        Destroy(bullet, 6.0f);

        bulletType += 1;
        ammo -= 1;
    }

    private void Reload()
    {
        bulletType = 0;
        ammo = 3;
    }



}
