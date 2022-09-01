using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    Intro,
    Start,
    Camera,
    Lobby,
    Main,
}

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private GameState m_GameState = GameState.Intro;
    public GameState GameState => m_GameState;
    


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        RefreshUI();

    }

    public void SetGameState(GameState state)
    {
        if (m_GameState == state)
        {
            return;
        }

        m_GameState = state;
        
        RefreshUI();
    }
    
    private void RefreshUI()
    {
        UI_Intro.Instance.Hide();
        UI_Start.Instance.Hide();
        UI_Camera.Instance.Hide();
        UI_Lobby.Instance.Hide();
        UI_Main.Instance.Hide();
        
        switch (m_GameState)
        {
            case GameState.Intro:
                UI_Intro.Instance.Show();
                break;
            
            case GameState.Start:
                UI_Start.Instance.Show();
                break;
            
            case GameState.Camera:
                UI_Camera.Instance.Show();
                break;
            
            case GameState.Lobby:
                UI_Lobby.Instance.Show();
                break;
            
            case GameState.Main:
                UI_Main.Instance.Show();
                break;
        }
    }
    
    
    
    
    public GameObject startScene;
    public GameObject cameraScene;
    public GameObject modellingScene;
    public GameObject gameScene;
    public GameObject HistoryScene;

    public GameObject Cat;

    public Animator anim;

    public HPManager[] hpManagers;
    public GameObject[] buttons;

    public float coolTime = 10;
    

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

    public void OnClickPlayBtn(int idx)
    {
        switch (idx)
        {
            case 0 :
                GameManager.Instance.Affection += 20;
                break;
            case 1 :
                GameManager.Instance.Starvation += 20;
                break;
            case 2 :
                GameManager.Instance.Affection += 20;
                break;
            case 3:
                GameManager.Instance.Cleanliness += 20;
                break;
        }

        StartCoroutine(IECoolTime(buttons[idx]));

        // walk
        if(idx == 0)
        {
            anim.SetTrigger("Jump");
        }
        // feed
        if (idx == 1)
        {
            anim.SetTrigger("Feed");
        }
        // scratch
        if (idx == 2)
        {
            anim.SetTrigger("Scratch");
        } 
        // wash
        if (idx == 3)
        {
            anim.SetTrigger("Wash");
        }
    }

    IEnumerator IECoolTime(GameObject button)
    {
        float t = 0;

        button.GetComponent<Button>().enabled = false;

        while ((t += Time.deltaTime) <= coolTime)
        {
            button.GetComponent<Image>().fillAmount = t / coolTime;

            yield return null;
        }

        button.GetComponent<Button>().enabled = true;
    }
}