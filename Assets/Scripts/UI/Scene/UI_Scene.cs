using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Scene : UI_Base
{
    public override void Init()
    {
        // Start 함수의 경우,
        // 만약 다른 Script에서 해당 Popup을 Start에서 생성할 경우,
        // 호출이 안될수도 있기 때문에 쓰지 않는다.

        Managers.UI.SetCanvas(gameObject, false);
    }
}
