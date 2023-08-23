using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [Tooltip("������� ����� ����� ������ ����������� ��������")]
    [SerializeField] private float averageReverseTime = 2f;

    /// <summary>������� ��������. ��� �� ���������� ������ ������������� ���������������</summary>
    private float minPosition, maxPosition;
    /// <summary>�������� ��������</summary>
    private float speed;
    /// <summary>����������� ��������</summary>
    private Vector2 direction;
    /// <summary>������ ������� �� ��������� ����������� ��������</summary>
    private float reverseTimer;
    /// <summary>����� �����</summary>
    private float lifeTime;
    /// <summary>��������� �������� ���� ������</summary>
    private bool isInitialized;



    /// <summary>
    /// ������ ��������� ��������� ��������
    /// </summary>
    /// <param name="minPosition">������ ������� ��������</param>
    /// <param name="maxPosition">������� ������� ��������</param>
    /// <param name="speed">��������</param>
    /// <param name="direction">��������� ����������� ��������</param>
    public void SetStartingParameters(float minPosition, float maxPosition, float speed, Vector2 direction, float lifeTime)
    {
        this.minPosition = minPosition;
        this.maxPosition = maxPosition;
        this.speed = Mathf.Clamp(speed, 0, 10);
        this.direction = direction.normalized;
        this.lifeTime = lifeTime;
        reverseTimer = RandomizeTime();
        isInitialized = true;
    }

    void Update()
    {
        if (!isInitialized)
            return;

        //������� ��������
        transform.Translate(direction * speed * Time.deltaTime);
        if (transform.position.y < minPosition || transform.position.y > maxPosition)
            reverseTimer = -1;

        //������������ ��������� ����������� �������� 
        reverseTimer -= Time.deltaTime;
        if (reverseTimer < 0)
        {
            ReverseMovement();
        }

        lifeTime -= Time.deltaTime;
        //���������� �������
        if (lifeTime < 0)
        {
            isInitialized = false;
            gameObject.SetActive(false); 
        }
    }

    /// <summary>
    /// �������� ����������� ��������
    /// </summary>
    private void ReverseMovement()
    {
        direction = -direction;
        reverseTimer = RandomizeTime();
    }

    /// <summary>
    /// ������ ��������� ����� ��� �������
    /// </summary>
    private float RandomizeTime()
    {
        return Random.Range(averageReverseTime * 0.5f, averageReverseTime * 2f);
    }

}
