using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Компонент, отвечающий за сбор монеток. Обычно прикрепляется к игроку.
/// </summary>
public class CoinCollector : MonoBehaviour
{
    /// <summary>Количество монет изменилось</summary>
    [HideInInspector] public UnityEvent<int> CoinsValueChangedEvent = new UnityEvent<int>();

    /// <summary>Узнать количество накопленных монет</summary>
    public int GetCoinsCount => coinsCount;

    /// <summary>Количество собранных монет</summary>
    private int coinsCount;

    /// <summary>
    /// Получить монетку.
    /// </summary>
    /// <param name="coin"></param>
    public void AddNewCoin(Coin coin)
    {
        if (coin != null && coin.CoinValue > 0)
        {
            coinsCount += coin.CoinValue;
            CoinsValueChangedEvent?.Invoke(coinsCount);
        }
    }
}
