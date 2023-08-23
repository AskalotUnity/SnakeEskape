using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Cтандартный спавнер. Создает группы из случайного числа объектов через определенные промежутки времени.
/// </summary>
public class Spawner : MonoBehaviour
{
    [Tooltip("Объект, который создаем")]
    [SerializeField] protected GameObject SpawnPrefab;
    [Tooltip("Время между спавнами групп объектов")]
    [SerializeField][Range(1f, 5f)] protected float SpawnTime;
    [Tooltip("Максимальное количество объектов в одной группе")]
    [SerializeField][Range(1, 5)] protected int SpawnMaxCount;
    [Tooltip("Время жизни объектов до возврата в пулл")]
    [SerializeField][Range(5f, 50f)] protected float lifeTime;
    [Tooltip("Средняя скорость движения объектов")]
    [SerializeField][Range(0f, 5f)] protected float averangeSpeed;
    [Tooltip("Нижняя граница спавна")]
    [SerializeField] protected Transform bottomBorder;
    [Tooltip("Верхняя граница спавна")]
    [SerializeField] protected Transform topBorder;

    /// <summary>Пулл объектов для спавна</summary>
    protected PullInspector pullInspector;
    /// <summary>Отсчет до создания противников</summary>
    protected float spawnTimer;
    /// <summary>Отслеживаем положение игрока, чтобы спавнить объекты перед ним</summary>
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
            //Определение количества объектов в группе
            spawnTimer = SpawnTime * Random.Range(0.77f, 1.3f);
            int randCount = Random.Range(1, SpawnMaxCount + 1);
            for (int i = 0; i < randCount; i++)
            {
                //Определение позиции с небольшим сдвигом для каждого нового объекта и спавн
                float xPos = player.position.x + 18f + Random.Range(0, 1f) + i * Random.Range(0.5f, 1f);
                float yPos = bottomBorder.position.y + Random.Range(1, Mathf.Abs(topBorder.position.y - bottomBorder.position.y) - 1);
                Spawn(new Vector2(xPos, yPos));
            }
        }
    }

    /// <summary>
    /// Создание нового объекта из пулла в заданной позиции
    /// </summary>
    /// <param name="position">Позиция для спавна</param>
    protected virtual GameObject Spawn(Vector2 position)
    {
        GameObject newObj = pullInspector.GetObjectFromPull();
        newObj.transform.position = position;
        return newObj;
    }
}