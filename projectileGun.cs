using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class projectileGun : MonoBehaviour
{
    //bullets
    public GameObject bullet;
    public float shootForce, upwardForce;

    //gun info
    public float spread, reloadTime, timeBetweenShots;
    public int magSize, bulletsPerTap;
    public bool autoFire;

    public int bulletsLeft, bulletsShot;
    //bools
    bool shooting, readyToShoot, reloading;

    //reference
    public Camera fpsCam;
    public Transform attackPoint;

    //bugs
    public bool allowInvoke = true;

    //other features
    public Text ammoCount;
    public Text currentGun;
    public string gunName;
    public Animator gunAnimations;
    public ParticleSystem muzzleFlash;
    public AudioSource gunshotSound;
    public AudioSource reloadSound;
    
    void Start()
    {
        readyToShoot = true;
        bulletsLeft = magSize;
        allowInvoke = true;
        reloading = false;
        ammoCount.text = ": " + bulletsLeft.ToString() + "/" + magSize.ToString();
        currentGun.text = ": " + gunName;
        CancelInvoke();
    }
    void OnEnable()
    {
        reloading = false;
        readyToShoot = true;
        ammoCount.text = ": " + bulletsLeft.ToString() + "/" + magSize.ToString();
        allowInvoke = true;
        currentGun.text = ": " + gunName;
        CancelInvoke();
    }


    void Update()
    {
        shootInput();
    }

    private void shootInput()
    {
        //checks if shooting input is clicked
        if (autoFire) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //Reload
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magSize && !reloading) Reload();
        if (readyToShoot && !reloading && shooting && bulletsLeft <= 0) Reload();

        //shooting
        if (readyToShoot && !reloading && shooting && bulletsLeft > 0){ bulletsShot = 0; Shoot();}
    }

    private void Shoot()
    {
        if (gunshotSound.isPlaying) gunshotSound.Stop();
        gunshotSound.Play();
        readyToShoot = false;

        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        Vector3 targetPoint;
        if(Physics.Raycast(ray, out hit)) targetPoint = hit.point;
        else targetPoint = ray.GetPoint(200);

        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);
        Debug.Log(directionWithoutSpread);
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0f);

        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        currentBullet.transform.forward = directionWithSpread.normalized;
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
      
        bulletsLeft--;
        bulletsShot++;
        
        if (bulletsShot < bulletsPerTap && bulletsLeft > 0) Shoot();
        else { 
            gunAnimations.SetTrigger("Shooting");
            if(muzzleFlash.isPlaying) muzzleFlash.Stop();
            muzzleFlash.Play();
            ammoCount.text = ": " + bulletsLeft.ToString() + "/" + magSize.ToString();
            if (allowInvoke)
            {
                Invoke("ResetShot", timeBetweenShots);
                allowInvoke = false;
            }
        }
        


    }
    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        gunAnimations.SetTrigger("Reloading");
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
        if (reloadSound.isPlaying) reloadSound.Stop();
        reloadSound.Play();
    }

    private void ReloadFinished()
    {
        if (allowInvoke)
        {
            bulletsLeft = magSize;
            reloading = false;
            ammoCount.text = ": " + bulletsLeft.ToString() + "/" + magSize.ToString();
        }
    }
}
