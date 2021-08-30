using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetName : MonoBehaviour
{
    [SerializeField] PlayerBase playerData;
    [SerializeField] Text nameField;
    [SerializeField] Text nameDisplay;
    [SerializeField] string playerName;


    public void SetPlayerName()
    {
        if(nameField.text == "")
        {
            playerName = playerData.Name;
            nameDisplay.GetComponent<Text>().text = playerName;
        }
        else
        {

        
        string playerName = nameField.text.ToString();
        playerData.Name = playerName;

        nameDisplay.GetComponent<Text>().text = playerName;
        }
    }
}
