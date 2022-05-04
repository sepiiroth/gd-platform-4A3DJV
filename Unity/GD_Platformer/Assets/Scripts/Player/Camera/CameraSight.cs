using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSight : MonoBehaviour
{
    private GameObject firstGameObjectOnSight;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        Color color = Color.black;
        if (firstGameObjectOnSight)
        {
            color = firstGameObjectOnSight.GetComponent<Renderer>().material.color;
        }
        
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 11 ))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            if (hit.transform.gameObject.layer.Equals(LayerMask.NameToLayer("Platform")))
            {
                firstGameObjectOnSight = hit.transform.gameObject;
                Debug.Log($"Did Hit {firstGameObjectOnSight.name}");
                firstGameObjectOnSight.GetComponent<Renderer>()
                    .material
                    .color= new Color(color.r,color.g,color.b,0.2f);
            
            }
            
        }
        else
        {
            
            
            if (firstGameObjectOnSight)
            {
                Debug.Log($"Did not Hit {firstGameObjectOnSight.name}");
                firstGameObjectOnSight.GetComponent<Renderer>()
                    .material
                    .color= new Color(color.r,color.g,color.b,1f);
                firstGameObjectOnSight = null;
            }
            
        }
    }
}
