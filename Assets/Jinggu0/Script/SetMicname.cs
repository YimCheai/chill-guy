using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetMicname : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string Micname = "Null";
    public int Index = 0;
    // Start is called before the first frame update
    void Start()
    {
        text.text = Micname;
    }

    void Update(){
        if(Micname != text.text){
            text.text = Micname;
        }
    }

    public void Onclick(){
        PlayerPrefs.SetInt("Micidx", Index);
        transform.parent.transform.parent.transform.parent.gameObject.SetActive(false);
    }
}
