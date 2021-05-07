using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticePlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;

    float _yAngle = 0.0f;

    void Start()
    {
        
    }

    // GameObject (Player)
    // Transform
    // PlayerController (*)
    void Update()
    {
        // Local �� World
        // TransformDirection
        //transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);
        //transform.position += transform.TransformDirection(Vector3.back * Time.deltaTime * _speed);
        //transform.position += transform.TransformDirection(Vector3.left * Time.deltaTime * _speed);
        //transform.position += transform.TransformDirection(Vector3.right * Time.deltaTime * _speed);

        // World �� Local
        // InverseTransformDirection

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

        // ���� ȸ�� ��.
        _yAngle += Time.deltaTime * 100;
        //transform.eulerAngles = new Vector3(0.0f, _yAngle, 0.0f);

        // +- delta ȸ�� ��.
        //transform.Rotate(new Vector3(0.0f, Time.deltaTime * 100, 0.0f));

        //transform.rotation = Quaternion.Euler(new Vector3(0.0f, _yAngle, 0.0f));
    }
}
