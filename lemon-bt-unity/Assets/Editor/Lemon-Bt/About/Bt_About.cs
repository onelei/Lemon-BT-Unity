using System.IO;
using UnityEditor;
using UnityEngine;
using System.Reflection;

public class Bt_About : EditorWindow
{
    [MenuItem("AI/LemonBt/About")]
    public static Bt_About BtnAbout()
    {
        Bt_About newWindow = EditorWindow.GetWindow<Bt_About>();
        newWindow.name = "About";
        return newWindow;
    }

    Assembly asm;

    void OnGUI()
    {
        About();
    }

    static void About()
    {
        GUIStyle style = null;
        GUILayout.Space(10);
        style = new GUIStyle();
     //   style.fontStyle = FontStyle.Bold;
        style.normal.textColor = Color.white;
        GUILayout.Label("Create by OneLei!\nahleiwolong@163.com", style);
    }
}

