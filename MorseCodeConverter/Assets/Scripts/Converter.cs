using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Converter : MonoBehaviour
{
    SoundManager soundManagerScript;
    public TMPro.TMP_InputField inputField;
    public TMPro.TMP_Text outputText;
    public AudioSource audioSource;

    Dictionary<string, string> latinToMorse;
    private string[] morseArray;
    private bool shouldPlay = false;
    private int currentIndex = 0;
    private int symbolIndex = 0;
    private float symbolTimer = 0.0f;
    private float letterGapTimer = 0.0f;
    private string previousInput = "";
    private bool playNewLetterOnly = false;



    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        CeviriKarsiligi();
        inputField.onValueChanged.AddListener(OnInputValueChanged);
        soundManagerScript = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

   void Update()
    {
        if (!shouldPlay || morseArray == null || morseArray.Length == 0) return;
        

        if (currentIndex >= morseArray.Length)
        {
            StopPlayback();
            return;
        }

        string currentToken = morseArray[currentIndex];

        if (string.IsNullOrEmpty(currentToken))
        {
            letterGapTimer += Time.deltaTime;
            if (letterGapTimer >= 0.6f)
            {
                letterGapTimer = 0f;
                currentIndex++;
            }
        }
        else
        {
            if (symbolIndex < currentToken.Length)
            {
                char currentSymbol = currentToken[symbolIndex];
                float symbolDelay = (currentSymbol == '.') ? 0.2f : (currentSymbol == '-' ? 0.2f : 0.8f);

                symbolTimer += Time.deltaTime;
                if (symbolTimer >= symbolDelay)
                {
                    symbolTimer = 0f;

                    if (currentSymbol == '.')
                    {
                        soundManagerScript.PlayDotSound();
                    }
                    else if (currentSymbol == '-')
                    {
                        soundManagerScript.PlayDashSound();
                    }

                    symbolIndex++;
                }
            }
            else
            {
                letterGapTimer += Time.deltaTime;
                if (letterGapTimer >= 0.6f)
                {
                    letterGapTimer = 0f;
                    currentIndex++;
                    symbolIndex = 0;
                }
            }
        }
    }
     private void OnInputValueChanged(string newValue)
    {
        if (newValue.Length > previousInput.Length)
        {
            string newLetter = newValue[newValue.Length - 1].ToString().ToLower();
            string morseCode = "";
            
            if (latinToMorse.ContainsKey(newLetter))
            {
                morseCode = latinToMorse[newLetter];
                outputText.text += morseCode + " ";
                morseArray = new string[] { morseCode };
                playNewLetterOnly = true;
                StartPlayback();
            }
        }
        previousInput = newValue;
        
        Cevirmeİslemi();
    }
    void ResetTimers()
    {
        currentIndex = 0;
        symbolIndex = 0;
        symbolTimer = 0.0f;
        letterGapTimer = 0.0f;

    }

    public void StartPlayback()
    {
        shouldPlay = true;
       
        ResetTimers();
    }
    public void StopPlayback()
    {
        shouldPlay = false;
        ResetTimers();
    }

    public void Cevirmeİslemi()
    {
        if (!playNewLetterOnly)
        {
       
            string latinCharacter = inputField.text.ToLower(); 
            string sonuc = ""; 
        

            for (int i = 0; i < latinCharacter.Length ; i++) 
            {
                string harf = latinCharacter[i].ToString();

                if (harf == " ")
                {
                    sonuc += " ";
                }
                else if (latinToMorse.ContainsKey(harf))
                {
                    sonuc += latinToMorse[harf] + " ";
                }
            
            }
            outputText.text = sonuc;
            
        }
        playNewLetterOnly = false;
    }

    void CeviriKarsiligi()
    {
       latinToMorse = new Dictionary<string, string>()
        {
            {"a", ".-"}, {"b", "-..."}, {"c", "-.-."}, {"d", "-.."}, {"e", "."},
            {"f", "..-."}, {"g", "--."}, {"h", "...."}, {"i", ".."}, {"j", ".---"},
            {"k", "-.-"}, {"l", ".-.."}, {"m", "--"}, {"n", "-."}, {"o", "---"},
            {"p", ".--."}, {"q", "--.-"}, {"r", ".-."}, {"s", "..."}, {"t", "-"},
            {"u", "..-"}, {"v", "...-"}, {"w", ".--"}, {"x", "-..-"}, {"y", "-.--"},
            {"z", "--.."}, {"1", ".----"}, {"2", "..---"}, {"3", "...--"}, {"4", "....-"},
            {"5", "....."}, {"6", "-...."}, {"7", "--..."}, {"8", "---.."}, {"9", "----."},
            {"0", "-----"}
        };
    }
  
 

}