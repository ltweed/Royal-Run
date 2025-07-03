using System;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float collisionCooldown;

    [SerializeField] private float adjustChangeMoveSpeed = -2f;
    
    const string hitString = "Hit";
    
    float cooldownTimer = 0f;
    
    LevelGenerator levelGenerator;

    private void Start()
    {
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (cooldownTimer <= collisionCooldown) return;
        
        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeed);
        
        animator.SetTrigger(hitString);
        cooldownTimer = 0f;
    }
}
