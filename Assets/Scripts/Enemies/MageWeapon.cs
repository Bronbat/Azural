using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageWeapon : MonoBehaviour {

    public GameObject boss;
    public Animator animator;
    public GameObject ballPrefab;
    public GameObject sonido;

    void ShootBall() {
        
        Instantiate(ballPrefab, boss.transform.position, boss.transform.rotation);

        
        Instantiate(sonido);
    }
}
