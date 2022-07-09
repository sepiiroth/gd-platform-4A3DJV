using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private Transform cameraTransform;
    private Animator cameraAnimator;
    [SerializeField]private Animator player;
    private bool rot;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = GetComponent<Transform>();
        cameraAnimator = GetComponent<Animator>();
        rot = false;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            rot = !rot;
            
            cameraAnimator.SetBool("isRotate", rot);
            /*Vector3 pos = cameraTransform.position;
            float newX = -10 * rotValue;
            float newZ = 10 *  rotValue - 10;
            cameraTransform.localPosition = new Vector3(newX, 0, newZ);
            cameraTransform.rotation = Quaternion.Euler(0 , 90 * rotValue, 0);*/
            if(GameManager.Instance().dimension == 0) {
                player.Play("Base Layer.KiwiRotation1", 0, 0.25f);
            } else if(GameManager.Instance().dimension == 1) {
                player.Play("Base Layer.KiwiRotation2", 0, 0.25f);
            }

            GameManager.Instance().ChangeDimension();

        }
    }
}
