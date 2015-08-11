using System.IO;
using UnityEditor;
using UnityEngine;
using System.Reflection;

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
    
	Vector2 scrollPos;
    bool mb_Action = false;
    bool mb_Composites = false;
    bool mb_Conditionals = false;
    bool mb_Decorators = false;

    
    [MenuItem("AI/LemonBt/IDE")]
    public static Bt_IDE IDE_Window()
    {
        Bt_IDE Bt_Window = EditorWindow.GetWindow<Bt_IDE>();
        Bt_Window.title = "Behavior IDE";
        return Bt_Window;
    }
    
    Assembly asm;

    void OnGUI()
    {
        IDE();
        if (GUILayout.Button("Lemon Behavior", GUILayout.Width(200)))
        {
            //打开一个通知栏;
            ShowNotification(new GUIContent("This is a Notification"));
        }

        EditorGUILayout.BeginVertical();
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Width(200));
       
        // Actions;
        mb_Action= EditorGUILayout.Foldout(mb_Action, "Action");
        if (mb_Action)
        {
            for (int i = 0; i < 9; ++i)
            {
                GUILayout.Button("Button_" + i, GUILayout.Width(200));
            }
        }

        mb_Composites=EditorGUILayout.Foldout(mb_Composites, "Composites");
        if (mb_Composites)
        {
            for (int i = 0; i < 9; ++i)
            {
                GUILayout.Button("Button_" + i, GUILayout.Width(200));
            }
        }
        // Conditionals;
        mb_Conditionals = EditorGUILayout.Foldout(mb_Conditionals, "Conditionals");
        if (mb_Conditionals)
        {
            for (int i = 0; i < 9; ++i)
            {
                GUILayout.Button("Button_" + i, GUILayout.Width(200));
            }
        }
        // Decorators;
        mb_Decorators = EditorGUILayout.Foldout(mb_Decorators, "Decorators");
        if (mb_Decorators)
        {
            for (int i = 0; i < 9; ++i)
            {
                GUILayout.Button("Button_" + i, GUILayout.Width(200));
            }
        }
        EditorGUILayout.EndScrollView();
        EditorGUILayout.EndVertical();
      
    }

    static void IDE()
    {
        if (GUILayout.Button("Create",GUILayout.Width(200)))
        {

        }

        Event evt = Event.current;

        // 创建下拉菜单;
        Rect contextRect = new Rect(10, 10, 100, 100);
        if (evt.type == EventType.ContextClick)
        {
            GenericMenu menu = new GenericMenu();
            //menu.AddSeparator ("");
            menu.AddItem(new GUIContent("Add Node/Actions"), false, Callback, NodeType.Actions);
            menu.AddItem(new GUIContent("Add Node/Composites"), false, Callback, NodeType.Composites);
            menu.AddItem(new GUIContent("Add Node/Conditionals"), false, Callback, NodeType.Conditionals);
            menu.AddItem(new GUIContent("Add Node/Decorators"), false, Callback, NodeType.Decorators);
            menu.ShowAsContext();
            evt.Use();
        }

        
        
    }

    /// <summary>
    /// 按钮回调;
    /// </summary>
    /// <param name="obj"></param>
    static void Callback(object obj)
    {
        NodeType type = (NodeType)obj;
        switch (type)
        {
            case NodeType.Actions:
                {
                    //  GameObject action = Instantiate(Resources.Load("img/LightTask")) as GameObject;
                    //  action.transform.position = Vector3.one;
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
}

