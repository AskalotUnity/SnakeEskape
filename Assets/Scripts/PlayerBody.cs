using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerBody : MonoBehaviour
{
    /// <summary>�������. ���������� � ������ ������.</summary>
    [HideInInspector] public UnityEvent PlayerIsDeadEvent = new UnityEvent();

    [Tooltip("���� ������ ������")]
    [SerializeField][Range(10f, 100f)] private float jumpForce = 30;

    /// <summary>���������� ���� ������� ������</summary>
    private Rigidbody2D playerRb;

    void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// ������ ������ ����� �� ������� �� �������
    /// </summary>
    public void Jump()
    {
        if (playerRb != null)
            playerRb.AddForce(jumpForce * Time.fixedDeltaTime * Vector2.up, ForceMode2D.Impulse);
    }

    /// <summary>
    /// ����� ������� ����
    /// </summary>
    /// <param name="source">�������� �����. ����� ���� ����������� � ���������� ��� ��������� ��������� �����</param>
    public void ReceiveDamage(DangerSource source)
    {
        PlayerIsDeadEvent?.Invoke();
    }


}
