using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ����� ����� �� ������
/// </summary>
public class InputController : MonoBehaviour
{
    /// <summary>�������. ���� ������ �� ������� �������.</summary>
    [HideInInspector] public UnityEvent GameWasStartedEvent = new UnityEvent();

    /// <summary>������ ������ �� �����</summary>
    public PlayerBody Player => player;

    [Tooltip("������ ������ �� �����")]
    [SerializeField] private PlayerBody player;

    void Awake()
    {
        //�������� �� ������������� ������
        if (player == null)
        { 
            Debug.LogError("PlayerBody is missing");
            return;
        }
    }

    void Update()
    {
        //�������� ������� ������� Space ��� ��� (����� ����)
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            GameWasStartedEvent?.Invoke(); 
    }

    void FixedUpdate()
    {
        //�������� ������� ������� Space ��� ��� (���������� ����������)
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            player.Jump();
    }

}
