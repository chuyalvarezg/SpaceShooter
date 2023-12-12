using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-2f * Time.deltaTime, 0, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ship")
        {

            other.gameObject.GetComponent<Ship>().addPower();
            Destroy(this.gameObject);
        }
    }
}
