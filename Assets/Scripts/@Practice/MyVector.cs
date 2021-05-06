using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyEngine
{
    // �� ��ġ ���� : Vector�� ����Ͽ� ��ġ�� ǥ���Ѵ�.
    // �� ���� ���� : forward, back, left, right �� ������ ǥ���Ѵ�.
    public struct MyVector
    {
        public float x;
        public float y;
        public float z;

        //         b
        //         *
        //     *   *
        // a*------*  ��   (a �� b)�� �Ÿ� = sqrt(����^2 + ����^2)
        // �Ÿ�       ��  ��Ÿ��� ����.
        public float magnitude { get { return Mathf.Sqrt((x * x) + (y * y) + (z * z)); } }
        // ���� (ũ��: 1).  ��  (���� * �Ÿ�) / (�Ÿ�)
        public MyVector normalized { get { return new MyVector(x / magnitude, y / magnitude, z / magnitude); } }


        public MyVector(float x, float y, float z) { this.x = x; this.y = y; this.z = z; }

        public static MyVector operator +(MyVector a, MyVector b)
        {
            return new MyVector(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static MyVector operator -(MyVector a, MyVector b)
        {
            return new MyVector(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static MyVector operator *(float d, MyVector a)
        {
            return new MyVector(a.x * d, a.y * d, a.z * d);
        }

        public static MyVector operator *(MyVector a, float d)
        {
            return new MyVector(a.x * d, a.y * d, a.z * d);
        }
    }
}
