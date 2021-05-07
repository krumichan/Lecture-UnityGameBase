using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest : MonoBehaviour
{
    GameObject prefab;
    GameObject tank;

    void Start()
    {
        tank = Managers.Resource.Instantiate("@Practice/Tank");
        //Managers.Resource.Destroy(tank);
        Destroy(tank, 3.0f);
    }
}
