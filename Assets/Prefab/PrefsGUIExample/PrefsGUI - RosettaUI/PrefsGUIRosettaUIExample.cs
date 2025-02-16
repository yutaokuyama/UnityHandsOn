#define PrefsGUI_RosettaUI

using PrefsGUI.Example;
using UnityEngine;
#if PrefsGUI_RosettaUI
using RosettaUI;
#endif

namespace PrefsGUI.RosettaUI.Example
{
#if PrefsGUI_RosettaUI
    [RequireComponent(typeof(RosettaUIRoot))]
    public class PrefsGUIRosettaUIExample : MonoBehaviour
    {
        public Vector2 position;
        
        private void Start()
        {
            
            var root = GetComponent<RosettaUIRoot>();
            root.Build(CreateElement());
            Debug.Log("Start");

        }

        Element CreateElement()
        {
            Debug.Log("Create Element");
            return UI.Window(
                "PrefsGUI - RosettaUI",
                UI.WindowLauncher<PrefsGUIExample_Part1>("General"),
                // UI.WindowLauncher<PrefsGUIExample_Part2>("Part2"),
                // UI.WindowLauncher<PrefsGUIExample_Part3>("Part3"),
                // UI.WindowLauncher(UI.Window(nameof(PrefsSearch), PrefsSearch.CreateElement())),
                UI.Space().SetHeight(15f),
                UI.Label(() => $"file path: {Kvs.PrefsKvsPathSelector.path}"),
                UI.Button(nameof(Prefs.Save), Prefs.Save),
                UI.Button(nameof(Prefs.DeleteAll), Prefs.DeleteAll)
            ).SetPosition(position);
        }
    }
#else
    public class PrefsGUIRosettaUIExample : MonoBehaviour
    {}
#endif
}