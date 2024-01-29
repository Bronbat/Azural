using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{

    public int damage = 100;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponentInParent<Stats>().takeTrueDamage(damage);

            if (collision.gameObject.GetComponentInParent<Stats>().health > 0)
            {
                collision.gameObject.GetComponentInParent<PlayerController>().reSpawn();
            }
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Çarpışan nesnenin bir düşman olup olmadığını kontrol eder
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            if (enemy != null)
            {
                // Düşman suya girdiğinde DieInWater metodunu çağırır
                enemy.DieInWater();
            }
        }
    }
}
