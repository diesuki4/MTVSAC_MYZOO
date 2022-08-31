using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void OnClickPlayBtn(int index)
    {
        hpManagers[index].hp += 20;
        StartCoroutine(IECoolTime(buttons[index]));
    }

    IEnumerator IECoolTime(GameObject button)
    {
        button.SetActive(false);
        yield return new WaitForSeconds(coolTime);
        button.SetActive(true);
    }
}
