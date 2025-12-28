using System;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerMovement playerMovementScript;
    [SerializeField] private float damageSword;
    [SerializeField] private Animator playerAttackAnimator;
    private float attackTime;
    private float attackAnimationTime = 0.0f;

    void Start()
    {
        playerMovementScript = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            playerAttackAnimator.SetBool("isAttacking", true);
            attackAnimationTime = Time.time;
            
            //El jugador no puede atacar mas mientras ataca
            return;
        }
        if (Time.time - attackAnimationTime >= 0.26f)
        {
            playerAttackAnimator.SetBool("isAttacking", false); 
        }
    }
}
