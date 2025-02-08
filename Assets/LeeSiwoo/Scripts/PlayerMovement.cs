using Cinemachine;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigid;
    [SerializeField]
    private MicInput micInput;
    [SerializeField]
    private CinemachineVirtualCamera cinemachine;

    private Animator animator;

    float _ref = 0.05f;

    private bool isJump = false;

    [HideInInspector]
    public bool GameDone = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameDone) return;
        InputHandler();
    }
    void InputHandler()
    {
        float decibel = micInput.GetDecibel(_ref);
        if (decibel >= 10 && decibel < 20)
        {
            animator.SetBool("isMove", true);
            rigid.AddForce(Vector3.right * 1.1f, ForceMode2D.Force); return;
        }
        else if(decibel >= 20 &&  decibel < 25 && !isJump)
        {
            rigid.AddForce(Vector3.up * 9, ForceMode2D.Impulse);
            isJump = true;
            return;
        }
        else if(decibel >= 25)
        {
            Death();
            return;
        }
		animator.SetBool("isMove", false);
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
	}
    public void Death()
    {
        Debug.Log("Death");
        GameDone = true;
        cinemachine.Follow = null;
    }
}
