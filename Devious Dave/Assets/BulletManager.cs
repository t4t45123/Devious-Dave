using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float dir;
    public Vector3 mousePos;
    Rigidbody2D rb;
    float timeCreated;
    GameObject player;
    float timeOfDeath;
    public Weapon weapon;
    public float dirChange;
    public int peirces;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("player");
        
        timeCreated = Time.fixedTime;
        timeOfDeath = timeCreated + weapon.range;
        dirChange = (dir + Random.Range(weapon.spread * -1, weapon.spread));
        
        MoveBullet(player.GetComponent<Rigidbody2D>().velocity);


    }

    // Update is called once per frame
    void Update()
    {
        
        CheckDeath();
        if (Time.fixedTime > timeOfDeath) {
            Destroy(gameObject);
        }
    }
    void MoveBullet(Vector3 playerVel) {
        
        float dirInRad = Mathf.Deg2Rad * dirChange;
        float x = weapon.bulletSpeed * Mathf.Cos(dirInRad);
        float y = weapon.bulletSpeed * Mathf.Sin(dirInRad);
        Vector3 Velocity = new Vector3(x, y, 0);
        rb.velocity = Velocity + playerVel;
        Quaternion rotation = Quaternion.Euler(0,0,dirChange);
        transform.localRotation = rotation;
    }
    void CheckDeath() {
        if (weapon.peircingAmount <= peirces) {
            Destroy(gameObject);
        }
    }
    
}
