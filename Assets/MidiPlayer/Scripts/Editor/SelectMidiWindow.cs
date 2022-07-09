using System;
using System.Collections.Generic;
using System.IO;
using MPTK.NAudio.Midi;
namespace MidiPlayerTK
{
    //using MonoProjectOptim;
    using UnityEditor;
    using UnityEngine;

    /// <summary>@brief
    /// Window editor for the setup of MPTK
    /// </summary>
    public class SelectMidiWindow : EditorWindow
    {
        //static public SelectMidiWindow SelectWindow;
        public SelectMidiWindow SelectWindow;
        private CustomStyle myStyle;

        public string Title;
        public int ColWidth;
        public int ColHeight;
        public bool KeepOpen;
        public object Tag;
        public int EspaceX;
        public int EspaceY;
        public int TitleHeight;
        public Color BackgroundColor;
        public int SelectedItem;
        public List<MPTKListItem> list;
        private Vector2 scrollPos;
        private int resizedWidth;
        private int resizedHeight;
        private int calculatedColCount;
        private int countRow;
        public Action<object, int> OnSelect;
        string midiFilter = "";


        void OnGUI()
        {
            try
            {
                //Debug.Log("ongui");
                MidiCommonEditor.LoadSkinAndStyle();
                ColWidth = 250;
                ColHeight = 30;
                EspaceX = 5;
                EspaceY = 5;
                TitleHeight = 30;
                KeepOpen = true;

                resizedWidth = (int)SelectWindow.position.size.x;
                resizedHeight = (int)SelectWindow.position.size.y;
                list = new List<MPTKListItem>();
                foreach (string midiname in MidiPlayerGlobal.CurrentMidiSet.MidiFiles)
                    list.Add(new MPTKListItem() { Label = midiname, Index = list.Count });
                calculatedColCount = resizedWidth / (ColWidth + EspaceX); //3;
                calculatedColCount = Mathf.Clamp(calculatedColCount, 1, 5);
                countRow = (int)((float)list.Count / (float)calculatedColCount + 1f);

                if (myStyle == null)
                    myStyle = new CustomStyle();

                DrawWindow();
            }
            catch (Exception ex)
            {
                MidiPlayerGlobal.ErrorDetail(ex);
            }
        }
        private void DrawWindow()
        {
            int localstartX = 0;// EspaceX;
            int localstartY = 0;// EspaceY;
            int boxX = 0;
            int boxY = 0;

            Rect zone = new Rect(localstartX, localstartY, resizedWidth + EspaceX, resizedHeight + EspaceY);
            GUI.color = BackgroundColor;
            GUI.Box(zone, "");
            GUI.color = Color.white;

            GUI.Label(new Rect(localstartX, localstartY + 5, 50, TitleHeight - 10), "Filter:");
            midiFilter = GUI.TextField(new Rect(localstartX + 55, localstartY + 5, 200, TitleHeight - 10), midiFilter);
            if (GUI.Button(new Rect(localstartX + 55 + 5 + 200, localstartY + 5, 20, TitleHeight - 10), "X", myStyle.BtStandard))
                midiFilter = "";

            Rect listVisibleRect = new Rect(localstartX, localstartY + TitleHeight, resizedWidth - localstartX, resizedHeight - EspaceY - TitleHeight);
            Rect listContentRect = new Rect(0, 0, calculatedColCount * (ColWidth + EspaceX) + 0, countRow * ColHeight + EspaceY + TitleHeight);

            scrollPos = GUI.BeginScrollView(listVisibleRect, scrollPos, listContentRect);

            boxX = 0;
            boxY = 0;

            int indexList = -1;
            try
            {
                foreach (MPTKListItem item in list)
                {
                    if (item != null)
                    {
                        indexList++;
                        if (string.IsNullOrEmpty(midiFilter) || item.Label.ToUpper().Contains(midiFilter.ToUpper()))
                        {
                            GUIStyle style = myStyle.BtStandard;
                            // if (patch.Index == selectedItem) style = myStyle.BtSelected;
                            if (item.Index == SelectedItem)
                                GUI.color = myStyle.ButtonColor;

                            Rect rect = new Rect(boxX, boxY, ColWidth, ColHeight);

                            if (GUI.Button(rect, indexList + " - " + item.Label, style))
                            {
                                SelectedItem = item.Index;
                                if (OnSelect != null)
                                    OnSelect(Tag, item.Index);
                                if (!KeepOpen)
                                    SelectWindow.Close();
                            }
                            GUI.color = Color.white;

                            if (calculatedColCount <= 1 || indexList % calculatedColCount == calculatedColCount - 1)
                            {
                                // New row
                                boxY += ColHeight;
                                boxX = 0;
                            }
                            else
                                boxX += ColWidth + EspaceX;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            GUI.EndScrollView();
        }
    }
}