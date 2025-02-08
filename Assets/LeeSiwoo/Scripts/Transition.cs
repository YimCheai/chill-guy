using DG.Tweening;
using UnityEngine;

public class Transition : MonoBehaviour
{
    void Awake()
    {
        transform.DOScale(0f, 1f);
    }
}
