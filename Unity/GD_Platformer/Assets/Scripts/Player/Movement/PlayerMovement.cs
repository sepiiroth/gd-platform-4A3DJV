using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform playerTransform;
    private Rigidbody playerRigidbody;

    private bool isJumping;

    [SerializeField] private float playerSpeed = 5f;

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
            playerRigidbody.AddForce(Vector3.up * 6, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("Platform")))
        {
            isJumping = false;
        }
    }
}
