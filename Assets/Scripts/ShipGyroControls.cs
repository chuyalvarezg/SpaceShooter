using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipGyroControls : MonoBehaviour,Ship
{
    private bool shooting,doubleAmmo;
    [SerializeField]
    private float speed = 10;
    [SerializeField]
    private GameObject ammo;
    [SerializeField]
    private GameObject gameController;
    

    // Start is called before the first frame update
    void Start()
    {

    }

// Update is called once per frame
    void Update()
    {

        if (Input.acceleration.x > 0.2 && transform.position.z>-4)
        {
            transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
        }
        else if (Input.acceleration.x < -0.2 && transform.position.z < 4)
        {
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }
        if (Input.GetMouseButton(0))
        {
            if (!shooting)
            {
                StartCoroutine(shoot());
            }
        }

    }

    public void takeDamage()
    {
        gameController.GetComponent<GameController>().loseLife();
    }

    public void addPower()
    {
        StartCoroutine(doubleFire());
    }

    IEnumerator shoot()
    {
        shooting = true;
        if (doubleAmmo)
        {
            Instantiate(ammo, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), Quaternion.identity);
            Instantiate(ammo, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Quaternion.identity);
        }
        else
        {
            Instantiate(ammo, transform.position, Quaternion.identity);
        }
        yield return new WaitForSeconds(0.8f);
        shooting = false;
    }

    IEnumerator doubleFire()
    {
        doubleAmmo = true;
        yield return new WaitForSeconds(7f);
        doubleAmmo = false;
    }
}
