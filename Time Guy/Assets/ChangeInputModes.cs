using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeInputModes : MonoBehaviour
{
    public Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {
        dropdown = gameObject.GetComponent<Dropdown>();
        PlayerPrefs.SetInt("InputMode", dropdown.value);
    }

    void OnValueChange()
    {
        PlayerPrefs.SetInt("InputMode", dropdown.value);
    }
}
