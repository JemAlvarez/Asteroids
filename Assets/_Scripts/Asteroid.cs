using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] float damage = 10f;
    [SerializeField] float asteroidSpeed = 100f;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce((new Vector3(0, 0, 0) - transform.position) * asteroidSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            GetComponent<Health>().TakeDamage(collision.gameObject.GetComponent<Bullet>().GetDamage());
            Destroy(collision.gameObject);
        }
    }
}
