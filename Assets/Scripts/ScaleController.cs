using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ScaleController : MonoBehaviour
{
    public Slider scaleSlider;

    ARSessionOrigin aRSessionOrigin;


    private void Awake()
    {
        aRSessionOrigin = GetComponent<ARSessionOrigin>();
    }
    // Start is called before the first frame update
    void Start()
    {
        scaleSlider.onValueChanged.AddListener(OnSliderChange);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSliderChange(float value)
    {
        if(scaleSlider != null)
        {
            aRSessionOrigin.transform.localScale = Vector3.one / value;
        }
    }
}
