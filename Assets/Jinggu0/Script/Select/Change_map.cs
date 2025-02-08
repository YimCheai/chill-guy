using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Change_map : MonoBehaviour
{
    public GameObject[] Chillguys = new GameObject[3];
    public Sprite[] maps = new Sprite[3];
    public TextMeshProUGUI title;
    Image image;
    int selected = 0;
    string[] stage_name = new string[3];
    void Start()
    {
        image = GetComponent<Image>();

        stage_name[0] = "STAGE-1";
        stage_name[1] = "STAGE-2";
        stage_name[2] = "STAGE-3";
    }

    // Update is called once per frame
    void Update()
    {
        this.image.sprite = maps[selected];
        title.text = stage_name[selected];
        
        Chillguys[(selected + 0) % 3].SetActive(true);
        Chillguys[(selected + 1) % 3].SetActive(false);
        Chillguys[(selected + 2) % 3].SetActive(false);
    }

    public void Onclick_right(){
        if(selected < 2){
            selected += 1;
        }
    }

    public void Onclick_left(){
        if(selected > 0){
            selected -= 1;
        }
    }
}
