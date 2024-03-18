using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float damage;
    public float speed;
    public float maxsize;

    void Start()
    {
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += Vector3.one * Time.deltaTime * speed;
        if (transform.localScale.x > maxsize)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var playerhealth = other.GetComponent<PlayerHealth>();
        if (playerhealth != null)
        {
            playerhealth.DealDamage(damage);
        }

        var mobhealth = other.GetComponent<MobHealth>();
        if (mobhealth != null)
        {
            mobhealth.DealDamage(damage);
        }
    }
}
