using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfFullHeart;
    public Sprite emptyHeart;
    public Sprite aQuarterOfAHeart;
    public Sprite threeQuartersOfAHeart;
    public FloatValue heartContainers;
    public FloatValue playerCurrentHealth;


    // Start is called before the first frame update
    void Start()
    {
        InitHearts();
    }

    public void InitHearts()
    {
        for (int i = 0; i < heartContainers.initialValue; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = fullHeart;
        }
    }
    public void UpdateHearts()
    {
        float tempHealth = playerCurrentHealth.RuntimeValue / 2;
        for (int i = 0; i < heartContainers.initialValue; i++)
        {
            if (i <= tempHealth-1)
            {
                //Full Heart
                hearts[i].sprite = fullHeart;
            }
            else if (i >= tempHealth)
            {
                //Empty Heart
                hearts[i].sprite = emptyHeart;
            }
            //else if ()
            //{
            //    //A Quarter Of A Heart
            //    hearts[i].sprite = aQuarterOfAHeart;
            //}
            //else if ()
            //{
            //    //Three Quarters Of A Heart
            //    hearts[i].sprite = threeQuartersOfAHeart;
            //}
            else
            {
                //Half Full Heart
                hearts[i].sprite = halfFullHeart;
            }
        }
    }
}
