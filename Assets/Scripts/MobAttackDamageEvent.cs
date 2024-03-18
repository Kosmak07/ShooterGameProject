using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAttackDamageEvent : MonoBehaviour
{
    public MobAI mobAI;
    public void AttackDamagaEvent()
    {
        mobAI.AttackDamage();
    }

}
