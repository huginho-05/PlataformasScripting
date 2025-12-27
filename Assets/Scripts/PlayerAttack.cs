using System;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerMovement playerMovementScript;
    [SerializeField] private float damageSword;
    [SerializeField] private Animator playerAttackAnimator;
    private float attackTime;
    

    void Start()
    {
        playerMovementScript = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            playerAttackAnimator.SetBool("isAttacking", true);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerAttackAnimator.SetBool("isAttacking", false); 
        }
    }
}
