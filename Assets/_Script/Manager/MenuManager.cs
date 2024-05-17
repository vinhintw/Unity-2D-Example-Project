using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using project.Menu;

namespace project.Manager
{
    public class MenuManager : MonoBehaviour
    {
        public List<BasicMenu> menus;

        void Start() { Init(); }
        #region  Initialize 
        // init Menus
        private void Init()
        {
            foreach (Transform child in transform)
            {
                BasicMenu menu = child.GetComponent<BasicMenu>();
                if (menu != null)
                {
                    menus.Add(menu);
                    Debug.Log("menu name: " + menu.name);
                }
            }
        }
        #endregion
        #region Find prop
        public BasicMenu FindMenu(string menuName)
        {
            foreach (BasicMenu menu in menus)
            {
                if (menu.name == menuName)
                {
                    return menu;
                }
            }
            Debug.LogError("Menu with name '" + menuName + "' not found.");
            return null;
        }
        #endregion
        #region Show prop
        public void ShowMenu(string menuName)
        {
            BasicMenu menuToShow = FindMenu(menuName);
            if (menuToShow != null)
            {
                menuToShow.gameObject.SetActive(true);
            }
        }
        #endregion
        #region Hide prop
        public void HideMenu(string menuName)
        {
            BasicMenu menuToHide = FindMenu(menuName);
            if (menuToHide != null)
            {
                menuToHide.gameObject.SetActive(false);
            }
        }
        #endregion
        #region Switch prop
        public void SwitchMenu(string menuToHide, string menuToShow)
        {
            HideMenu(menuToHide);
            ShowMenu(menuToShow);
        }
        #endregion
    }
}