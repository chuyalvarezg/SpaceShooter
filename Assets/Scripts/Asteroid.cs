using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float asteroidSpeed = 5;
    public int aValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-asteroidSpeed * Time.deltaTime, 0, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameBarrier")
        {
            Destroy(this.gameObject);
        }
        else if (other.tag == "Ship")
        {

            other.gameObject.GetComponent<Ship>().takeDamage();
            Destroy(this.gameObject);
        }
    }
}
