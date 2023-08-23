using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Монетка, собираемая игроком
/// </summary>
public class Coin : MonoBehaviour
{
    /// <summary>Узнать стоимость монеты.</summary>
    public int CoinValue => coinValue;

    /// <summary>Стоимость монеты.</summary>
    private int coinValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out CoinCollector coinCollector))
        {
            coinCollector.AddNewCoin(this);
            gameObject.SetActive(false);
        }
    }
}
