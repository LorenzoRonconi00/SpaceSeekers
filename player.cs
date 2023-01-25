using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private float _jump = 3f;
    private Animator _anim;
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private Collider2D _collider;
    [SerializeField]
    private bool detect = false;
    private float horizontal;

    public GameObject luce1;
    public GameObject luce2;

    //random light intermission
    private float n;

    //spawn variables
    private float xStart = -6.45f;
    private float yStart = -3.10f;

    
    public int cristals = 0;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        transform.position = new Vector3(xStart, yStart, 0);
    }

    
    void Update()
    {
        if(detect==true && Input.GetKeyDown(KeyCode.Q))
        {
            disableCrouch();
        }
        if (_collider.enabled == false)
        {
            _anim.SetBool("crouch", true);
        }
        if (_collider.enabled == true)
        {
            _anim.SetBool("crouch", false);
        }
        movement();
        jump();
        damage();
        lightIntermission();
    }

    void movement()
    {
        horizontal = Input.GetAxis("Horizontal");
        _anim.SetFloat("speed", Mathf.Abs(horizontal));
        Vector3 move = new Vector3(horizontal, 0f, 0f);
        transform.position += move * Time.deltaTime * _speed; 

        if(!Mathf.Approximately(0, horizontal))
        {
            transform.rotation = horizontal < 0 ? Quaternion.Euler(0, -180, 0) : Quaternion.identity;
        }

        if(transform.position.x <= -8.7f)
        {
            transform.position = new Vector3(-8.7f, transform.position.y, 0);
        }
        if(transform.position.x >= 8.7f)
        {
            transform.position = new Vector3(8.7f, transform.position.y, 0);
        }

        if(transform.position.y <= -30f)
        {
            transform.position = new Vector3(xStart, yStart, 0);
        }
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, _jump), ForceMode2D.Impulse);
            StartCoroutine(jumproutine());
        }
    }

    void enableCrouch()
    {
        _anim.SetBool("crouch", true);
        detect = true;
        _speed = 2f;
        _collider.enabled = false;
    }

    void disableCrouch()
    {
        _anim.SetBool("crouch", false);
        detect = false;
        _speed = 5f;
        _collider.enabled = true;
    }

    void daamge()
    {
        if (Input.GetKey(KeyCode.F))
        {
            _anim.SetBool("hit", true);
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            _anim.SetBool("hit", false);
        }
    }

    void lightIntermission()
    {
        StartCoroutine(lightRoutine());
    }

    public void increaseCristals()
    {
        cristals++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstractionCrouch")
        {
            enableCrouch();
        }
    }

    IEnumerator jumpRoutine()
    {
        _anim.SetBool("jump", true);
        yield return new WaitForSeconds(0.6f);
        _anim.SetBool("jump", false);
    }

    IEnumerator lightRoutine()
    {
        n = Random.Range(1.5f, 3.5f);
        yield return new WaitForSeconds(n);
        luce1.SetActive(false);
        luce2.SetActive(false);
        yield return new WaitForSeconds(n);
        luce1.SetActive(true);
        luce2.SetActive(true);
    }

}
