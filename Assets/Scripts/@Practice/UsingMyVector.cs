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

        // from���� direction�������� _speed��ŭ �̵�.
        MyVector newPosition = from + direction * _speed;

        // ���� ����
        // �� �Ÿ� �� magnitude
        // �� ���� �� normalized
    }

    void Update()
    {
        
    }
}
