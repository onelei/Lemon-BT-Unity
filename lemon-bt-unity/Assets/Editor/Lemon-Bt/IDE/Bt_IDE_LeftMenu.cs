using UnityEditor;
using UnityEngine;

namespace Lemon_Bt
{
    public class Bt_IDE_LeftMenu
    {
        private static Vector2 scrollPos;
        private static bool mb_Action = true;
        private static bool mb_Composites = true;
        private static bool mb_Conditionals = true;
        private static bool mb_Decorators = true;


        public static void Bt_LeftMenu()
        {
            EditorGUILayout.BeginVertical();
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Width(200));

            // Actions;
            mb_Action = EditorGUILayout.Foldout(mb_Action, "Action");
            if (mb_Action)
            {
                for (int i = 0; i < 9; ++i)
                {
                    GUILayout.Button("Button_" + i, GUILayout.Width(200));
                }
            }

            mb_Composites = EditorGUILayout.Foldout(mb_Composites, "Composites");
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
    }
}
