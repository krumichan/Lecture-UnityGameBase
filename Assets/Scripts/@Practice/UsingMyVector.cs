using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyEngine;

public class UsingMyVector : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;

    void Start()
    {
        MyVector to = new MyVector(10.0f, 0.0f, 0.0f);
        MyVector from = new MyVector(5.0f, 0.0f, 0.0f);

        // (5.0f, 0.0f, 0.0f);
        MyVector direction = to - from;

        // (1.0f, 0.0f, 0.0f);
        direction = direction.normalized;

        // from에서 direction방향으로 _speed만큼 이동.
        MyVector newPosition = from + direction * _speed;

        // 방향 벡터
        // ① 거리 → magnitude
        // ② 방향 → normalized
    }

    void Update()
    {
        
    }
}
