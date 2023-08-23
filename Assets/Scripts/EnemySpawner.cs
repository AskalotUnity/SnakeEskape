using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  ласс, занимающийс€ созданием противников
/// </summary>
public class EnemySpawner : Spawner
{
    /// <summary>
    /// —оздание нового противника из пулла в заданной позиции и со случайными параметрами движени€
    /// </summary>
    /// <param name="position">ѕозици€ дл€ спавна</param>
    protected override GameObject Spawn(Vector2 position)
    {
        EnemyMover enemy = base.Spawn(position).GetComponent<EnemyMover>();
        Vector2 direction = Random.Range(0, 2) == 1 ? Vector2.up : Vector2.down;
        float speed = Random.Range(0.5f * averangeSpeed, 2 * averangeSpeed);
        enemy.SetStartingParameters(bottomBorder.position.y + 1, topBorder.position.y - 1, speed, direction, lifeTime);
        return enemy.gameObject;
    }
}
