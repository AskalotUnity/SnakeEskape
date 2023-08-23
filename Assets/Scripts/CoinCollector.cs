using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ���������, ���������� �� ���� �������. ������ ������������� � ������.
/// </summary>
public class CoinCollector : MonoBehaviour
{
    /// <summary>���������� ����� ����������</summary>
    [HideInInspector] public UnityEvent<int> CoinsValueChangedEvent = new UnityEvent<int>();

    /// <summary>������ ���������� ����������� �����</summary>
    public int GetCoinsCount => coinsCount;

    /// <summary>���������� ��������� �����</summary>
    private int coinsCount;

    /// <summary>
    /// �������� �������.
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
