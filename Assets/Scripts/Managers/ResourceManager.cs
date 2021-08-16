using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object
    {
        // GameObject면 Prefab일 확률이 높다.
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

        // Resources.Load의 시작점은
        // Assests.Resources Directory가 된다.
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        // 개선 사항
        // 1. 원본이 이미 존재하면 바로 사용.
        GameObject original = Load<GameObject>($"Prefabs/{path}");
        if (original == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }

        // 2. 혹시 Pooling된 녀석이 있는지 확인.
        if (original.GetComponent<Poolable>() != null)
        {
            return Managers.Pool.Pop(original, parent).gameObject;
        }

        GameObject go = Object.Instantiate(original, parent);
        go.name = original.name; // prefab: 원본, go: 복제본.
        /*int index = go.name.IndexOf("(Clone)");
        if (index > 0)
        {
            go.name = go.name.Substring(0, index);
        }*/

        return go;

    }

    public void Destroy(GameObject go)
    {
        // 개선 사항.
        if (go == null)
            return;

        // Pooling이 필요할 경우 -> Pooling Manager에 위탁.
        Poolable poolable = go.GetComponent<Poolable>();
        if (poolable != null)
        {
            Managers.Pool.Push(poolable);
            return;
        }

        Object.Destroy(go);
    }
}
