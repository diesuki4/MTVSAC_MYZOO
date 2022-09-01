using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    bool isAgressive;
    bool isDie;

    public GameObject StateGood;
    public GameObject StateNormal;
    public GameObject StateBad;

    public Animator anim;

    public Text hpText;

    public string type;

    // Start is called before the first frame update
    void Start()
    {
        isAgressive = true;
        isDie = true;
    }

    // Update is called once per frame
    void Update()
    {
        int hp = 0;

        switch (type)
        {
            case "Affection":
                hp = GameManager.Instance.Affection;
                break;
            case "Starvation":
                hp = GameManager.Instance.Starvation;
                break;
            case "Cleanliness":
                hp = GameManager.Instance.Cleanliness;
                break;
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
            if(isAgressive == true)
            {
                anim.SetTrigger("Agressive");
                isAgressive = false;
            }
            if(hp <= 0 && isDie == true)
            {
                anim.SetTrigger("Die");
                isDie = false;
            }
        }
        else
        {
            StateGood.SetActive(false);
            StateNormal.SetActive(true);
            StateBad.SetActive(false);
        }
  
        hp = Mathf.Clamp(hp, 0, 100);

        switch (type)
        {
            case "Affection":
                GameManager.Instance.Affection = hp;
                break;
            case "Starvation":
                GameManager.Instance.Starvation = hp;
                break;
            case "Cleanliness":
                GameManager.Instance.Cleanliness = hp;
                break;
        }

        hpText.text = hp + "%";
    }
}
