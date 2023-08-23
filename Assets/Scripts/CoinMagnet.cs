using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Магнит для монетки, если неподалеку есть игрок
/// </summary>
public class CoinMagnet : MonoBehaviour
{
    [Tooltip("Радиус действия магнетизма")]
    [SerializeField] [Range(0.1f, 10f)] private float magnetRadius = 2;
    [Tooltip("Скорость притяжения монетки")]
    [SerializeField] [Range(0.1f, 10f)] private float coinSpeed = 5;

    /// <summary>Цель для притяжения</summary>
    private CoinCollector coinCollector;
    /// <summary>Параметры были заданы</summary>
    private bool isInitialized;

    /// <summary>
    /// Задание стартовых параметров.
    /// </summary>
    /// <param name="coinCollector">Цель для притяжения</param>
    public void SetStartingParameters(CoinCollector coinCollector)
    {
        this.coinCollector = coinCollector;
        isInitialized = true;
    }

    void Update()
    {
        if (!isInitialized)
            return;

        //Ждем пока CoinCollector приблизится
        if (Vector2.Distance(transform.position, coinCollector.transform.position) < magnetRadius)
            transform.Translate((coinCollector.transform.position - transform.position).normalized * coinSpeed * Time.deltaTime);
    }
}
