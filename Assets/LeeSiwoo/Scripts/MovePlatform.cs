using DG.Tweening;
using System.Security.Cryptography;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public Vector3 a;
    public Vector3 b;
    void Start()
    {
        transform.position = a;
		transform.DOMove(b, 3).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
	}
}
