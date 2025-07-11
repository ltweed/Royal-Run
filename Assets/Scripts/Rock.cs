using System;
using Unity.Cinemachine;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] ParticleSystem collisionParticleSystem;
    [SerializeField] AudioSource boulderSmashAudioSource;
    [SerializeField] float shakeModifier = 10f;
    [SerializeField] float collisionCooldown = 1f;
    
    CinemachineImpulseSource cinemachineImpulseSource;
    private float collisionTimer = 1f;
    
    private void Awake()
    {
        cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
        
    }

    private void Update()
    {
        collisionTimer += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (collisionTimer <= collisionCooldown) return;
        FireImpulse();
        CollisionFX(other);
        collisionTimer = 0f;
    }

    private void FireImpulse()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        float shakeIntensity = 1f / distance * shakeModifier;
        shakeIntensity = Mathf.Min(shakeIntensity, 1f);
        
        cinemachineImpulseSource.GenerateImpulse(shakeIntensity);
    }

    void CollisionFX(Collision other)
    {
        ContactPoint contact = other.contacts[0];
        collisionParticleSystem.transform.position = contact.point;
        collisionParticleSystem.Play();
        boulderSmashAudioSource.Play();
    }
}
