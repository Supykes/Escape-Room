using UnityEngine;
using System.Collections;
using TMPro;

public class FurnaceInteraction : MonoBehaviour
{
    public GameObject itemTransform;
    public GameObject goldBar, cobaltBar, galliumBar;
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
        if (pickedUpItem != null && (pickedUpItem.name == "Gold" || pickedUpItem.name == "Cobalt" || pickedUpItem.name == "Gallium"))
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
        metal.GetComponent<Rigidbody>().AddForce(Vector3.back * 2f, ForceMode.Impulse);

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
            if (pickedUpItem.name == "Gold")
            {
                Destroy(pickedUpItem);
                StartCoroutine(OpenFurnace(4.9f));
                StartCoroutine(SpawnMetal(goldBar, 5f));

                startTimer = true;

                canvas.SetActive(true);
            }
            else if (pickedUpItem.name == "Cobalt")
            {
                Destroy(pickedUpItem);
                StartCoroutine(OpenFurnace(4.9f));
                StartCoroutine(SpawnMetal(cobaltBar, 5f));

                startTimer = true;

                canvas.SetActive(true);
            }
            else if (pickedUpItem.name == "Gallium")
            {
                Destroy(pickedUpItem);
                StartCoroutine(OpenFurnace(4.9f));
                StartCoroutine(SpawnMetal(galliumBar, 5f));

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