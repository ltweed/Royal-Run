using System;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 100f;
    const string playerString = "Player";

    private void Update()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerString))
        {
            OnPickup();
            Destroy(gameObject);
        }
    }

    protected abstract void OnPickup();
}
