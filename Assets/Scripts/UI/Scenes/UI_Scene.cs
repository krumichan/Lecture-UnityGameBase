using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Scene : UI_Base
{
    public override void Init()
    {
        // Start �Լ��� ���,
        // ���� �ٸ� Script���� �ش� Popup�� Start���� ������ ���,
        // ȣ���� �ȵɼ��� �ֱ� ������ ���� �ʴ´�.

        Managers.UI.SetCanvas(gameObject, false);
    }
}
