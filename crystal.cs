using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crystal : MonoBehaviour
{

    private Animator anim;

    [SerializeField]
    private Collider2D _collider;

    private void Start()
    {
        anim = GetComponent<Animator>();
        _collider = GetComponent<Collider2D>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player _p = collision.transform.GetComponent<player>();
            if (_p != null)
            {
                _p.aumentaCristalli();
            }
            _collider.enabled = false;
            StartCoroutine(distruggi());
        }
    }

    IEnumerator destroy()
    {
        anim.SetBool("isCollected", true);
        yield return new WaitForSeconds(2.56f);
        Destroy(this.gameObject);
    }

}
