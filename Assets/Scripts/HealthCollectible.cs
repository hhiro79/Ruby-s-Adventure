using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        RubyController controller = col.GetComponent<RubyController>();

        if (controller != null)
        {
            if(controller.health <= controller.maxHealth)
            {
                controller.ChangeHealth(3);
                Destroy(gameObject);
            }
        }
    }
}
