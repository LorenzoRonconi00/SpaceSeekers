using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    [SerializeField]
    private GameObject climbing1;
    [SerializeField]
    private GameObject climbing2;
    [SerializeField]
    private GameObject spiderweb;

    private player p;

    [SerializeField]
    private GameObject spriteLight;
    [SerializeField]
    private GameObject pointlight;


    void Start()
    {
        p = GameObject.FindWithTag("Player").GetComponent<player>();
        spriteLight.SetActive(false);
        pointlight.SetActive(false);
    }

    
    void Update()
    {
        if (p != null)
        {
            if (p.crystals >= 3)
            {
                StartCoroutine(disablePlants());
                spriteLight.SetActive(true);
                pointlight.SetActive(true);
            }
        }
    }


    IEnumerator disablePlants()
    {
        yield return new WaitForSeconds(1.5f);
        climbing1.SetActive(false);
        climbing2.SetActive(false);
        spiderweb.SetActive(false);
    }
}
