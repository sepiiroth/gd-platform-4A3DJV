using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemis : MonoBehaviour
{
    [SerializeField]private int type; // 0 : invincible/tuable statique, 1 : lent , 2 : rapide 
    [SerializeField]private Vector3 pointDepart;
    [SerializeField]private Vector3 pointArrive;
    [SerializeField]public Animator animations;
    [SerializeField]private bool tour;
    private Vector3 arrivee;


    void Start() {
        this.gameObject.transform.position = pointDepart;
        arrivee = pointArrive;
    }

    void Update() {
        Move(type);
    }

    private void Move(int type) {
        if(type == 1) {
            if(animations.GetBool("Dead") == false) {
                this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, arrivee, 0.8f * Time.deltaTime);
                if(this.gameObject.transform.position == arrivee) {
                    tour = !tour;
                }

                if(tour == false) {
                    animations.SetBool("isRunningRight", true);
                    animations.SetBool("isRunningLeft", false);
                    arrivee = pointArrive;
                } else if(tour == true) {
                    animations.SetBool("isRunningLeft", true);
                    animations.SetBool("isRunningRight", false);
                    arrivee = pointDepart;
                }
            }        
        } else if(type == 2) {
            if(animations.GetBool("Dead") == false) {
                this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, arrivee, 2.0f * Time.deltaTime);
                if(this.gameObject.transform.position == arrivee) {
                    tour = !tour;
                }

                if(tour == false) {
                    animations.SetBool("isRunningRight", true);
                    animations.SetBool("isRunningLeft", false);
                    arrivee = pointArrive;
                } else if(tour == true) {
                    animations.SetBool("isRunningLeft", true);
                    animations.SetBool("isRunningRight", false);
                    arrivee = pointDepart;
                }
            }        
        }
    }
}
