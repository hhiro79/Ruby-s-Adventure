using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public ParticleSystem healthEffect;   

    void OnTriggerEnter2D(Collider2D col)
    {
        RubyController controller = col.GetComponent<RubyController>();

        if (controller != null)
        {
            if(controller.health <= controller.maxHealth)
            {
                //todo アイテム取得エフェクト発生
                Instantiate(healthEffect, transform.position, Quaternion.identity);

                controller.ChangeHealth(3);
                Destroy(gameObject);
            }
        }
    }
}
