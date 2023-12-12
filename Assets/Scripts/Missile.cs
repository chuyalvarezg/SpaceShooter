using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed = 10;
    private int asteroidValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(bulletSpeed*Time.deltaTime,0,0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameBarrier")
        {
            Destroy(this.gameObject);
        }
        else if(other.tag== "Asteroid")
        {
            asteroidValue = other.gameObject.GetComponent<Asteroid>().aValue;
            Destroy(other.gameObject);
            PlayerPrefs.SetFloat("Score", PlayerPrefs.GetFloat("Score") + asteroidValue);
            Destroy(this.gameObject);

        }
       
    }
}
