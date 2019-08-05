using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigibody2d;

    void Awake()
    {
        rigibody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(transform.position.magnitude > 50.0f)
        {
            Destroy(gameObject);
        }
    }

    public void Launch(Vector2 direction, float force)
    {
        rigibody2d.AddForce(direction * force);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        EnemyController e =
            col.collider.GetComponent<EnemyController>();

        if (e != null)
        {
            e.Fix();
        }

        Destroy(gameObject);
    }
}
