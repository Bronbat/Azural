using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health = 500;
    public float timeDestroy = 1.5f;
    public Animator animator;
    public GameObject sonidoMuerte;

    public GameObject coins;
    public GameObject hearts;
    public GameObject sword;
    public GameObject shield;

    public int maxCoins = 5;
    public int maxHearts = 3;
    public int maxSwords = 2;
    public int maxShields = 2;

    public void TakeDamage(int damage) {
        this.health -= damage;

        
        animator.SetTrigger("hurt");

        if(health <= 0) {
            Die();
        }
    }
    public void DieInWater()
    {
        // Bu metod, düşman suya girdiğinde çağrılır.

        // Düşman suya girdiğinde ölüm animasyonunu oynatır
        dropItems();

        // Animator içindeki "isDead" parametresini true olarak ayarlar
        animator.SetBool("isDead", true);

        // SkorManager örneği kullanarak skoru değiştirir
        ScoreManager.instance.ChangeScore(100);

        // Collider2D bileşenini ve bu script'i devre dışı bırakır
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        // Ölüm sesini çağırır ve bir gecikme sonrasında düşmanı yok eder
        Object.Destroy(gameObject, timeDestroy);
    }

    void Die() {
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;

        
        dropItems();

        animator.SetBool("isDead", true);

        ScoreManager.instance.ChangeScore(100);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        Instantiate(sonidoMuerte);
        Object.Destroy(gameObject, timeDestroy);
    }

    void dropItems() {
        int numCoins = Random.Range(1, maxCoins);
        int numHearts = Random.Range(0, maxHearts);
        int numSwords = Random.Range(0, maxSwords);
        int numShields = Random.Range(0, maxShields);

        for (int i = 0; i < numCoins; i++) {
            Instantiate(coins, new Vector3(gameObject.transform.position.x - 1.0f, gameObject.transform.position.y + 2.0f, gameObject.transform.position.z), Quaternion.identity);
        }

        for (int i = 0; i < numHearts; i++) {
            Instantiate(hearts, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2.0f, gameObject.transform.position.z), Quaternion.identity);
        }

        for (int i = 0; i < numSwords; i++) {
            Instantiate(sword, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2.0f, gameObject.transform.position.z), Quaternion.identity);
        }

        for (int i = 0; i < numShields; i++) {
            Instantiate(shield, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2.0f, gameObject.transform.position.z), Quaternion.identity);
        }
    }


}







