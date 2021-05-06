using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyEngine
{
    // ① 위치 벡터 : Vector를 사용하여 위치를 표현한다.
    // ② 방향 벡터 : forward, back, left, right 등 방향을 표현한다.
    public struct MyVector
    {
        public float x;
        public float y;
        public float z;

        //         b
        //         *
        //     *   *
        // a*------*  ⇒   (a ↔ b)의 거리 = sqrt(가로^2 + 세로^2)
        // 거리       ⇒  피타고라스 정리.
        public float magnitude { get { return Mathf.Sqrt((x * x) + (y * y) + (z * z)); } }
        // 방향 (크기: 1).  ⇒  (방향 * 거리) / (거리)
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
