using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Popup : UI_Base
{
    public override void Init()
    {
        // Start �Լ��� ���,
        // ���� �ٸ� Script���� �ش� Popup�� Start���� ������ ���,
        // ȣ���� �ȵɼ��� �ֱ� ������ ���� �ʴ´�.

        Managers.UI.SetCanvas(gameObject, true);
    }

    public virtual void ClosePopupUI()
    {
        Managers.UI.ClosePopupUI(this);
    }
}
