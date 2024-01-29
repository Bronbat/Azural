using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour {

    public Transform bow;
    public Animator animator;
    public GameObject arrowPrefab;
    public GameObject sonido;

    
    void Update() {

        if (Input.GetKeyDown(KeyCode.C) && GetComponentInParent<Stats>().power == 4) {
            GetComponentInParent<Stats>().power = 0;
            Shoot();
        }
        
    }

    void Shoot() {
       
        animator.SetTrigger("attackBow");
    }

    void ShootArrow() {
        
        Instantiate(arrowPrefab, bow.position, bow.rotation);


        Instantiate(sonido);
    }

    public void AttackButton() {
        if (GetComponentInParent<Stats>().power == 4) {
            GetComponentInParent<Stats>().power = 0;
            Shoot();
        }
    }
}
