using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CameraMover : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    private Rigidbody rigidBodyPlayer;

    private List<Vector3> velocities = new List<Vector3>();
    private const int defaultCountVelocities = 10;

    private void Start()
    {
        if (player != null)
        {
            if (player.gameObject.TryGetComponent(out Rigidbody rb))
            {
                rigidBodyPlayer = rb;
            }
        }

        for (int i = 0; i < defaultCountVelocities; i++)
        {
            velocities.Add(Vector3.zero);
        }
    }

    private void FixedUpdate()
    {
        velocities.Add(rigidBodyPlayer.velocity);
        velocities.RemoveAt(0);
    }

    private void Update()
    {
        transform.position = player.position;

        var sumVelocities = Vector3.zero;
        for (int i = 0; i < defaultCountVelocities; i++)
        {
            sumVelocities += velocities[i];
        }
        
        if (rigidBodyPlayer != null)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, 
                                    Quaternion.LookRotation(sumVelocities), 
                                    Time.deltaTime * 10f);
        }
    }
}
