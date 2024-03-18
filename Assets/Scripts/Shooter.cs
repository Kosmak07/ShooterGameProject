using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooter : MonoBehaviour
{
    public Ammo ammpPrefab;
    public float nowAmmoInMagazine;
    public float allAmmoInMagazine;
    public Text text;

    void Start()
    {
        text.text = "Ammo: 30/270";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (nowAmmoInMagazine > 0)
            {
                Instantiate(ammpPrefab, transform.position, transform.rotation);
                nowAmmoInMagazine -= 1;
                NewTime();
            }
        }

        if (Input.GetKey(KeyCode.R))
        {
            if (nowAmmoInMagazine != 30)
            {
                if (allAmmoInMagazine > 30)
                {
                    allAmmoInMagazine -= 30;
                    nowAmmoInMagazine = 30;
                }
                else if (allAmmoInMagazine != 0)
                {
                    nowAmmoInMagazine = allAmmoInMagazine;
                    allAmmoInMagazine = 0;
                }
            }
            NewTime();
        }
    }
    private void NewTime()
    {
        text.text = "Ammo: " + nowAmmoInMagazine.ToString() + "/" + allAmmoInMagazine.ToString();
    }
}
