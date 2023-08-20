using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessControl : MonoBehaviour
{
[SerializeField] private PostProcessVolume _postProcessVolume;

    void Awake(){
        _postProcessVolume = GameObject.FindGameObjectWithTag("Camera").GetComponent<PostProcessVolume>();
    }

    public void Start(){
        _postProcessVolume.enabled = !_postProcessVolume.enabled;
    }
}
