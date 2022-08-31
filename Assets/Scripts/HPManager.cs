using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    public int hp = 100;
    float currentTime;
    public float damageTime = 1;

    public GameObject StateGood;
    public GameObject StateNormal;
    public GameObject StateBad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > damageTime)
        {
            hp--;
            currentTime = 0;        
        }
        if(hp >= 70)
        {
            StateGood.SetActive(true);
            StateNormal.SetActive(false);
            StateBad.SetActive(false);
        }
        else if (hp < 30)
        {
            StateGood.SetActive(false);
            StateNormal.SetActive(false);
            StateBad.SetActive(true);
        }
        else
        {
            StateGood.SetActive(false);
            StateNormal.SetActive(true);
            StateBad.SetActive(false);
        }
        hp = Mathf.Clamp(hp, 0, 100);
    }
}
