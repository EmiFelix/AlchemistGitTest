using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessModify : MonoBehaviour
{
    [SerializeField] private PostProcessVolume ppVolume;
    private Bloom _bloom;
    private void Awake()
    {

    }

    private void Start()
    {
        
    }


    private void BloomChangeIntensity()
    {
        var bloomOnOff = ppVolume.profile.TryGetSettings(out _bloom);
        
        if (bloomOnOff)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                _bloom.intensity.value--;
            }
            
            if (Input.GetKeyDown(KeyCode.B))
            {
                _bloom.intensity.value++;
            }

        }

    }


    private void Update()
    {
        BloomChangeIntensity();
    }

}    
