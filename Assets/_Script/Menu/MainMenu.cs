using System.Collections.Generic;
using project.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace project.Menu
{
    public class StartMenu : BasicMenu
    {
        public MenuManager menuManager;
        protected override void Start()
        {
            base.Start();
            UpdateButtonText("PlayBtn", "Start");
            UpdateText("StartMenuBanner", "Start Menu");
            this.Init();
            CopyButton("PlayBtn", "Add button", new Vector3(3, -400, 0), InitBtn);
        }
        private void Init()
        {
            foreach (Button button in buttons)
            {
                if (button.name == "PlayBtn")
                {
                    button.onClick.AddListener(PlayGame);
                }
                else if (button.name == "ExitBtn")
                {
                    button.onClick.AddListener(ExitGame);
                }
                else
                {
                    Debug.Log("Unknown button: " + button.name);
                }
            }
        }
        public void ExitGame() => Debug.Log("Exit button clicked.");
        public void PlayGame() => Debug.Log("Play button clicked.");
        public void NewButtonClicked() => Debug.Log("New button clicked.");
        public void InitBtn() => CopyButton("PlayBtn", "New Button", new Vector3(3, 165, 0), NewButtonClicked);

    }
}
