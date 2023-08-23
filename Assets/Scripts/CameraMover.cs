using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����, ���������� �� �������� ������, ������������ �������� ������ �� ������
/// </summary>
public class CameraMover : MonoBehaviour
{
    [Tooltip("�������� ��������")]
    [SerializeField] private float speed = 3f;
    [Tooltip("����������� ��������")]
    [SerializeField] private Vector3 direction = Vector3.right;


    //����������� ����� ����������, ��������� ��� ��������������
    private void OnValidate()
    {
        speed = Mathf.Clamp(speed, 0.1f, 20f);
        direction = direction.normalized;
        if (direction == Vector3.zero)
            direction = Vector3.right;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
