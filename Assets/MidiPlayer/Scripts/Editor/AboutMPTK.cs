using UnityEngine;
using UnityEditor;
using System;

using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace MidiPlayerTK
{
    public class AboutMPTK : PopupWindowContent
    {

        private int winWidth = 838;
        private int winHeight = 450;
        static Vector2 scrollPosAnalyze = Vector2.zero;
    

        public override Vector2 GetWindowSize()
        {
            return new Vector2(winWidth, winHeight);
        }

        [MenuItem("MPTK/Version and Doc &V", false, 100)]
        private static void Display()
        {
            try
            {
                Rect rect = new Rect() { x = 100, y = 120 };
                PopupWindow.Show(rect, new AboutMPTK());
            }
            catch (Exception)
            {

            }
        }


      
        public override void OnGUI(Rect rect)
        {
            MidiCommonEditor.LoadSkinAndStyle(false);
            try
            {
                float xCol0 = 5;
                float xCol1 = 20;
                float xCol2 = 120;
                float yStart = 0;
                float ySpace = 18;
                float colWidth = 230;
                float colHeight = 17;
                float btWidth = 130;
                float btHeight = 22;
                float btx = xCol0;
                float spaceH = 8;
                float spaceV = 8;
                string textVersion = "";

                GUIStyle style = new GUIStyle("Label");
                style.fontSize = 16;
                style.normal.textColor = Color.black;
                style.fontStyle = FontStyle.Bold;

                try
                {
                    int sizePicture = 90;
                    Texture aTexture = Resources.Load<Texture>("Logo_MPTK");
                    //TextAsset textAsset = Resources.Load<TextAsset>("Version changes");
                    //textVersion = System.Text.Encoding.UTF8.GetString(textAsset.bytes);
                    textVersion =ToolsEditor.ReadTextFile(Application.dataPath + "/MidiPlayer/Version changes.txt");
                    EditorGUI.DrawPreviewTexture(new Rect(winWidth - sizePicture - 5, yStart, sizePicture, sizePicture), aTexture);
                }
                catch (System.Exception ex)
                {
                    MidiPlayerGlobal.ErrorDetail(ex);
                }
                GUIContent cont = new GUIContent("Maestro - Midi Player Tool Kit");
                EditorGUI.LabelField(new Rect(xCol0, yStart-5, 300, 30), cont, style);
                EditorGUI.LabelField(new Rect(xCol0, yStart + 8, 800, colHeight), "_________________________________________________________________________________________________________________________________________________");

                yStart += 15;
                EditorGUI.LabelField(new Rect(xCol1, yStart += ySpace, colWidth, colHeight), "Version:");
                EditorGUI.LabelField(new Rect(xCol2, yStart, colWidth, colHeight), ToolsEditor.version);

                EditorGUI.LabelField(new Rect(xCol1, yStart += ySpace, colWidth, colHeight), "Release:");
                EditorGUI.LabelField(new Rect(xCol2, yStart, colWidth, colHeight), ToolsEditor.releaseDate);

                yStart += 15;
                EditorGUI.LabelField(new Rect(xCol0, yStart += ySpace, colWidth * 2, colHeight), "Design and Development by Thierry Bachmann");
                EditorGUI.LabelField(new Rect(xCol1, yStart += ySpace, colWidth, colHeight), "Email:");
                EditorGUI.TextField(new Rect(xCol2, yStart, colWidth, colHeight), "thierry.bachmann@gmail.com");
                EditorGUI.LabelField(new Rect(xCol1, yStart += ySpace, colWidth, colHeight), "Website:");
                EditorGUI.TextField(new Rect(xCol2, yStart, colWidth, colHeight), ToolsEditor.paxSite);


                yStart += 30;

                if (GUI.Button(new Rect(btx, yStart, btWidth, btHeight), "Unity Forum"))
                {
                    Application.OpenURL(ToolsEditor.forumSite);
                }

                btx += btWidth + spaceH;
                if (GUI.Button(new Rect(btx, yStart, btWidth, btHeight), "Discord Site"))
                {
                    Application.OpenURL(ToolsEditor.DiscordSite);
                }

                btx += btWidth + spaceH;
                if (GUI.Button(new Rect(btx, yStart, btWidth, btHeight), "Documentation Site"))
                {
                    Application.OpenURL(ToolsEditor.blogSite);
                }

                btx += btWidth + spaceH;
                if (GUI.Button(new Rect(btx, yStart, btWidth, btHeight), "API Helper Site"))
                {
                    Application.OpenURL(ToolsEditor.apiSite);
                }

                btx += btWidth + spaceH;
                if (GUI.Button(new Rect(btx, yStart, btWidth, btHeight), "PaxStellar"))
                {
                    Application.OpenURL(ToolsEditor.paxSite);
                }

                btx += btWidth + spaceH;
                if (GUI.Button(new Rect(btx, yStart, btWidth, btHeight), "Get Full Version"))
                {
                    Application.OpenURL(ToolsEditor.UnitySite);
                }

                yStart += btHeight + spaceV;
                float heightList = winHeight - yStart - 10;
                // GUI.TextArea(new Rect() { x = xCol0, y = yStart, width = winWidth - 10, height = winHeight - yStart - 10 }, textVersion);

                float wList = winWidth - 10;
                Rect listVisibleRect = new Rect(
                    xCol0,
                    yStart,
                    wList,
                    heightList);

                Rect listContentRect = new Rect(
                    0,
                    0,
                    2 * wList,
                    121 * MidiCommonEditor.lineHeight + spaceV);

                Rect fondRect = new Rect(
                    xCol0,
                    yStart,
                    wList,
                    heightList);

                GUI.Box(fondRect, "", MidiCommonEditor.stylePanel);

                scrollPosAnalyze = GUI.BeginScrollView(listVisibleRect, scrollPosAnalyze, listContentRect);
                if (!string.IsNullOrEmpty(textVersion))
                    GUI.Box(listContentRect, textVersion, MidiCommonEditor.styleLabelUpperLeft);
                GUI.EndScrollView();
            }
            catch (System.Exception ex)
            {
                MidiPlayerGlobal.ErrorDetail(ex);
            }
        }
      
    }
}