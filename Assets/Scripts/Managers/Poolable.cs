using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poolable : MonoBehaviour
{
    // 해당 Component를 가지고 있으면
    // Pooling을 수행한다.
    // 즉, Pooling 대상인지를 인식하기 위한 Component.
    public bool IsUsing;
}
