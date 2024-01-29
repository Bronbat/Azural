using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageBall : MonoBehaviour {

    public float speed = 20f;
    public int damage = 10;
    public float time = 0.5f;
    public Rigidbody2D rb;
    
    private GameObject player;
    private GameObject boss;

    
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        boss = GameObject.FindGameObjectWithTag("Boss");

        
        Vector2 direction = player.transform.position - boss.transform.position;

        
        Debug.Log("Fırlatılan Top");
        rb.velocity = direction * speed;
    }

    void Update() {
        
        Object.Destroy(gameObject, 2f);
    }

    void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponentInParent<Stats>().takeDamage(damage);
            Destroy(gameObject);
        }
    }

    public void setTransform(GameObject boss) {
        this.boss = boss;
    }
}
