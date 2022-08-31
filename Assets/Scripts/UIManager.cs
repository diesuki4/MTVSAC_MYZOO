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

    public void OnClickPlayBtn(HPManager hpManager)
    {
        hpManager.hp += 20;
    }
}
