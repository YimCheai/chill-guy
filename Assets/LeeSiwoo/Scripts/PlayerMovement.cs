using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigid;
    [SerializeField]
    private MicInput micInput;

    float _ref = 0.05f;

    private bool isJump = false;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        InputHandler();
    }
    void InputHandler()
    {
        float decibel = micInput.GetDecibel(_ref);
        if (decibel >= 12 && decibel < 18)
        {
            rigid.AddForce(Vector3.right, ForceMode2D.Force);
        }
        else if(decibel >= 18 &&  decibel < 22 && !isJump)
        {
            rigid.AddForce(Vector3.up * 10, ForceMode2D.Impulse);
            isJump = true;
        }
        else if(decibel >= 25)
        {
            Debug.Log("Death");
        }
    }
	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
	}
}
