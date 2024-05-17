using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace project.Menu
{
  public class BasicMenu : MonoBehaviour
  {
    public List<Button> buttons = new List<Button>();
    public List<TMP_Text> texts = new List<TMP_Text>();
    protected virtual void Start()
    {
      Init();
    }
    #region Initialize
    private void Init()
    {
      foreach (Transform child in transform)
      {
        Button button = child.GetComponent<Button>();
        if (button != null)
        {
          buttons.Add(button);
          Debug.Log("Button name: " + button.name);
        }
        TMP_Text text = child.GetComponent<TMP_Text>();
        if (text != null)
        {
          texts.Add(text);
          Debug.Log("Text content: " + text.text);
        }
      }
    }
    #endregion
    #region Update prop
    // Method to update button text
    public void UpdateButtonText(string buttonName, string newText)
    {
      Button buttonToUpdate = FindButton(buttonName);
      if (buttonToUpdate != null)
      {
        buttonToUpdate.GetComponentInChildren<TMP_Text>().text = newText;
      }
      else
      {
        Debug.LogError("Button '" + buttonName + "' not found.");
      }
    }

    // Method to update text content
    public void UpdateText(string textName, string newText)
    {
      TMP_Text textToUpdate = FindText(textName);
      if (textToUpdate != null)
      {
        textToUpdate.text = newText;
      }
      else
      {
        Debug.LogError("Text '" + textName + "' not found.");
      }
    }
    #endregion
    #region Set visible
    public void SetButtonsVisible(List<string> buttonNames, bool isVisible)
    {
      foreach (string buttonName in buttonNames)
      {
        SetButtonVisible(buttonName, isVisible);
      }
    }
    public void SetTextsVisible(List<string> textNames, bool isVisible)
    {
      foreach (string textName in textNames)
      {
        SetTextVisible(textName, isVisible);
      }
    }
    public void SetButtonVisible(string buttonName, bool isVisible)
    {
      Button button = FindButton(buttonName);
      if (button != null)
      {
        button.gameObject.SetActive(isVisible);
      }
      else
      {
        Debug.LogError("Button '" + buttonName + "' not found.");
      }
    }
    public void SetTextVisible(string textName, bool isVisible)
    {
      TMP_Text text = FindText(textName);
      if (text != null)
      {
        text.gameObject.SetActive(isVisible);
      }
      else
      {
        Debug.LogError("Text '" + textName + "' not found.");
      }
    }
    #endregion
    #region private helper
    // Helper method to find button by name
    private Button FindButton(string buttonName)
    {
      foreach (Button button in buttons)
      {
        if (button.name == buttonName)
        {
          return button;
        }
      }
      return null;
    }
    // Helper method to find text by name
    private TMP_Text FindText(string textName)
    {
      foreach (TMP_Text text in texts)
      {
        if (text.name == textName)
        {
          return text;
        }
      }
      return null;
    }
    #endregion
    public void CopyButton(string buttonName, string buttonText, Vector3 position, Action buttonAction)
    {
      Button buttonToCopy = FindButton(buttonName);
      if (buttonToCopy != null)
      {
        GameObject newButtonObject = Instantiate(buttonToCopy.gameObject, transform);
        newButtonObject.transform.localPosition = position;
        newButtonObject.name = buttonName + "Copy";
        newButtonObject.GetComponentInChildren<TMP_Text>().text = buttonText;
        newButtonObject.GetComponent<Button>().onClick.AddListener(() => buttonAction.Invoke());
        buttons.Add(newButtonObject.GetComponent<Button>());
      }
      else
      {
        Debug.LogError("Button '" + buttonName + "' not found.");
      }
    }
    public void PrintButtonList()
    {
      foreach (Button button in buttons)
      {
        Debug.Log("Button name: " + button.name);
      }
    }

  }
}
