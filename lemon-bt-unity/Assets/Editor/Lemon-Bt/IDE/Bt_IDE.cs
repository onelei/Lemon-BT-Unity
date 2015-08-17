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

    public class node
    {
        public int self=-1;
        public int other=-1;
    }
    // create asset
    static string assetName = "LemonBt.asset";
    static string assetOutputPath = @"Assets\LemonBt";

    public Bt_IDE()
    {
        RecList = new List<Rect>();
        mRectLines = new List<node>();
    }

    [MenuItem("AI/LemonBt/IDE")]
    public static Bt_IDE IDE_Window()
    {
        Bt_IDE Bt_Window = EditorWindow.GetWindow<Bt_IDE>();
        Bt_Window.title = "Lemon-Bt";
        return Bt_Window;
    }

    static int mNode_Num = 0;
    int parentWinID = -1;
    List<Rect> RecList;
    List<node> mRectLines;
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

        // 鼠标拖动的时候,记录两个box;
        if(mEvent.type==EventType.MouseDrag)
        {
            DrawMoveableLine();
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

      //  
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
        for (int i = 0; i < mRectLines.Count; ++i)
        {
            int selfIndex = mRectLines[i].self;
            int otherIndex = mRectLines[i].other;
            if (selfIndex!=-1&&otherIndex!=-1)
            {
                DrawOneLine(RecList[selfIndex], RecList[otherIndex]);
            }
        }      
        Handles.EndGUI();
    }

    void DrawOneLine(Rect rec1,Rect rec2)
    {
        Color color = Color.green;
        Handles.DrawBezier(rec1.center, rec2.center,
           new Vector2(rec1.xMax + 50f, rec1.center.y),
           new Vector2(rec2.xMin - 50f, rec2.center.y),
           color, null, 5f);
    }


    Rect windowRect = new Rect(400 + 100, 100, 100, 100);
    Rect windowRect2 = new Rect(400, 100, 100, 100);

    //void DrawBox(int id1, int id2)
    //{
    //    Handles.BeginGUI();
    //    Handles.DrawBezier(windowRect.center, windowRect2.center, new Vector2(windowRect.xMax + 50f, windowRect.center.y), new Vector2(windowRect2.xMin - 50f, windowRect2.center.y), Color.white, null, 5f);
    //    Handles.EndGUI();

    //    BeginWindows();
    //    windowRect = GUI.Window(id1, windowRect, WindowFunction, "Box1");
    //    windowRect2 = GUI.Window(id2, windowRect2, WindowFunction, "Box2");
    //    EndWindows();
    //}

    void WindowFunction(int windowID)
    {
         //创建一个GUI Button  
        if (GUILayout.RepeatButton("Link")) 
        {  
            Debug.Log("Click Link Button"); 
            // 连线;
            parentWinID = windowID;
        }  
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

    void DrawMoveableLine()
    {
        for(int i = 0;i<RecList.Count;++i)
        {
            if (RecList[i].Contains(mEvent.mousePosition) &&parentWinID!=-1&& parentWinID != i)
            {
                // 可以连接了;
                node _node = new node();
                _node.self = i;
                _node.other = parentWinID;
                mRectLines.Add(_node);
                parentWinID = -1;
                Debug.Log("~~~~~~~~~~~~~~~~~~~");
                break;
            }           
        }
    }
}

