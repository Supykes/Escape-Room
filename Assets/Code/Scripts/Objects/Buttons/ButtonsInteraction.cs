using UnityEngine;
using TMPro;
using System;

public class ButtonsInteraction : MonoBehaviour
{
    public enum ButtonType
    {
        CombinationLockNumber,
        CombinationLockSubmit
    }

    public ButtonType buttonType;
    public int combinationLockButtonPosition;
    public TMP_Text combinationLockNumberText;
    public GameObject combinationLockDoor;
    public GameObject combinationLock;
    CabinetAnimation combinationLockDoorAnimation;
    string combinationLockCorrectCode = "1234";
    static string combinationLockCurrentCode = "0000";
    char[] combinationLockCurrentCodeSymbols;
    int combinationLockNumber = 0;

    void Start()
    {
        combinationLockDoorAnimation = combinationLockDoor.GetComponent<CabinetAnimation>();
    }

    public void HandleButtonBehaviour()
    {
        if (buttonType == ButtonType.CombinationLockNumber)
        {
            if (combinationLockNumber == 9)
            {
                combinationLockNumber = -1;
            }

            combinationLockNumber++;

            combinationLockNumberText.text = combinationLockNumber.ToString();

            FormCombinationLockCurrentCode();
        }
        else if (buttonType == ButtonType.CombinationLockSubmit)
        {
            if (combinationLockCurrentCode == combinationLockCorrectCode)
            {
                combinationLockDoorAnimation.PlayAnimation();

                DisableButtonsInteraction(combinationLock);
            }
        }
    }

    void FormCombinationLockCurrentCode()
    {
        combinationLockCurrentCodeSymbols = combinationLockCurrentCode.ToCharArray();
        combinationLockCurrentCodeSymbols[combinationLockButtonPosition] = Convert.ToChar(combinationLockNumberText.text);
        combinationLockCurrentCode = new string(combinationLockCurrentCodeSymbols);
    }

    void DisableButtonsInteraction(GameObject lockType)
    {
        foreach (Transform child in lockType.transform)
        {
            child.transform.tag = "Untagged";
        }
    }
}