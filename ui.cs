using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]
    private Text crystalText;

    private player p;

    [SerializeField]
    private GameObject light;
    
    
    void Start()
    {
        p = GameObject.FindWithTag("Player").GetComponent<player>();
        crystalText.text = 0 + "/3";
        light.SetActive(false);
    }

    
    void Update()
    {
        if (p != null)
        {
            crystalText.text = p.crystals + "/3";
        }
        enableLight();
    }

    void enableLight()
    {
        if (p != null)
        {
            if (p.crystals >= 3)
            {
                light.SetActive(true);
            }
        }
    }
}
