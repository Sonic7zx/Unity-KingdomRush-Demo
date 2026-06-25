using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour
{
    public GameObject on;
    public GameObject off;
    private Toggle toggle;
    void Start()
    {
        toggle = GetComponent<Toggle>();
        OnValueChanged(toggle.isOn);
    }

    void Update()
    {
        
    }
    public void OnValueChanged(bool isOn)
    {   
        print(isOn);
        on.SetActive(isOn);
        off.SetActive(!isOn);
    }
}
