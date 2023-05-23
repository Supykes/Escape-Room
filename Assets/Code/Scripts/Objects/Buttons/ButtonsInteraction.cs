using UnityEngine;
using TMPro;
using System;

public class ButtonsInteraction : MonoBehaviour
{
    public enum ButtonType
    {
        KeypadNumber,
        KeypadClear,
        KeypadSubmit,
        CombinationLockNumber,
        CombinationLockSubmit,
        CombinationLockBoxNumber,
        CombinationLockBoxSubmit
    }

    public ButtonType buttonType;
    public int keypadNumber;
    public int combinationLockButtonPosition;
    public TMP_Text keypadNumbersText;
    public TMP_Text combinationLockNumberText;
    public GameObject keypadDoor;
    public GameObject combinationLockDoor;
    public GameObject combinationLockBoxTop;
    public GameObject keypad;
    public GameObject combinationLock;
    CabinetAnimation keypadDoorAnimation;
    CabinetAnimation combinationLockDoorAnimation;
    string keypadCorrectCode = "3975";
    string combinationLockCorrectCode = "5147";
    string combinationLockBoxCorrectCode = "6208";
    static string keypadCurrentCode = "";
    static string combinationLockCurrentCode = "0000";
    static string combinationLockBoxCurrentCode = "0000";
    char[] combinationLockCurrentCodeSymbols;
    char[] combinationLockBoxCurrentCodeSymbols;
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
            HandleCombinationLockNumbersBehaviour(ref combinationLockCurrentCode, combinationLockCurrentCodeSymbols);
        }
        else if (buttonType == ButtonType.CombinationLockBoxNumber)
        {
            HandleCombinationLockNumbersBehaviour(ref combinationLockBoxCurrentCode, combinationLockBoxCurrentCodeSymbols);
        }
        else if (buttonType == ButtonType.CombinationLockSubmit)
        {
            if (combinationLockCurrentCode == combinationLockCorrectCode)
            {
                combinationLockDoorAnimation.PlayAnimation();

                DisableButtonsInteraction(combinationLock);
            }
        }
        else if (buttonType == ButtonType.CombinationLockBoxSubmit)
        {
            if (combinationLockBoxCurrentCode == combinationLockBoxCorrectCode)
            {
                Destroy(combinationLockBoxTop);
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
        }
    }

    void HandleCombinationLockNumbersBehaviour(ref string currentCode, char[] currentCodeSymbols)
    {
        if (combinationLockNumber == 9)
        {
            combinationLockNumber = -1;
        }

        combinationLockNumber++;

        combinationLockNumberText.text = combinationLockNumber.ToString();

        FormCombinationLockCurrentCode(ref currentCode, currentCodeSymbols);
    }

    void FormCombinationLockCurrentCode(ref string currentCode, char[] currentCodeSymbols)
    {
        currentCodeSymbols = currentCode.ToCharArray();
        currentCodeSymbols[combinationLockButtonPosition] = Convert.ToChar(combinationLockNumberText.text);
        currentCode = new string(currentCodeSymbols);
    }

    void DisableButtonsInteraction(GameObject lockType)
    {
        foreach (Transform child in lockType.transform)
        {
            child.transform.tag = "Untagged";
        }
    }
}