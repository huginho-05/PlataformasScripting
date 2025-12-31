using System;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float damageSword;
    [SerializeField] private Animator playerAttackAnimator;
    private float attackAnimationTime = 0.0f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            playerAttackAnimator.SetBool("isAttacking", true);
            attackAnimationTime = Time.deltaTime;
            
            //El jugador no puede atacar mas mientras ataca
            return;
        }
        if (Time.time - attackAnimationTime >= 0.9f)
        {
            playerAttackAnimator.SetBool("isAttacking", false); 
        }
    }
}
