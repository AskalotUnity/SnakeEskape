using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : Spawner
{
    /// <summary>����������� ���������� ������</summary>
    private CoinCollector coinCollector;

    protected override void Awake()
    {
        base.Awake();
        coinCollector = player.GetComponent<CoinCollector>();
    }

    /// <summary>
    /// �������� ����� �������
    /// </summary>
    /// <param name="position">������� ��� ������</param>
    protected override GameObject Spawn(Vector2 position)
    {
        CoinMagnet coinMagnet = base.Spawn(position).GetComponent<CoinMagnet>();
        coinMagnet.SetStartingParameters(coinCollector);
        return coinMagnet.gameObject;
    }
}
