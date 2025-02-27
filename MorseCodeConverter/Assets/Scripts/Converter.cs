using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Converter : MonoBehaviour
{

    Dictionary<string, string> latinToMorse;
    public TMPro.TMP_InputField inputField;
    public TMPro.TMP_Text outputText;

    void Start()
    {
        CeviriKarsiligi();
        inputField.onEndEdit.AddListener(delegate { if (Input.GetKeyDown(KeyCode.Return)) Cevirmeİslemi(); });
    }


    void Cevirmeİslemi()
    {
        string latinCharacter = inputField.text.ToLower();
        string sonuc = "";
        

        for (int i = 0; i < latinCharacter.Length ; i++)
        {
            string harf = latinCharacter[i].ToString(); 
            if (latinToMorse.TryGetValue(harf, out string morseTranslation))
            {
                sonuc += morseTranslation;

            }
            else
            {
                sonuc += "Gecersiz";

            }
        
        }
        outputText.text = sonuc;
    }

    void CeviriKarsiligi()
    {
        latinToMorse = new Dictionary<string, string>();
        latinToMorse.Add("a", ".-");
        latinToMorse.Add("b", "-...");
        latinToMorse.Add("c", "-.-.");
        latinToMorse.Add("d", "-..");
        latinToMorse.Add("e", ".");
        latinToMorse.Add("f", "..-.");
        latinToMorse.Add("g", "--.");
        latinToMorse.Add("h", "....");
        latinToMorse.Add("i", "..");
        latinToMorse.Add("j", ".---");
        latinToMorse.Add("k", "-.-");
        latinToMorse.Add("l", ".-..");
        latinToMorse.Add("m", "--");
        latinToMorse.Add("n", "-.");
        latinToMorse.Add("o", "---");
        latinToMorse.Add("p", ".--.");
        latinToMorse.Add("q", "--.-");
        latinToMorse.Add("r", ".-.");
        latinToMorse.Add("s", "...");
        latinToMorse.Add("t", "-");
        latinToMorse.Add("u", "..-");
        latinToMorse.Add("v", "...-");
        latinToMorse.Add("w", ".--");
        latinToMorse.Add("x", "-..-");
        latinToMorse.Add("y", "-.--");
        latinToMorse.Add("z", "--..");
        latinToMorse.Add("1", ".----");
        latinToMorse.Add("2", "..---");
        latinToMorse.Add("3", "...--");
        latinToMorse.Add("4", "....-");
        latinToMorse.Add("5", ".....");
        latinToMorse.Add("6", "-....");
        latinToMorse.Add("7", "--...");
        latinToMorse.Add("8", "---..");
        latinToMorse.Add("9", "----.");
        latinToMorse.Add("0", "-----");
        latinToMorse.Add(" ", " ");
    }


}
