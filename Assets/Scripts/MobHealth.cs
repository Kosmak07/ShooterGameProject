using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobHealth : MonoBehaviour
{
    public float health = 10;
    public Animator animator;
    public GameObject healing;
    public GameObject spawner;

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            MobDeath();
        }
        else
        {
            animator.SetTrigger("hit");
        }       
    }

    private void MobDeath()
    {
        animator.SetTrigger("Death");
        Instantiate(healing, spawner.transform.position, spawner.transform.rotation);
        GetComponent<MobAI>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        
    }
}
