using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;

    [SerializeField] float fireRate = 1f;
    [SerializeField] float shootingForce = 200f;

    Coroutine shootingCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shootingCoroutine = StartCoroutine(ContinuousShooting());
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            StopCoroutine(shootingCoroutine);
        }
    }

    void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, transform.position, transform.parent.rotation) as GameObject;
        bullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * shootingForce);
    }

    IEnumerator ContinuousShooting()
    {
        while(true)
        {
            Shoot();
            yield return new WaitForSeconds(fireRate);
        }
    }
}
