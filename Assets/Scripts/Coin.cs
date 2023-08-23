using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// �������, ���������� �������
/// </summary>
public class Coin : MonoBehaviour
{
    /// <summary>������ ��������� ������.</summary>
    public int CoinValue => coinValue;

    /// <summary>��������� ������.</summary>
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
