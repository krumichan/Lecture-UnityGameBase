using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.QuaterView;

    [SerializeField]
    Vector3 _delta = new Vector3(0.0f, 6.0f, -5.0f);
    
    [SerializeField]
    GameObject _player = null;

    void Start()
    {
            
    }

    void LateUpdate()
    {
        if (_mode == Define.CameraMode.QuaterView)
        {
            RaycastHit hit;
            
            // 카메라와 플레이어 사이에 벽이 있을 경우.
            if (Physics.Raycast(_player.transform.position, _delta, out hit, _delta.magnitude, LayerMask.GetMask("Wall")))
            {
                // 크기&방향 벡터에서 크기만 추출하여 살짝 앞으로 당김.
                float distance = (hit.point - _player.transform.position).magnitude * 0.8f;
                transform.position = _player.transform.position + _delta.normalized * distance;
            }

            // 카메라와 플레이어 사이에 벽이 없을 경우.
            else
            {
                transform.position = _player.transform.position + _delta;
                transform.LookAt(_player.transform);
            }
        }
    }

    public void SetQuaterView(Vector3 delta)
    {
        _mode = Define.CameraMode.QuaterView;
        _delta = delta;
    }
}
