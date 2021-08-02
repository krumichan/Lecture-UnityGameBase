using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : UI_Scene
{
    enum GameObjects
    {
        GridPanel
        ,
    }
    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));

        GameObject gridPanel = Get<GameObject>((int)GameObjects.GridPanel);
        foreach (Transform child in gridPanel.transform)
        {
            Managers.Resource.Destroy(child.gameObject);
        }

        // 실제 Inventory 정보를 참고하여 생성.
        for (int i = 0; i < 24; ++i)
        {
            GameObject item = Managers.UI.MakeSubItem<UI_Inventory_Item>(parent: gridPanel.transform).gameObject;

            // UI_Inventory_Item invenItem = Util.GetOrAddComponent<UI_Inventory_Item>(item);
            UI_Inventory_Item invenItem = item.GetOrAddComponent<UI_Inventory_Item>();
            invenItem.SetInfo($"집행검+{i}");
        }
    }
}
