using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private CoinManager coinManager;

    [SerializeField]
    private Coin minDistanceCoin;

    private const float lerpVelocity = 10f;

    private const float protrusionArrowY = 0.759f;

    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y + protrusionArrowY, player.position.z);
        
        minDistanceCoin = coinManager.FindMinimumDistanceCoin(player.transform.position);
        var coinPosition = minDistanceCoin.transform.position;
        var distanceVector = coinPosition - player.transform.position;
        var distanceVectorWithoutY = new Vector3(distanceVector.x, 0, distanceVector.z);
        var orientation = Quaternion.LookRotation(distanceVectorWithoutY);

        transform.rotation = Quaternion.Lerp(transform.rotation, orientation, Time.deltaTime * lerpVelocity);
    }
}
