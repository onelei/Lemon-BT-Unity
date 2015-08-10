using System.IO;
using UnityEditor;
using UnityEngine;
using System.Reflection;

public class LemonBtWindow : EditorWindow
{

    // create asset
    static string assetName = "LemonBt.asset";
    static string assetOutputPath = @"Assets\LemonBt";

    [MenuItem("AI/LemonBt/Designe")]
    public static LemonBtWindow LemonBt()
    {
        LemonBtWindow newWindow = EditorWindow.GetWindow<LemonBtWindow>();
        return newWindow;
    }

    [MenuItem("AI/LemonBt/About")]
    public static LemonBtWindow BtnAbout()
    {
        LemonBtWindow newWindow = EditorWindow.GetWindow<LemonBtWindow>();
        newWindow.name = "About";
       // LemonBtWindow newWindow = ScriptableWizard.DisplayWizard<LemonBtWindow>("About");
       // GUIAbout();
        return newWindow;
    }

    Assembly asm;

    void OnGUI()
    {
      //  GUIAbout();

    }

    //static void About()
    //{
    //    GUIStyle style = null;
    //    GUILayout.Space(10);
    //    style = new GUIStyle();
    //    style.fontStyle = FontStyle.Bold;
    //    style.normal.textColor = Color.green;
    //    GUILayout.Label("Create by OneLei!\nahleiwolong@163.com", style);
    //}
}

