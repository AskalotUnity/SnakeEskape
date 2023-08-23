using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  ласс, отвечающий за движение камеры, симулирующее движение игрока по уровню
/// </summary>
public class CameraMover : MonoBehaviour
{
    [Tooltip("—корость движени€")]
    [SerializeField] private float speed = 3f;
    [Tooltip("Ќаправление движени€")]
    [SerializeField] private Vector3 direction = Vector3.right;


    //ќграничение ввода переменных, доступных дл€ редактировани€
    private void OnValidate()
    {
        speed = Mathf.Clamp(speed, 0.1f, 20f);
        direction = direction.normalized;
        if (direction == Vector3.zero)
            direction = Vector3.right;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
