using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class GunScript : MonoBehaviour
{
    [SerializeField]
    private InputManager inputManager;
    public ParticleSystem muzzleFlash;
    public Animator reloadAnimation;
    public GameObject Hitmark;
    public LayerMask IgnoreMe;
    public int weaponSlot = 0;
    [SerializeField]
    private float GunAnimDuration;

    public float damage = 10f;
    public float range = 100f;
    private bool isReloading = false;

    public int maxMagazineAmmo = 10;
    public int totalAmmo = 30;
    public int currentAmmo = 1;
    public float reloadTime = 0.8f;

    private float lastTimeShoot = 0f;
    [SerializeField]
    private float nextTimeToFire = 0.5f;
    
    public Camera fpsCam;
    public GameObject impactEffect;

    

    private void OnEnable()
    {
        isReloading = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (isReloading)
            return;
        //if(currentAmmo <= 0 && totalAmmo > 0 || (currentAmmo < maxMagazineAmmo && Input.GetButtonDown("Reload")))
        if ((currentAmmo < maxMagazineAmmo && Input.GetButtonDown("Reload")))
        {
            StartCoroutine(Reload());
            return;
        }

        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (inputManager.onFoot.Shoot.triggered)
        {
            if (currentAmmo > 0)
           {
            Shoot();
            Invoke(nameof(GunShootAnim), GunAnimDuration);
        }
        else
            return;
        }

    }



    IEnumerator Reload()
    {
        reloadAnimation.SetBool("isReloadingAnim", true);
        isReloading = true;
        Debug.Log("Reloading...");
        Invoke(nameof(ReloadAnimationDelay), 1.2f);

        yield return new WaitForSeconds(reloadTime);

        if(totalAmmo > maxMagazineAmmo && currentAmmo<= 0)
        {
            currentAmmo = maxMagazineAmmo;
            totalAmmo -= maxMagazineAmmo;
        }
        else if(totalAmmo < maxMagazineAmmo && totalAmmo > 0 && currentAmmo <=0)
        {
            currentAmmo += totalAmmo;
            totalAmmo = 0;
        }
        else if(currentAmmo > 0 && currentAmmo < maxMagazineAmmo && totalAmmo > maxMagazineAmmo)
        {
            totalAmmo += currentAmmo;
            currentAmmo = maxMagazineAmmo;
            totalAmmo -= maxMagazineAmmo;
        }
        else if(currentAmmo > 0 && currentAmmo < maxMagazineAmmo && totalAmmo < maxMagazineAmmo)
        {
            currentAmmo += totalAmmo;
            if(currentAmmo > maxMagazineAmmo)
            {
                totalAmmo = currentAmmo - maxMagazineAmmo;
                currentAmmo = maxMagazineAmmo;
            }
            else
            totalAmmo = 0;
        }
        //reloadAnimation.SetBool("isReloadingAnim", false);
        isReloading = false;
    }

    void Shoot()
    {
        if(Time.time > lastTimeShoot + nextTimeToFire) {
        muzzleFlash.Play();
        reloadAnimation.SetBool("isGunShoot", true);
        currentAmmo--;

        RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, ~IgnoreMe))
            {
                Debug.Log(hit.transform.name);

                Target target = hit.transform.GetComponentInParent<Target>();
                if (target != null)
                {
                    if (target.gameObject.tag == "Enemy" && hit.transform.name != "Head")
                    {
                        HitActive();
                        Invoke("HitDisable", 0.15f);
                        target.TakeDamage(damage);
                    }
                    else if (target.gameObject.tag == "Enemy" && hit.transform.name == "Head")
                    {
                        HitActive();
                        Invoke("HitDisable", 0.15f);
                        target.TakeHeadshot(damage);
                    }
                }
                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f);
            }
            lastTimeShoot = Time.time;
        }
    }

    void HitActive()
    {
        Hitmark.SetActive(true);
    }

    void HitDisable()
    {
        Hitmark.SetActive(false);
    }

    private void ReloadAnimationDelay()
    {
        reloadAnimation.SetBool("isReloadingAnim", false);
    }

    private void GunShootAnim()
    {
        reloadAnimation.SetBool("isGunShoot", false);
    }

}
