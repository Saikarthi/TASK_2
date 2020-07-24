using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LockPanelScript : MonoBehaviour
{
    public TMP_InputField codeField;
    public GameObject LockPanel;
    public GameObject incorrectCode;
    public GameObject VirtualKeyboadrHolder;
    int keyboardOn;
    //Lock Code checker
    public void LockCodeChecker()
    {
        if (codeField.text != null)
        {
            if (codeField.text.Equals("KKHIT") || codeField.text.Equals("MAJPTL"))//Changed the code based on your clients/requirement..
            {
                //start the game 
                SceneManager.LoadScene(1);
                LockPanel.SetActive(false);

            }
            else if (codeField.text.Equals("TAMIL"))//Changed the code based on your clients/requirement..
            {
                //start the game 
                SceneManager.LoadScene(3);
                LockPanel.SetActive(false);

            }
            else
            {
                //wrong pass code
            
                LockPanel.SetActive(true);
                incorrectCode.SetActive(true);
            }
        }
    }
    //Virtual KeyBoard Thing...
    public void VirtualKeyBoard()
    {
        string currentText = EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;


        if (currentText.ToLower() == "clear")
        {
            currentText = null;
            codeField.text = null;
        }
        else
        {
            codeField.text += currentText;

        }
    }
    //show KeyBorad
    public void ShowKeyboard()
    {
        if (keyboardOn == 0)
        {
            VirtualKeyboadrHolder.SetActive(true);
            keyboardOn++;
        }
        else
        {
            VirtualKeyboadrHolder.SetActive(false);
            keyboardOn = 0;
        }

    }
}
