using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;

    bool _moveToDestination = false;
    Vector3 _destination;
    
    void Start()
    {
        // ��𼱰� ������û�� �ϰ� ���� ��� ����.
        Managers.Input.KeyAction -= OnKeyboard;

        // ���� �� �߰�. ( �ߺ� ���� ���� )
        Managers.Input.KeyAction += OnKeyboard;

        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;
    }

    float wait_run_ratio = 0.0f;
    void Update()
    {
        if (_moveToDestination)
        {
            Vector3 direction = _destination - transform.position;
            if (direction.magnitude < 0.0001f)
            {
                _moveToDestination = false;
            }
            else
            {
                // �̵� �Ÿ��� �ݵ�� ����&ũ�� ����(direction)�� ũ�⺸�� �۾ƾ� �Ѵ�.
                // �׷��� ������, ������ �ٷ� �αٿ��� �������� �Դٰ��� �Ѵ�.
                float moveDistance = Mathf.Clamp(_speed * Time.deltaTime, 0, direction.magnitude);

                transform.position += direction.normalized * moveDistance;
                transform.rotation = Quaternion.Slerp(
                       transform.rotation
                       , Quaternion.LookRotation(direction)
                       , 20 * Time.deltaTime
                );
            }
        }

        if (_moveToDestination)
        {
            wait_run_ratio = Mathf.Lerp(wait_run_ratio, 1, 10.0f * Time.deltaTime);
            Animator animator = GetComponent<Animator>();
            animator.SetFloat("wait_run_ratio", wait_run_ratio);
            animator.Play("WAIT_RUN");
        }
        else
        {
            wait_run_ratio = Mathf.Lerp(wait_run_ratio, 0, 10.0f * Time.deltaTime);
            Animator animator = GetComponent<Animator>();
            animator.SetFloat("wait_run_ratio", wait_run_ratio);
            animator.Play("WAIT_RUN");
        }
    }

    void OnKeyboard()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation
                , Quaternion.LookRotation(Vector3.forward)
                , 0.2f
            );
            transform.position += Vector3.forward * Time.deltaTime * _speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation
                , Quaternion.LookRotation(Vector3.back)
                , 0.2f
            );
            transform.position += Vector3.back * Time.deltaTime * _speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation
                , Quaternion.LookRotation(Vector3.left)
                , 0.2f
            );
            transform.position += Vector3.left * Time.deltaTime * _speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation
                , Quaternion.LookRotation(Vector3.right)
                , 0.2f
            );
            transform.position += Vector3.right * Time.deltaTime * _speed;
        }

        _moveToDestination = false;
    }

    void OnMouseClicked(Define.MouseEvent evt)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Wall")))
        {
            _destination = hit.point;
            _moveToDestination = true;
        }
    }
}
