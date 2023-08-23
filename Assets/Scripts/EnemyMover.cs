using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [Tooltip("Среднее время между сменой направления движения")]
    [SerializeField] private float averageReverseTime = 2f;

    /// <summary>Границы движения. При их достижении объект принудительно разворачивается</summary>
    private float minPosition, maxPosition;
    /// <summary>Скорость движения</summary>
    private float speed;
    /// <summary>Направление движения</summary>
    private Vector2 direction;
    /// <summary>Отсчет времени до изменения направления движения</summary>
    private float reverseTimer;
    /// <summary>Время жизни</summary>
    private float lifeTime;
    /// <summary>Параметры движения были заданы</summary>
    private bool isInitialized;



    /// <summary>
    /// Задать стартовые параметры движения
    /// </summary>
    /// <param name="minPosition">Нижняя граница движения</param>
    /// <param name="maxPosition">Верхняя граница движения</param>
    /// <param name="speed">Скорость</param>
    /// <param name="direction">Начальное направление движения</param>
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

        //Обычное движение
        transform.Translate(direction * speed * Time.deltaTime);
        if (transform.position.y < minPosition || transform.position.y > maxPosition)
            reverseTimer = -1;

        //Отслеживание изменения направления движения 
        reverseTimer -= Time.deltaTime;
        if (reverseTimer < 0)
        {
            ReverseMovement();
        }

        lifeTime -= Time.deltaTime;
        //отключение объекта
        if (lifeTime < 0)
        {
            isInitialized = false;
            gameObject.SetActive(false); 
        }
    }

    /// <summary>
    /// Изменить направление движения
    /// </summary>
    private void ReverseMovement()
    {
        direction = -direction;
        reverseTimer = RandomizeTime();
    }

    /// <summary>
    /// Задать случайное время для таймера
    /// </summary>
    private float RandomizeTime()
    {
        return Random.Range(averageReverseTime * 0.5f, averageReverseTime * 2f);
    }

}
