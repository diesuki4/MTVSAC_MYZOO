using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int Affection;
    public int Starvation;
    public int Cleanliness;

    public Action OnChangeCallback;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(OneSecondTick());
        StartCoroutine(TwoSecondTick());
    }


    private IEnumerator OneSecondTick()
    {
        var wait = new WaitForSeconds(1f);

        while (true)
        {
            yield return wait;
            
            if (UIManager.Instance.GameState == GameState.Main)
            {
                Affection -= 1;
                
                
                OnChangeCallback?.Invoke();
            }
        }
    }
    
    private IEnumerator TwoSecondTick()
    {
        var wait = new WaitForSeconds(2f);

        while (true)
        {
            yield return wait;
            
            if (UIManager.Instance.GameState == GameState.Main)
            {
                Starvation -= 1;
                Cleanliness -= 1;
                
                
                OnChangeCallback?.Invoke();
            }
        }
    }
    
    
}
