using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobHealth : MonoBehaviour
{
    public float health = 100;
    public Animator animator;
    public GameObject healing;
    public GameObject spawner;
    public PlayerControl TargerObj;

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            HealingSpawn();
            MobDeath();
        }
        else
        {
            animator.SetTrigger("hit");
        }       
    }

    private void MobDeath()
    {
        TargerObj.AddPointToScore();
        animator.SetTrigger("Death");
        GetComponent<MobAI>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
    }

    private void HealingSpawn()
    {
        if (UnityEngine.Random.Range(0.0f, 10.0f) >= 8.5f)
        {
            Instantiate(healing, spawner.transform.position, spawner.transform.rotation);
        }
    }
}
