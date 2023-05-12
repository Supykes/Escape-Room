using UnityEngine;
using TMPro;
using System;

public class ButtonsInteraction : MonoBehaviour
{
    public enum ButtonType
    {
        CombinationLockNumber,
        CombinationLockSubmit,
        KeypadNumber,
        KeypadClear,
        KeypadSubmit
    }

    public ButtonType buttonType;
    public int keypadNumber;
    public int combinationLockButtonPosition;
    public TMP_Text keypadNumbersText;
    public TMP_Text combinationLockNumberText;
    public GameObject keypadDoor;
    public GameObject combinationLockDoor;
    public GameObject keypad;
    public GameObject combinationLock;
    CabinetAnimation keypadDoorAnimation;
    CabinetAnimation combinationLockDoorAnimation;
    string keypadCorrectCode = "1234";
    string combinationLockCorrectCode = "1234";
    static string keypadCurrentCode = "";
    static string combinationLockCurrentCode = "0000";
    char[] combinationLockCurrentCodeSymbols;
    int combinationLockNumber = 0;

    void Start()
    {
        if (buttonType == ButtonType.KeypadNumber || buttonType == ButtonType.KeypadClear || buttonType == ButtonType.KeypadSubmit)
        {
            keypadDoorAnimation = keypadDoor.GetComponent<CabinetAnimation>();
        }
        else if (buttonType == ButtonType.CombinationLockNumber || buttonType == ButtonType.CombinationLockSubmit)
        {
            combinationLockDoorAnimation = combinationLockDoor.GetComponent<CabinetAnimation>();
        }
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
        else if (buttonType == ButtonType.KeypadNumber)
        {
            if (keypadCurrentCode.Length < 4)
            {
                keypadCurrentCode += keypadNumber;

                keypadNumbersText.text = keypadCurrentCode;
            }
        }
        else if (buttonType == ButtonType.KeypadClear)
        {
            keypadCurrentCode = "";

            keypadNumbersText.text = keypadCurrentCode;
        }
        else if (buttonType == ButtonType.KeypadSubmit)
        {
            if (keypadCurrentCode == keypadCorrectCode)
            {
                keypadDoorAnimation.PlayAnimation();

                DisableButtonsInteraction(keypad);
            }
            else
            {
                keypadCurrentCode = "";

                keypadNumbersText.text = keypadCurrentCode;
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