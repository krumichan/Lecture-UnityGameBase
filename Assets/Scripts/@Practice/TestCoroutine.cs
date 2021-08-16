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
    // 1. �Լ��� ��������/���� ����.
    //  �� ��û ���� �ɸ��� �۾��� ��� ���� ���.
    //  �� ���ϴ� Ÿ�ֿ̹� �Լ��� ��� Stop/Start �ϴ� ���.
    // 2. return �� ���ϴ� Ÿ������ ��ȯ ���� ( class�� ���� )
    // ��, Coroutine�� �ð� ������ �ſ� �����ϴ�.
    void GenerateItem()
    {
        // 1. ������ ����.
        // 2. DB ����.

        // �� �߰� ��������,
        // DB�� �����ϱ� ���� �Ʒ��� Logic�� ������ ���,
        // ��ġ�ʴ� ������ �߻��� �� �ִ�.
        // ��, DB ���� ���� ��û�� ���� �� Logic�� �����ϵ��� �ϰ� �Ѵ�.
        // �� Coroutine�� yield �迭�� ����Ͽ� �Ͻ� ����.

        // 3. Logic.
    }

    float deltaTime = 0;
    void ExplodeAfter4Seconds()
    {
        // �� Frame���� time�� ���ϰ� Ȯ���ؾ� �Ѵ�.
        // ��, cost�� �߻�.
        deltaTime += Time.deltaTime;
        if (deltaTime >= 4)
        {
            // Logic.
        }
    }

    Coroutine coExplode;

    // ExplodeAfter3Seconds�� Coroutine���� ȿ�������� ���� �� �ִ�.
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
            // ���� System.Object �κп� int�� ���� �־ �ȴ�.
            int value = (int)t;

            // 1, 2, 3, 4 ������� ����.
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