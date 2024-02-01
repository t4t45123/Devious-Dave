using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int health;
    public int damage;
    public GameObject player;
    Rigidbody2D rb;
    public float speed;
    public float acceleration;
    public float knockBack;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckDeath();
        move();
    }
    void CheckDeath() {
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log("Collided");
        if (other.gameObject.tag == "Bullet") {
            BulletManager bulletScript = other.gameObject.GetComponent<BulletManager>();
            bulletScript.peirces += 1;
            health -= bulletScript.weapon.damage;
            float bulletDir = bulletScript.dirChange;
            float knockbackDirInRad = (bulletDir + 180) * Mathf.Deg2Rad; 
            float x = bulletScript.weapon.knockback * Mathf.Cos(knockbackDirInRad);
            float y = bulletScript.weapon.knockback * Mathf.Sin(knockbackDirInRad);
            rb.velocity = new Vector3(x, y,0);


            Debug.Log("dealt" + bulletScript.weapon.damage);
            
            // Add check for explosion effect
        }
    }
    void move() {
        Vector3 dir = (transform.position - player.transform.position).normalized;
        float CurrentxVel = rb.velocity.x;
        float CurrentyVel = rb.velocity.y;
        //rb.velocity = Mathf.Lerp(rb.velocity, (dir* speed), 1);
        Vector3 targetVel = dir * speed *-1;
        rb.velocity = new Vector3(Mathf.Lerp(CurrentxVel, targetVel.x,acceleration), Mathf.Lerp(CurrentyVel,targetVel.y,acceleration));
    }
}
