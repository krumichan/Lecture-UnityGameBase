using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    // 1) RigidBody ����. ( IsKinematic : Off )
    // 2) Collider ����. ( IsTrigger : Off )
    // 3) ���浵 Collider ���� ( IsTrigger : Off )
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision !");   
    }

    // 1) �� �� Collider ����.
    // 2) �� �� �ϳ��� IsTrigger : On
    // 3) �� �� �ϳ��� RigidBody ����.
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger !");
    }

    void Start()
    {
        
    }

    void Update()
    {
        Version2();
    }

    void Info()
    {
        // Local �� World �� ��Viewport �� Screen��(ȭ��)

        //Input.mousePosition; // Screen Position(x, y, 0).

        //Camera.main.ScreenToViewportPoint(Input.mousePosition); // Viewport Position(0.x, 0.y, 0). (���� ǥ��)

        /*// Local �� World
        Vector3 look = transform.TransformDirection(Vector3.forward);

        Debug.DrawRay(transform.position + Vector3.up, look  * 10, Color.red);

        RaycastHit[] hits = Physics.RaycastAll(transform.position + Vector3.up, look, 10);
        foreach (var hit in hits)
        {
            Debug.Log($"Raycast {hit.collider.gameObject.name}");
        }*/
    }

    void Version1()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // mouse��ġ���� Caemra�� near��ŭ ������ ������.
            Vector3 mousePosition =
                Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));

            Vector3 cameraPosition = Camera.main.transform.position;

            // ���� ���͸� ���Ѵ�.
            Vector3 direction = mousePosition - cameraPosition;
            direction = direction.normalized;

            Debug.DrawRay(cameraPosition, direction * 100.0f, Color.red, 1.0f);

            RaycastHit hit;
            if (Physics.Raycast(cameraPosition, direction, out hit, 100.0f))
            {
                Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
            }
        }
    }

    void Version2()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

            LayerMask maskMonster = LayerMask.GetMask("Monster"); // int maskMonster = (1 << 6);
            LayerMask maskWall = LayerMask.GetMask("Wall"); // int maskWall = (1 << 7);
            LayerMask maskMonsterAndWall = maskMonster | maskWall;

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100.0f, maskMonsterAndWall))
            {
                Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
            }
        }
    }
}
