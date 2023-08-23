using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ViewUI : MonoBehaviour
{
    [Tooltip("��������� UI. ����� � ���������� ������ ������� ��� ������ ����.")]
    [SerializeField] private TextMeshProUGUI startTextObject;
    [Tooltip("��������� UI. ������� ��������� �����.")]
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
        //������� ����� ������ � �������� ���� (����� ����� ����������� ����� DI)
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
    /// ������ ��������� ����� � ����������
    /// </summary>
    private void HideStartingText()
    {
        startTextObject.gameObject.SetActive(false);
    }

    /// <summary>
    /// �������� �������� �������� �����.
    /// </summary>
    /// <param name="newValue">����� ��������</param>
    private void ChangeCoinsCounter(int newValue)
    {
        coinsCounterTextObject.text = newValue.ToString();
    }

}
