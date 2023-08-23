using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullInspector : MonoBehaviour
{
    /// <summary>���� �������� ��� ������</summary>
    private List<GameObject> pullOfObjects = new List<GameObject>();
    /// <summary>����������� ������� ��� ������</summary>
    private GameObject prefab;

    /// <summary>
    /// ������� ��������� ���� ��������
    /// </summary>
    /// <param name="prefab">������ �������</param>
    /// <param name="count">��������� ����������, ������������ ����� ���� ��������� �������������.</param>
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
    /// ��������� ������� ����������� ������� �� ����
    /// </summary>
    /// <returns>������ �� ���� � �������� ���������</returns>
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
        //���������� �����
        GameObject obj = Instantiate(prefab, transform);
        obj.SetActive(true);
        pullOfObjects.Add(obj);
        return obj;
    }
}
