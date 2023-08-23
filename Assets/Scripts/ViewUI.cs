using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ViewUI : MonoBehaviour
{
    [Tooltip("Компонент UI. Текст с подсказкой нажать клавишу при старте игры.")]
    [SerializeField] private TextMeshProUGUI startTextObject;
    [Tooltip("Компонент UI. Счетчик собранных монет.")]
    [SerializeField] private TextMeshProUGUI coinsCounterTextObject;

    private void Awake()
    {
        if (startTextObject == null || coinsCounterTextObject == null)
        {
            Debug.LogError("UI components are missing");
            enabled = false;
            return;
        }
    }

    private void Start()
    {
        //Попытка найти игрока и менеджер игры (далее можно реализовать через DI)
        if (TryGetComponent(out InputController inputController))
        {
            inputController.GameWasStartedEvent.AddListener(HideStartingText);
            if (inputController.Player != null && inputController.Player.TryGetComponent(out CoinCollector coinCollector))
            {
                coinCollector.CoinsValueChangedEvent.AddListener(ChangeCoinsCounter);
            }
        }
    }

    /// <summary>
    /// Скрыть стартовый текст с подсказкой
    /// </summary>
    private void HideStartingText()
    {
        startTextObject.gameObject.SetActive(false);
    }

    /// <summary>
    /// Изменить значение счетчика монет.
    /// </summary>
    /// <param name="newValue">Новое значение</param>
    private void ChangeCoinsCounter(int newValue)
    {
        coinsCounterTextObject.text = newValue.ToString();
    }

}
