using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCoroutine : MonoBehaviour
{
    class CoroutineTest : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
        }
    }

    class IdTest
    {
        public int id;
    }

    class CoroutineTestWithId : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new IdTest() { id = 1 };
            yield return new IdTest() { id = 2 };
            yield return new IdTest() { id = 3 };
            yield return new IdTest() { id = 4 };
        }
    }

    // Coroutine.
    // 1. 함수의 상태저장/복원 가능.
    //  → 엄청 오래 걸리는 작업을 잠시 끊을 경우.
    //  → 원하는 타이밍에 함수를 잠시 Stop/Start 하는 경우.
    // 2. return → 원하는 타입으로 반환 가능 ( class도 가능 )
    // 즉, Coroutine은 시간 관리에 매우 강력하다.
    void GenerateItem()
    {
        // 1. 아이템 생성.
        // 2. DB 저장.

        // 이 중간 과정에서,
        // DB에 저장하기 전에 아래의 Logic을 실행할 경우,
        // 원치않는 오류가 발생할 수 있다.
        // 즉, DB 저장 성공 요청을 받은 후 Logic을 실행하도록 하게 한다.
        // → Coroutine의 yield 계열을 사용하여 일시 정지.

        // 3. Logic.
    }

    float deltaTime = 0;
    void ExplodeAfter4Seconds()
    {
        // 매 Frame마다 time을 더하고 확인해야 한다.
        // 즉, cost가 발생.
        deltaTime += Time.deltaTime;
        if (deltaTime >= 4)
        {
            // Logic.
        }
    }

    Coroutine coExplode;

    // ExplodeAfter3Seconds를 Coroutine으로 효율적으로 만들 수 있다.
    IEnumerator ExplodeAfterSeconds(float seconds)
    {
        Debug.Log("Explode Enter");
        yield return new WaitForSeconds(seconds);
        Debug.Log("Explode Execute!!!");
        coExplode = null;
    }

    IEnumerator CoStopExplode(float seconds)
    {
        Debug.Log("Stop Enter");
        yield return new WaitForSeconds(seconds);
        Debug.Log("Stop Execute!!!");
        if (coExplode != null)
        {
            StopCoroutine(coExplode);
            coExplode = null;
        }
    }

    private void Start()
    {
        CoroutineTest test = new CoroutineTest();
        foreach (System.Object t in test)
        {
            // 위의 System.Object 부분에 int를 직접 넣어도 된다.
            int value = (int)t;

            // 1, 2, 3, 4 순서대로 실행.
            Debug.Log(value);
        }

        CoroutineTestWithId idTest = new CoroutineTestWithId();
        foreach (System.Object t in idTest)
        {
            IdTest value = (IdTest)t;
            Debug.Log($"id = {value.id}");
        }

        coExplode = StartCoroutine("ExplodeAfterSeconds", 4.0f);
        StartCoroutine("CoStopExplode", 2.0f);
    }
}