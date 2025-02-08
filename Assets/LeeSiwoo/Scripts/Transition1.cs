using DG.Tweening;
using UnityEngine;

public class Transition1 : MonoBehaviour
{
    void Awake()
    {
        transform.DOScale(0.562f, 1f);
        Destroy(gameObject.transform.parent.gameObject, 1f);
    }
}
