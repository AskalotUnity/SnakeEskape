using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������ ��� �������, ���� ���������� ���� �����
/// </summary>
public class CoinMagnet : MonoBehaviour
{
    [Tooltip("������ �������� ����������")]
    [SerializeField] [Range(0.1f, 10f)] private float magnetRadius = 2;
    [Tooltip("�������� ���������� �������")]
    [SerializeField] [Range(0.1f, 10f)] private float coinSpeed = 5;

    /// <summary>���� ��� ����������</summary>
    private CoinCollector coinCollector;
    /// <summary>��������� ���� ������</summary>
    private bool isInitialized;

    /// <summary>
    /// ������� ��������� ����������.
    /// </summary>
    /// <param name="coinCollector">���� ��� ����������</param>
    public void SetStartingParameters(CoinCollector coinCollector)
    {
        this.coinCollector = coinCollector;
        isInitialized = true;
    }

    void Update()
    {
        if (!isInitialized)
            return;

        //���� ���� CoinCollector �����������
        if (Vector2.Distance(transform.position, coinCollector.transform.position) < magnetRadius)
            transform.Translate((coinCollector.transform.position - transform.position).normalized * coinSpeed * Time.deltaTime);
    }
}
