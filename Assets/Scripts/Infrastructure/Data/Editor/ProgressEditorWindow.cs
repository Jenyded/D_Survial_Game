using System.IO;
using _Project.Scripts.Infrastructure.Services.PersistentData;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace _Project.Scripts.Infrastructure.Data.Editor
{
    public class ProgressEditorWindow : OdinEditorWindow
    {
        [PropertyOrder(1), HideLabel] 
        public PlayerProgress PlayerProgress;

        [MenuItem("Editors/DataEditor")]
        private static void OpenWindow()
        {
            GetWindow<ProgressEditorWindow>().Show();
        }

        protected override void OnImGUI()
        {
            base.OnImGUI();
        }

        [ButtonGroup("Saves"), Button(ButtonSizes.Large), PropertyOrder(0)]
        private void Save()
        {

        }

        [ButtonGroup("Saves")]
        private void Load()
        {
            string jsonPath = EditorUtility.OpenFilePanel("import save", "", "json");
            PlayerPrefs.SetString("save", File.ReadAllText(jsonPath));
        }

        [ButtonGroup("Clear")]
        private void Clear()
        {
        
        }

        [ButtonGroup("Export")]
        private void Export()
        {
        
        }
    }
}
