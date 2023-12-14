using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

public class OpenPopupBehaviour : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public NodeEditor editor;
    void PopulateDropdown()
    {
        dropdown.options.Clear();
        string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(),"*.dtree");
        foreach(string file in files)
        {
            TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData();
            optionData.text = file.Split("\\").Last() ;
            dropdown.options.Add(optionData);
        }
    }

    public void OnConfirm()
    {
        editor.LoadTree(dropdown.options[dropdown.value].text);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }


    // Start is called before the first frame update
    void Start()
    {
        PopulateDropdown();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
