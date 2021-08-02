using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory_Item : UI_Base
{
    enum GameObjects
    {
        ItemIcon
        , ItemNameText
    }

    string _name;

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));

        Get<GameObject>((int)GameObjects.ItemNameText).GetComponent<Text>().text = _name;
        Get<GameObject>((int)GameObjects.ItemIcon).BindEvent((PointerEventData) => { Debug.Log($"������ Ŭ��! {_name}"); });
    }

    public void SetInfo(string name)
    {
        _name = name;
    }
}
