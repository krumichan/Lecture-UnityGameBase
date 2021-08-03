using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;

    Vector3 _destination;
    
    void Start()
    {
        /*        // ��𼱰� ������û�� �ϰ� ���� ��� ����.
                Managers.Input.KeyAction -= OnKeyboard;

                // ���� �� �߰�. ( �ߺ� ���� ���� )
                Managers.Input.KeyAction += OnKeyboard;*/

        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;
    }

    public enum PlayerState
    {
        Die
        , Moving
        , Idle
        /*, Channeling
        , Jumping
        , Falling*/
    }

    PlayerState _state = PlayerState.Idle;

    void UpdateDie()
    {
        // �ƹ��͵� ����.
    }

    void UpdateMoving()
    {
        Vector3 direction = _destination - transform.position;
        if (direction.magnitude < 0.0001f)
        {
            _state = PlayerState.Idle;
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

        // animation
        Animator animator = GetComponent<Animator>();
        // ���� ���� ���¿� ���� ������ ����.
        animator.SetFloat("speed", _speed);
    }

     void UpdateIdle()
    {
        // animation
        Animator animator = GetComponent<Animator>();
        animator.SetFloat("speed", 0);
    }

    void Update()
    {
        switch (_state)
        {
            case PlayerState.Die:
                UpdateDie();
                break;

            case PlayerState.Moving:
                UpdateMoving();
                break;

            case PlayerState.Idle:
                UpdateIdle();
                break;
        }
    }

    #region not use
/*    void OnKeyboard()
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
    }*/
    #endregion

    void OnMouseClicked(Define.MouseEvent evt)
    {
        if (_state == PlayerState.Die)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Wall")))
        {
            _destination = hit.point;
            _state = PlayerState.Moving;
        }
    }
}
