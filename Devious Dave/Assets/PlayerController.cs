using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public int health;
    public bool alive;
    public float acceleration;
    public bool CanBeDamaged;
    public float invulnerabilityTime;
    public float currentInvulnTime;


    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        HealthManager();
    }
    void Move() {
        //Vector3 pos = new Vector3 (Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0);
        //transform.position += pos;
        Vector3 input = new Vector3 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"),0).normalized;
        
        rb.velocity = new Vector3 (Mathf.Lerp(rb.velocity.x, input.x * moveSpeed, acceleration), Mathf.Lerp(rb.velocity.y, input.y * moveSpeed, acceleration));

    }
    void OnCollisionStay2D(Collision2D other) {
        //Debug.Log("Collided with sometihng");
        if (other.gameObject.tag == "Enemy") {
            
            //Debug.Log("enemyCollided with enemy");
            if (CanBeDamaged) {
                EnemyManager enemyInfo = other.gameObject.GetComponent<EnemyManager>();
                float knockback = enemyInfo.knockBack;
                DamagePlayer(enemyInfo.damage);
                Vector3 enemyDir = (other.gameObject.GetComponent<Rigidbody2D>().velocity).normalized;
                rb.velocity = (enemyDir * knockback);
                //Debug.Log(ene);
            }
        }
        }
    void DamagePlayer(int damage) {
        health -= damage;
    }
    
    void HealthManager() {
        if (health >= 0) {
            alive = false;
    }}
}
