using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(InputController))]

/// <summary>
/// ���������, ���������� �� ���������� ������� �������
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>���� ���� ������?</summary>
    private bool gameWasStarted = false;

    private void Awake()
    {
        //����������� ��� � ����
        Application.targetFrameRate = 50;
        //����� ��� ������ ������ (��������� �������� ����� �������)
        Time.timeScale = 0f;
    }

    void Start()
    {
        //�������� �� ������ ����
        GetComponent<InputController>().GameWasStartedEvent.AddListener(PlayGame);
        //�������� �� ������ ������
        if (GetComponent<InputController>().Player != null) 
            GetComponent<InputController>().Player.PlayerIsDeadEvent.AddListener(GameOver);
    }

    /// <summary>
    /// ���� ������ �� ������� �������. ����� ���� � �����.
    /// </summary>
    private void PlayGame()
    {
        if (gameWasStarted == false)
        {
            gameWasStarted = true;
            Time.timeScale = 1f;
            GetComponent<InputController>().GameWasStartedEvent.RemoveListener(PlayGame);
        }
    }

    /// <summary>
    /// ����� �����. ���� ���������. ������� ������.
    /// </summary>
    private void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
