using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerBody : MonoBehaviour
{
    /// <summary>Событие. Уведомляет о смерти игрока.</summary>
    [HideInInspector] public UnityEvent PlayerIsDeadEvent = new UnityEvent();

    [Tooltip("Сила прыжка игрока")]
    [SerializeField][Range(10f, 100f)] private float jumpForce = 30;

    /// <summary>Физическое тело объекта игрока</summary>
    private Rigidbody2D playerRb;

    void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Прыжок игрока вверх по нажатию на клавишу
    /// </summary>
    public void Jump()
    {
        if (playerRb != null)
            playerRb.AddForce(jumpForce * Time.fixedDeltaTime * Vector2.up, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Игрок получил урон
    /// </summary>
    /// <param name="source">Источник урона. Может быть использован в дальнейшем при различных рассчетах урона</param>
    public void ReceiveDamage(DangerSource source)
    {
        PlayerIsDeadEvent?.Invoke();
    }


}
