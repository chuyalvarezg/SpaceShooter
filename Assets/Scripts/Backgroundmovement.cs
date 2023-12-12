using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgroundmovement : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed=1f;
    [SerializeField]
    private float movementDistance= 16.5f;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if(transform.position.x > 0 )
        {
            transform.localPosition += scrollSpeed * Vector3.right * Time.deltaTime;
        }
        else
        {
            transform.position = new Vector3(movementDistance, transform.position.y, transform.position.z);
        }
    }
}
