using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float value = 100;
    public RectTransform valueRectTransform;
    public GameObject gameplayUI;
    public GameObject gameOverScreen;
    public GameObject Gun;
    public Animator animator;

    public void DealDamage(float damage)
    {
        value -= damage;
        if (value <= 0)
        {
            gameplayUI.SetActive(false);
            gameOverScreen.SetActive(true);
            GetComponent<PlayerControl>().enabled = false;
            Gun.GetComponent<Shooter>().enabled = false;
            GetComponent<CameraRotation>().enabled = false;
            GetComponent<GrenadeCaster>().enabled = false;
            animator.SetTrigger("death");
        }

        DrawHealthBar();
    }

    void Start()
    {
        DrawHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddHealth(float amout)
    {
        value += amout;
        value = Mathf.Clamp(value, 0, 100);
        DrawHealthBar();
    }

    private void DrawHealthBar()
    {
        valueRectTransform.anchorMax = new Vector2(value / 100, 1);
    }
}
