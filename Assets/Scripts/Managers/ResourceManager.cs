using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object
    {
        // GameObject�� Prefab�� Ȯ���� ����.
        if (typeof(T) == typeof(GameObject))
        {
            string name = path;
            int index = name.LastIndexOf('/');
            if (index >= 0)
            {
                name = name.Substring(index + 1);
            }

            GameObject go = Managers.Pool.getOriginal(name);
            if (go != null)
            {
                return go as T;
            }
        }

        // Resources.Load�� ��������
        // Assests.Resources Directory�� �ȴ�.
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        // ���� ����
        // 1. ������ �̹� �����ϸ� �ٷ� ���.
        GameObject original = Load<GameObject>($"Prefabs/{path}");
        if (original == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }

        // 2. Ȥ�� Pooling�� �༮�� �ִ��� Ȯ��.
        if (original.GetComponent<Poolable>() != null)
        {
            return Managers.Pool.Pop(original, parent).gameObject;
        }

        GameObject go = Object.Instantiate(original, parent);
        go.name = original.name; // prefab: ����, go: ������.
        /*int index = go.name.IndexOf("(Clone)");
        if (index > 0)
        {
            go.name = go.name.Substring(0, index);
        }*/

        return go;

    }

    public void Destroy(GameObject go)
    {
        // ���� ����.
        if (go == null)
            return;

        // Pooling�� �ʿ��� ��� -> Pooling Manager�� ��Ź.
        Poolable poolable = go.GetComponent<Poolable>();
        if (poolable != null)
        {
            Managers.Pool.Push(poolable);
            return;
        }

        Object.Destroy(go);
    }
}
