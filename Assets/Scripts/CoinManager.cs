using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private List<Coin> coinList = new List<Coin>();

    private void Awake()
    {
        var childs = GetComponentsInChildren<Coin>();
        foreach (var child in childs)
        {
            coinList.Add(child);
        }
    }

    public void CollectCoin(Coin coin){
        coinList.Remove(coin);
        coin.HideCoin();
    }

    public Coin FindMinimumDistanceCoin(Vector3 positionPerson)
    {
        Coin coinWithMinDistance = null;
        var distanceResult = Mathf.Infinity;
        foreach (var coin in coinList)
        {
            var distance = Vector3.Distance(positionPerson, coin.transform.position);

            if (distance < distanceResult)
            {
                distanceResult = distance;
                coinWithMinDistance = coin;
            }
        }

        return coinWithMinDistance;
    }
}
