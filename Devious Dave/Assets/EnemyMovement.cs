using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //rb.MovePosition (Vector3.MoveTowards(transform.position,player.transform.position,speed * Time.deltaTime));
        Vector3 dir = (transform.position - player.transform.position).normalized;
        rb.velocity = dir * speed;
    }
}
