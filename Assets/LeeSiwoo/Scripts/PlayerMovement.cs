using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigid;
    [SerializeField]
    private MicInput micInput;
    [SerializeField]
    private CinemachineVirtualCamera cinemachine;
    [SerializeField]
    private float Speed;
    [SerializeField]
    private GameObject SaveEffect;
    [SerializeField]
    private GameObject NextSceneChanger;

    public int count;

    private string PointName;

    private Vector3 RespawnPos;

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

	private void FixedUpdate()
	{
		if (GameDone) return;
		InputHandler();
	}
	void InputHandler()
    {
        float decibel = micInput.GetDecibel(_ref);
        if (decibel >= 7 && decibel < 15)
        {
            animator.SetBool("isMove", true);
            rigid.velocity = new Vector2(Speed, rigid.velocity.y); return;
        }
        else if(decibel >= 15 &&  decibel < 20 && !isJump)
        {
            rigid.AddForce(Vector3.up * 9, ForceMode2D.Impulse);
            isJump = true;
            return;
        }
        else if(decibel >= 20)
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
        if (collision.gameObject.CompareTag("Spike"))
        {
            Death();
        }
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (!GameDone)
        {
			if (collision.CompareTag("SavePoint"))
			{
				RespawnPos = collision.gameObject.transform.position;
				if (PointName != collision.gameObject.name)
				{
					GameObject clone = Instantiate(SaveEffect, RespawnPos, Quaternion.identity);
					Destroy(clone, 0.8f);
					PointName = collision.gameObject.name;
				}
			}
			else if (collision.gameObject.name.Equals("EndCollider"))
			{
                StartCoroutine(Nigga());
			}
		}
	}
	public void Death()
    {
        Debug.Log("Death");
        GameDone = true;
        cinemachine.Follow = null;
        Invoke("Respawn", 0.7f);
    }
    private void Respawn()
    {
        GameDone = false;
        cinemachine.Follow = this.gameObject.transform;
        transform.position = RespawnPos;
    }
    private IEnumerator Nigga()
    {
        count++;
        GameDone = true;
        Instantiate(NextSceneChanger, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        string name = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetInt("Is"+name, 1);
        SceneManager.LoadScene(name.Remove(name.Length-1) + count);
    }
}
