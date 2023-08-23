using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Класс ввода от игрока
/// </summary>
public class InputController : MonoBehaviour
{
    /// <summary>Событие. Игра начата по нажатию клавиши.</summary>
    [HideInInspector] public UnityEvent GameWasStartedEvent = new UnityEvent();

    /// <summary>Объект игрока на сцене</summary>
    public PlayerBody Player => player;

    [Tooltip("Объект игрока на сцене")]
    [SerializeField] private PlayerBody player;

    void Awake()
    {
        //Проверка на существование игрока
        if (player == null)
        { 
            Debug.LogError("PlayerBody is missing");
            return;
        }
    }

    void Update()
    {
        //Ожидание нажатия клавиши Space или ЛКМ (старт игры)
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            GameWasStartedEvent?.Invoke(); 
    }

    void FixedUpdate()
    {
        //Ожидание нажатия клавиши Space или ЛКМ (управление персонажем)
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            player.Jump();
    }

}
