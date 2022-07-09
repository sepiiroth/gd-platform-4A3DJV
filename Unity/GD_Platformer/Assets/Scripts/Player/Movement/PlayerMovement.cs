using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform playerTransform;
    private Rigidbody playerRigidbody;

    private bool isJumping;

    [SerializeField] public float playerSpeed = 5f;
    [SerializeField] public float playerStrength = 6f;
    [SerializeField] public Animator animations;
    [SerializeField] public Animator animation1;
    [SerializeField] public GameObject[] watermelon;
    public bool WT1 = false;
    public bool WT2 = false;
    public bool WT3 = false;


    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<Transform>();
        playerRigidbody = GetComponent<Rigidbody>();
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(GameManager.Instance().jump)) {
            animations.SetBool("isJumpingRight", true);
            animation1.SetBool("isJumpingRight", true);
        } else {
            animations.SetBool("isJumpingRight", false);
            animation1.SetBool("isJumpingRight", false);
        }
        Move();
        Jump();

    }

    void Move() {
        if(Input.GetKey(GameManager.Instance().right) && GameManager.Instance().onPause == false) {
            animations.SetBool("isRunningRight", true);
            animation1.SetBool("isRunningRight", true);
            Vector3 movement = new Vector3(1, 0, 0);
            if (GameManager.Instance().GetDimension() == 1)
            {
                movement = new Vector3(0, 0, -1);
            }
            playerTransform.position += movement * Time.deltaTime * playerSpeed;
        } else {
            animations.SetBool("isRunningRight", false);
            animation1.SetBool("isRunningRight", false);
        }

        if(Input.GetKey(GameManager.Instance().left) && GameManager.Instance().onPause == false) {
            animations.SetBool("isRunningLeft", true);
            animation1.SetBool("isRunningLeft", true);
            Vector3 movement = new Vector3(1, 0, 0);
            if (GameManager.Instance().GetDimension() == 1)
            {
                movement = new Vector3(0, 0, -1);
            }
            playerTransform.position -= movement * Time.deltaTime * playerSpeed;
        } else {
            animations.SetBool("isRunningLeft", false);
            animation1.SetBool("isRunningLeft", false);
        } 
    }

    void Jump()
    {
        if (isJumping)
        {
            return;
        }
        if (Input.GetKey(GameManager.Instance().jump) && GameManager.Instance().onPause == false) {
            isJumping = true;
            playerRigidbody.AddForce(Vector3.up * playerStrength, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("Platform")))
        {
            isJumping = false;
            playerStrength = 6;
        }
    }

    void OnTriggerStay(Collider target) {
        if(target.tag == "Spring") {
            var anim = target.gameObject.GetComponent<Animator>();
            playerStrength = 13;
            if(isJumping) {
                if(anim != null) {
                    anim.Play("Base Layer.Springboard", 0, 0.25f);
                }
            }
        }

        if(target.tag == "Portal") {
            var portal = target.gameObject.GetComponent<Portal>();
            if(isJumping) {
                this.gameObject.transform.position = portal.PortalToGo;
            }
        }

        if(target.tag == "WT1") {
            target.gameObject.SetActive(false);
            watermelon[0].SetActive(true);
            this.WT1 = true;
        }

        if(target.tag == "WT2") {
            target.gameObject.SetActive(false);
            watermelon[1].SetActive(true);
            this.WT2 = true;
        }

        if(target.tag == "WT3") {
            target.gameObject.SetActive(false);
            watermelon[2].SetActive(true);
            this.WT3 = true;
        }
        if(target.tag == "Ennemi") {
            playerTransform.transform.position = GameManager.Instance().spawn;
        }

        if(target.tag == "HeadEnnemi") {
            var anim = target.gameObject.transform.parent.gameObject.GetComponent<Animator>();
            anim.SetBool("Dead", true);
            target.gameObject.transform.parent.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    void OnTriggerExit(Collider target) {
        if(target.tag == "Spring") {
            playerStrength = 6;
        }
    }
}
