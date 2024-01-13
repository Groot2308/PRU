using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bullet;
    public Transform firePos;
    public float TimeBtwFire = 0.2f;
    public float bulletForce;

    private float timeBtwFire; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateGun();
        timeBtwFire -= Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            FireBullet(); 
        }
    }

     void RotateGun()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotation;
    }
    void FireBullet()
    {
        timeBtwFire = TimeBtwFire; 
        GameObject bulletTmp = Instantiate(bullet, firePos.position, Quaternion.identity);
        
        Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
    
    }
}
