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
    [SerializeField] public Animator animation;
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
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            animation.SetBool("isRunningRight", true);
            animation1.SetBool("isRunningRight", true);
        } else {
            animation.SetBool("isRunningRight", false);
            animation1.SetBool("isRunningRight", false);
        }

        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q)) {
            animation.SetBool("isRunningLeft", true);
            animation1.SetBool("isRunningLeft", true);
        } else {
            animation.SetBool("isRunningLeft", false);
            animation1.SetBool("isRunningLeft", false);
        }

        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Z)) {
            animation.SetBool("isJumpingRight", true);
            animation1.SetBool("isJumpingRight", true);
        } else {
            animation.SetBool("isJumpingRight", false);
            animation1.SetBool("isJumpingRight", false);
        }
        Move();
        Jump();

    }

    void Move()
    {
        float xAxis = Input.GetAxis("Horizontal");
        
        if (xAxis != 0)
        {
            Vector3 movement = new Vector3(xAxis, 0, 0);
            if (GameManager.Instance().GetDimension() == 1)
            {
                movement = new Vector3(0, 0, -xAxis);
            }
            playerTransform.position += movement * Time.deltaTime * playerSpeed;
        }
        
    }

    void Jump()
    {
        if (isJumping)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Z))
        {
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
    }
}
