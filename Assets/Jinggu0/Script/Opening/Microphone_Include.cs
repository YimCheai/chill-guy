using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Microphone_Include : MonoBehaviour
{
    public GameObject Error_Nomic;
    public GameObject Micmenu;
    public Transform Content;
    // Start is called before the first frame update
    void Start()
    {
        string[] myMic = Microphone.devices;
        if(myMic.Length == 0){
            Error_Nomic.SetActive(true);
        }
        else{
            for(int i=0; i<myMic.Length; i++){
                Instantiate(Micmenu, new Vector3(0, 0, 0), Quaternion.identity, Content);
            }
            Content.GetComponent<Microphone_setname>().Setname();
            PlayerPrefs.SetInt("Micidx", 0);
        }
    }
}
