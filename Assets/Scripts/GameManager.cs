using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(InputController))]

/// <summary>
/// Компонент, отвечающий за глобальные игровые события
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>Игра была начата?</summary>
    private bool gameWasStarted = false;

    private void Awake()
    {
        //ограничение фпс в игре
        Application.targetFrameRate = 50;
        //пауза при старте уровня (снимается нажатием любой клавиши)
        Time.timeScale = 0f;
    }

    void Start()
    {
        //подписка на начало игры
        GetComponent<InputController>().GameWasStartedEvent.AddListener(PlayGame);
        //подписка на смерть игрока
        if (GetComponent<InputController>().Player != null) 
            GetComponent<InputController>().Player.PlayerIsDeadEvent.AddListener(GameOver);
    }

    /// <summary>
    /// Игра начата по нажатию клавиши. Снять игру с паузы.
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
    /// Игрок мертв. Игра проиграна. Рестарт уровня.
    /// </summary>
    private void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
