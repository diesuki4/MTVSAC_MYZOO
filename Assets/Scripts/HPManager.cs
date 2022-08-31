using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    public int hp = 100;
    float currentTime;
    public float damageTime = 1; 
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

        hp = Mathf.Clamp(hp, 0, 100);
    }
}
