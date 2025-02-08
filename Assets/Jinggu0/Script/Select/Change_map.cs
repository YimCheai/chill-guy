using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Change_map : MonoBehaviour
{
    public GameObject[] Chillguys = new GameObject[3];
    public GameObject Error_Prev;
    public Sprite[] maps = new Sprite[3];
    public TextMeshProUGUI title;
    Image image;
    int selected = 0;
    string[] stage_name = new string[3];
    void Start()
    {
        image = GetComponent<Image>();

        stage_name[0] = "Stage1";
        stage_name[1] = "Stage2";
        stage_name[2] = "Stage3";
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

    public void Onclick_stage(){
        if(selected == 0){
            SceneManager.LoadScene(stage_name[selected]);
        }
        else if(PlayerPrefs.GetInt("Is"+stage_name[selected-1]) == 1){
            SceneManager.LoadScene(stage_name[selected]);
        }
        else{
            Debug.Log("tlqkf");
            Instantiate(Error_Prev, this.transform.position, Quaternion.identity, this.transform);
        }
    }
}
