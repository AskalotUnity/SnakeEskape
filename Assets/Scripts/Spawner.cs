using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// C���������� �������. ������� ������ �� ���������� ����� �������� ����� ������������ ���������� �������.
/// </summary>
public class Spawner : MonoBehaviour
{
    [Tooltip("������, ������� �������")]
    [SerializeField] protected GameObject SpawnPrefab;
    [Tooltip("����� ����� �������� ����� ��������")]
    [SerializeField][Range(1f, 5f)] protected float SpawnTime;
    [Tooltip("������������ ���������� �������� � ����� ������")]
    [SerializeField][Range(1, 5)] protected int SpawnMaxCount;
    [Tooltip("����� ����� �������� �� �������� � ����")]
    [SerializeField][Range(5f, 50f)] protected float lifeTime;
    [Tooltip("������� �������� �������� ��������")]
    [SerializeField][Range(0f, 5f)] protected float averangeSpeed;
    [Tooltip("������ ������� ������")]
    [SerializeField] protected Transform bottomBorder;
    [Tooltip("������� ������� ������")]
    [SerializeField] protected Transform topBorder;

    /// <summary>���� �������� ��� ������</summary>
    protected PullInspector pullInspector;
    /// <summary>������ �� �������� �����������</summary>
    protected float spawnTimer;
    /// <summary>����������� ��������� ������, ����� �������� ������� ����� ���</summary>
    protected Transform player;

    protected virtual void Awake()
    {
        pullInspector = gameObject.AddComponent<PullInspector>();
        pullInspector.CreateStartPull(SpawnPrefab, SpawnMaxCount * 3);
        if (TryGetComponent(out InputController controller) && controller.Player != null)
            player = controller.Player.transform;
        else
        {
            Debug.LogError("Player is missing");
            enabled = false;
        }
    }

    protected void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            //����������� ���������� �������� � ������
            spawnTimer = SpawnTime * Random.Range(0.77f, 1.3f);
            int randCount = Random.Range(1, SpawnMaxCount + 1);
            for (int i = 0; i < randCount; i++)
            {
                //����������� ������� � ��������� ������� ��� ������� ������ ������� � �����
                float xPos = player.position.x + 18f + Random.Range(0, 1f) + i * Random.Range(0.5f, 1f);
                float yPos = bottomBorder.position.y + Random.Range(1, Mathf.Abs(topBorder.position.y - bottomBorder.position.y) - 1);
                Spawn(new Vector2(xPos, yPos));
            }
        }
    }

    /// <summary>
    /// �������� ������ ������� �� ����� � �������� �������
    /// </summary>
    /// <param name="position">������� ��� ������</param>
    protected virtual GameObject Spawn(Vector2 position)
    {
        GameObject newObj = pullInspector.GetObjectFromPull();
        newObj.transform.position = position;
        return newObj;
    }
}