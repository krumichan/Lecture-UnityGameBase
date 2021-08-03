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
        /*        // 어디선가 구독신청을 하고 있을 경우 제거.
                Managers.Input.KeyAction -= OnKeyboard;

                // 제거 후 추가. ( 중복 실행 방지 )
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
        // 아무것도 못함.
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
            // 이동 거리는 반드시 방향&크기 벡터(direction)의 크기보다 작아야 한다.
            // 그렇지 않으면, 목적지 바로 부근에서 마구마구 왔다갔다 한다.
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
        // 현재 게임 상태에 대한 정보를 전달.
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
