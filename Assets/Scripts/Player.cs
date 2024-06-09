using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;

    [SerializeField]
    private float torqueVelocity;

    private Rigidbody rb;

    [SerializeField]
    private CoinManager coinManager;

    private void Awake()
    { 
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (rb != null)
        {
            var directionForward = Input.GetAxis("Vertical");
            var direction = Input.GetAxis("Horizontal");

            rb.AddTorque(cameraTransform.right * torqueVelocity * directionForward, ForceMode.VelocityChange);
            rb.AddTorque(-cameraTransform.forward * torqueVelocity * direction, ForceMode.VelocityChange);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            coinManager.CollectCoin(coin);
        }
    }
}
