using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsMicsetting : MonoBehaviour
{
    public GameObject Micsetting;
    public void Onclick(){
        Micsetting.SetActive(!Micsetting.activeSelf);
    }
}
