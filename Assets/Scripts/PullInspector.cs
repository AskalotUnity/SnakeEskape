using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullInspector : MonoBehaviour
{
    /// <summary>Пулл объектов для спавна</summary>
    private List<GameObject> pullOfObjects = new List<GameObject>();
    /// <summary>Запоминание префаба для спавна</summary>
    private GameObject prefab;

    /// <summary>
    /// Создать стартовый пулл объектов
    /// </summary>
    /// <param name="prefab">Префаб объекта</param>
    /// <param name="count">Стартовое количество, впоследствии может быть расширено автоматически.</param>
    public void CreateStartPull(GameObject prefab, int count)
    {
        this.prefab = prefab;
        for (int i = 0; i < count; i++)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.SetActive(false);
            pullOfObjects.Add(obj); 
        }
    }

    /// <summary>
    /// Получение первого неактивного объекта из пула
    /// </summary>
    /// <returns>Объект из пула в активном состоянии</returns>
    public GameObject GetObjectFromPull()
    {
        foreach (GameObject go in pullOfObjects)
        {
            if (go.activeSelf == false)
            { 
                go.SetActive(true);
                return go;
            }
        }
        //Расширение пулла
        GameObject obj = Instantiate(prefab, transform);
        obj.SetActive(true);
        pullOfObjects.Add(obj);
        return obj;
    }
}
