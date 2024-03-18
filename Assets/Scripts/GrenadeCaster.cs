using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeCaster : MonoBehaviour
{
    public float boombCount;
    public Rigidbody grenadeP;
    public Transform grenadecasterTransform;
    public float force;
    public Text text;

    void Start()
    {
        text.text = "Boomb: 10";
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (boombCount > 0)
            {
                var grenade = Instantiate(grenadeP);
                grenade.transform.position = grenadecasterTransform.position;
                grenade.GetComponent<Rigidbody>().AddForce(grenadecasterTransform.forward * force);
                boombCount -= 1;
                NewText();
            }
        }
    }
    private void NewText()
    {
        text.text = "Boomb: " + boombCount.ToString();
    }
}
