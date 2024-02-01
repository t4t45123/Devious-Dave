using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "weapon", menuName = "Weapon", order = 3)]
public class Weapon : ScriptableObject
{
    public GameObject bullet;
    public float fireRate;
    public float bulletSpeed;
    public int damage;
    public float knockback;
    public float spread;
    public float ammo;
    public float peircingAmount;
    public float reloadTime;
    public float bulletSize;
    public float range;

    public bool holdToShoot; //I
    //Basic Vars
    


    
}
            