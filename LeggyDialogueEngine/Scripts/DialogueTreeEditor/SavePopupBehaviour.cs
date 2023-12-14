using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SavePopupBehaviour : MonoBehaviour
{
    public TMP_InputField nameField;
    public NodeEditor editor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseSavePopup()
    {
        gameObject.SetActive(false);
    }

    public void Save()
    {
        editor.Save(nameField.text);
    }
}
