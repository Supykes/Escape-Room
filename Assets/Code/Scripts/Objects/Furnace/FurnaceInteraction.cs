using UnityEngine;
using System.Collections;

public class FurnaceInteraction : MonoBehaviour
{
    public GameObject itemTransform;
    public GameObject metal1, metal2, metal3;
    GameObject pickedUpItem = null;
    bool requiredItem = false;
    bool startTimer = false;
    float timeRemaining = 6f;

    void Update()
    {
        GetChild();
        CheckRequiredItem();

        StartTimer();
    }

    void GetChild()
    {
        if (itemTransform.transform.childCount > 0)
        {
            pickedUpItem = itemTransform.transform.GetChild(0).gameObject;
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

    public void ProcessRawMaterial()
    {
        if (requiredItem)
        {
            if (pickedUpItem.name == "Raw material 1")
            {
                startTimer = true;

                Destroy(pickedUpItem);
                StartCoroutine(SpawnMetal(metal1, 5f));
            }
            else if (pickedUpItem.name == "Raw material 2")
            {
                startTimer = true;

                Destroy(pickedUpItem);
                StartCoroutine(SpawnMetal(metal2, 5f));
            }
            else if (pickedUpItem.name == "Raw material 3")
            {
                startTimer = true;

                Destroy(pickedUpItem);
                StartCoroutine(SpawnMetal(metal3, 5f));
            }
        }
    }

    void StartTimer()
    {
        float seconds;
        if (startTimer)
        {
            if (timeRemaining >= 0)
            {
                timeRemaining -= Time.deltaTime;
                Debug.Log(seconds = Mathf.FloorToInt(timeRemaining % 60));
            }
        }
        else
        {
            timeRemaining = 6f;
        }
    }
}