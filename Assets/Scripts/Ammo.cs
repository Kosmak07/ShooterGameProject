using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float speed;
    public float damage;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        MoveFixedUpdate();
    }

    private void MoveFixedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        DamageEnemy(collision);
        Destroy(gameObject);
    } 

    private void DamageEnemy(Collision collision)
    {
        var mobHealth = collision.gameObject.GetComponent<MobHealth>();
        if (mobHealth != null)
        {
            mobHealth.DealDamage(damage);
        }
    }
}

