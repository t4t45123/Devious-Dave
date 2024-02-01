using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    //public float bulletSpeed;
    //[SerializeField] GameObject bullet;
    //public float fireRate;
    public float lastShotTime;
    public float timeSinceLastShot;
    [SerializeField] Transform bulletParent;
    public Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastShot = Time.fixedTime - lastShotTime;
        // if (timeSinceLastShot > weapon.fireRate) {
        //     if (Input.GetKey(KeyCode.Mouse0)) {

        //         Shoot(weapon.bullet,weapon.bulletSpeed,getDir());
        //     }
        // }
        Debug.Log(weapon.GetType());
        if (weapon.GetType().ToString() == ("Shotgun")) {
            Shotgun shotgun = weapon as Shotgun;
            float anglePerShot = shotgun.shotgunAngleRange / shotgun.shots;
            if (weapon.holdToShoot) {
                if (timeSinceLastShot > weapon.fireRate) {
                    if (Input.GetKey(KeyCode.Mouse0)) {
                        for (int i = 0; i < shotgun.shots; i++)
                        {
                            Shoot(weapon.bullet, weapon.bulletSpeed, (getDir() - shotgun.shotgunAngleRange / 2) + (anglePerShot * i));
                        }
                    }
                }
            } 
       
        }else {
            if (weapon.holdToShoot) {
                if (timeSinceLastShot > weapon.fireRate) {
                    if (Input.GetKey(KeyCode.Mouse0)) {
                         Shoot(weapon.bullet,weapon.bulletSpeed,getDir());
                    }
                }
            }else {
            if (timeSinceLastShot > weapon.fireRate) {
                if (Input.GetKeyDown(KeyCode.Mouse0)) {
                        Shoot(weapon.bullet,weapon.bulletSpeed,getDir());
                }
            }
            }
        }
        

    }
    float getDir() {
        // Vector3 MousePos = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x,Input.mousePosition.y,Camera.main.nearClipPlane));
        // Vector3 dir = (MousePos - (new Vector3 (transform.position.x, transform.position.y,0)));
        // return dir;
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y,dir.x ) * Mathf.Rad2Deg;
        return angle;

    }
    void Shoot(GameObject bullet, float bulletSpeed, float direction) {
            BulletManager Bmanager;
            Bmanager = bullet.GetComponent<BulletManager>();
            Bmanager.dir = direction;
            Bmanager.weapon = weapon;
            Bmanager.mousePos = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x,Input.mousePosition.y,Camera.main.nearClipPlane));
            lastShotTime = Time.fixedTime;
            
            GameObject lastCreatedBullet = Instantiate(weapon.bullet, transform.position, Quaternion.identity, bulletParent);
            lastCreatedBullet.transform.localScale = lastCreatedBullet.transform.localScale * weapon.bulletSize;
            
            
    }
}
