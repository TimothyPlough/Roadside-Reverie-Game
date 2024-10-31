using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsSlider : MonoBehaviour
{

    [SerializeField] private Slider slider;

    // Start is called before the first frame update
    void Start()
    {

        slider.onValueChanged.AddListener((value) =>
        {
            FindObjectOfType<AudioManager>().SetVolume("EveningTheme", value);
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
