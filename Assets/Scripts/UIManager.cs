using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject startScene;
    public GameObject cameraScene;
    public GameObject modellingScene;
    public GameObject gameScene;
    public GameObject HistoryScene;

    public GameObject Cat;

    public HPManager[] hpManagers;
    public GameObject[] buttons;
    public Image[] disabled;

    public float coolTime = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PressButtonToCamera()
    {
        startScene.SetActive(false);
        cameraScene.SetActive(true);
    }

    public void PressButtonToSave()
    {
        cameraScene.SetActive(false);
        modellingScene.SetActive(true);
    }

    public void PressButtonToGame()
    {
        modellingScene.SetActive(false);
        gameScene.SetActive(true);
        Cat.SetActive(true);
    }

    public void PressButtonToBack()
    {
        modellingScene.SetActive(false);
        cameraScene.SetActive(true);
    }

    public void OnClickPlayBtn(string strIdx)
    {
        int btnIdx = strIdx[0] - '0', imgIdx = strIdx[1] - '0';

        hpManagers[btnIdx].hp += 20;
        StartCoroutine(IECoolTime(buttons[imgIdx], disabled[imgIdx]));
    }

    IEnumerator IECoolTime(GameObject button, Image imageDisabled)
    {
        float t = 0;

        button.SetActive(false);

        while ((t += Time.deltaTime) < coolTime)
        {
            imageDisabled.fillAmount = t / coolTime;

            yield return null;
        }

        button.SetActive(true);
    }
}