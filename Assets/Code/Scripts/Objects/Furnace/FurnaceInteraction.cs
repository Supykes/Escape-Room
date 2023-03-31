using UnityEngine;
using System.Collections;
using TMPro;

public class FurnaceInteraction : MonoBehaviour
{
    public GameObject itemTransform;
    public GameObject metal1, metal2, metal3;
    public GameObject upperDoor;
    public GameObject canvas;
    public TMP_Text timerText;
    GameObject pickedUpItem = null;
    bool requiredItem = false;
    FurnaceAnimation furnaceAnimation;
    public static bool startTimer = false;
    float timeRemaining = 6f;

    void Start()
    {
        furnaceAnimation = upperDoor.GetComponent<FurnaceAnimation>();

        canvas.SetActive(false);
    }

    void Update()
    {
        GetChild();
        CheckRequiredItem();

        CountTime();
    }

    void GetChild()
    {
        if (itemTransform.transform.childCount > 0)
        {
            pickedUpItem = itemTransform.transform.GetChild(0).gameObject;
        }
        else
        {
            pickedUpItem = null;
        }
    }

    void CheckRequiredItem()
    {
        if (pickedUpItem != null && (pickedUpItem.name == "Raw material 1" || pickedUpItem.name == "Raw material 2" || pickedUpItem.name == "Raw material 3"))
        {
            requiredItem = true;
        }
        else
        {
            requiredItem = false;
        }
    }

    IEnumerator SpawnMetal(GameObject metal, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        metal.SetActive(true);

        startTimer = false;
    }

    IEnumerator OpenFurnace(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        furnaceAnimation.PlayAnimation();

        canvas.SetActive(false);
    }

    public void ProcessRawMaterial()
    {
        if (requiredItem)
        {
            if (pickedUpItem.name == "Raw material 1")
            {
                Destroy(pickedUpItem);
                StartCoroutine(OpenFurnace(4.9f));
                StartCoroutine(SpawnMetal(metal1, 5f));

                startTimer = true;

                canvas.SetActive(true);
            }
            else if (pickedUpItem.name == "Raw material 2")
            {
                Destroy(pickedUpItem);
                StartCoroutine(OpenFurnace(4.9f));
                StartCoroutine(SpawnMetal(metal2, 5f));

                startTimer = true;

                canvas.SetActive(true);
            }
            else if (pickedUpItem.name == "Raw material 3")
            {
                Destroy(pickedUpItem);
                StartCoroutine(OpenFurnace(4.9f));
                StartCoroutine(SpawnMetal(metal3, 5f));

                startTimer = true;

                canvas.SetActive(true);
            }
        }
    }

    void CountTime()
    {
        if (startTimer)
        {
            float seconds;

            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                seconds = Mathf.FloorToInt(timeRemaining % 60);

                timerText.text = seconds + " s";
            }
        }
        else
        {
            timeRemaining = 6f;
        }
    }
}