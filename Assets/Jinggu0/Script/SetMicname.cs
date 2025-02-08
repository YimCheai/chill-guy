using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetMicname : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string Micname = "Null";
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
}
