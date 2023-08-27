using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
using TMPro;

public class PostProcessControl : MonoBehaviour
{
    [SerializeField] private PostProcessVolume _postProcessVolume;
    public Toggle toggle;
    public TMP_Text text;


    void Awake(){
        toggle = GameObject.Find("PostProcessing").GetComponent<Toggle>();
        _postProcessVolume = GameObject.FindGameObjectWithTag("Camera").GetComponent<PostProcessVolume>();
    }

    public void Start(){
        _postProcessVolume.enabled = !_postProcessVolume.enabled;
    }
    public void Update(){

        if (toggle.isOn){
            text.color = Color.green;
        }

        if (!toggle.isOn){
            text.color = Color.red;
        }
    }
}
