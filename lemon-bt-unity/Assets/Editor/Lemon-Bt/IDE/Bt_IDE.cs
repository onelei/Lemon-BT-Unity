using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Reflection;
using Lemon_Bt;

public class Bt_IDE : EditorWindow
{
    public enum NodeType
    {
        Actions,
        Composites,
        Conditionals,
        Decorators
    }

    // create asset
    static string assetName = "LemonBt.asset";
    static string assetOutputPath = @"Assets\LemonBt";

    public Bt_IDE()
    {
        RecList = new List<Rect>();
        RecCircleList = new List<Rect>();
    }

    [MenuItem("AI/LemonBt/IDE")]
    public static Bt_IDE IDE_Window()
    {
        Bt_IDE Bt_Window = EditorWindow.GetWindow<Bt_IDE>();
        Bt_Window.title = "Lemon-Bt";
        return Bt_Window;
    }

    static int mNode_Num = 0;
    List<Rect> RecList;
    List<Rect> RecCircleList;
    Rect mClickRect;
    Assembly asm;
    Event mEvent;
    bool mb_Running = false;
    void OnGUI()
    {
         mEvent = Event.current;

         // 右键菜单;
         if (mEvent.type == EventType.ContextClick)
         {
             RightClickMenu();
         }

        //打开一个通知栏;
        //if (GUILayout.Button("Lemon Behavior", GUILayout.Width(200)))
        //{
        //    ShowNotification(new GUIContent("This is a Notification"));
        //}
         // 左边菜单按钮;
         Bt_IDE_LeftMenu.Bt_LeftMenu();

        // 划线;
        LoadAllLine();

        // 载入所有节点;
        LoadAllBox(mNode_Num);

      //  CheckBoxClicked();

      //  DrawMoveableLine();
    }

    void LoadAllBox(int num)
    {
        if (num<=0)
        {
            return;
        }
 
        BeginWindows();
        for (int i = 0; i < num; ++i)
        {
            // 创建box;
            RecList[i] = GUI.Window(i, RecList[i], WindowFunction, "Box" + i);
      
        }
        EndWindows();

    }

    void LoadAllLine()
    {
        if (RecList.Count<=1)
        {
            return;
        }
        Handles.BeginGUI();
        for(int i=0;i<RecList.Count-1;++i)
        {
            DrawOneLine(RecList[i], RecList[i+1]);
        }         
        Handles.EndGUI();
    }

    void DrawOneLine(Rect rec1,Rect rec2)
    {
        Color color = Color.white;
        Handles.DrawBezier(rec1.center, rec2.center,
           new Vector2(rec1.xMax + 50f, rec1.center.y),
           new Vector2(rec2.xMin - 50f, rec2.center.y),
           color, null, 5f);
    }


    Rect windowRect = new Rect(400 + 100, 100, 100, 100);
    Rect windowRect2 = new Rect(400, 100, 100, 100);

    void DrawBox(int id1, int id2)
    {
        Handles.BeginGUI();
        Handles.DrawBezier(windowRect.center, windowRect2.center, new Vector2(windowRect.xMax + 50f, windowRect.center.y), new Vector2(windowRect2.xMin - 50f, windowRect2.center.y), Color.white, null, 5f);
        Handles.EndGUI();

        BeginWindows();
        windowRect = GUI.Window(id1, windowRect, WindowFunction, "Box1");
        windowRect2 = GUI.Window(id2, windowRect2, WindowFunction, "Box2");
        EndWindows();
    }

    void WindowFunction(int windowID)
    {
        GUI.DragWindow();
    }

    void RightClickMenu()
    {
        if (GUILayout.Button("Create", GUILayout.Width(200)))
        {

        }
        GenericMenu menu = new GenericMenu();
        //menu.AddSeparator ("");
        menu.AddItem(new GUIContent("Add Node/Actions"), false, Callback, NodeType.Actions);
        menu.AddItem(new GUIContent("Add Node/Composites"), false, Callback, NodeType.Composites);
        menu.AddItem(new GUIContent("Add Node/Conditionals"), false, Callback, NodeType.Conditionals);
        menu.AddItem(new GUIContent("Add Node/Decorators"), false, Callback, NodeType.Decorators);
        menu.ShowAsContext();
        mEvent.Use();

    }

    /// <summary>
    /// 按钮回调;
    /// </summary>
    /// <param name="obj"></param>
    void Callback(object obj)
    {
        NodeType type = (NodeType)obj;
        switch (type)
        {
            case NodeType.Actions:
                {
                    UpdateRecList(++mNode_Num);
                }
                break;
            case NodeType.Composites:
                {

                }
                break;
            case NodeType.Conditionals:
                {

                }
                break;
            case NodeType.Decorators:
                {

                }
                break;
            default:
                {

                }
                break;
        }
        Debug.Log("Selected: " + obj);
    }

    void UpdateRecList(int num)
    {
        // 在鼠标点击的地方,创建box;
        if (num > RecList.Count)
        {
            Rect rect = new Rect(mEvent.mousePosition.x, mEvent.mousePosition.y, 100, 100);
            RecList.Add(rect);
        }
    }


    void CheckBoxClicked()
    {
        for (int i = 0; i < RecList.Count;++i )
        {
            if(RecList[i].Contains(mEvent.mousePosition))
            {
                mClickRect = RecList[i];
                Debug.Log("~~~~~~~~~~~~~~~~~~~");
                break;
            }
        }
    }

    void DrawMoveableLine()
    {
        if (mClickRect!=null)
        {
            Handles.BeginGUI();
            Rect mouseRect = new Rect(mEvent.mousePosition.x, mEvent.mousePosition.y, 100, 100);
            DrawOneLine(mClickRect, mouseRect);
            Handles.EndGUI();
        }
     
    }
}

