using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0), Time.time * 0.05f);        
    }

    public void HideCoin()
    {
        Destroy(gameObject);
    }
}
