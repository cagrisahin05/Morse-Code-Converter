using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Converter : MonoBehaviour
{
    Dictionary<string, string> latinToMorse;
    SoundManager soundManagerScript;
    public TMPro.TMP_InputField inputField;
    public TMPro.TMP_Text outputText;
    public AudioSource audioSource;

    private string[] morseArray;
    
    private int currentIndex = 0;
    private int symbolIndex = 0;
    private float symbolTimer = 0.0f;
    private float letterGapTimer = 0.0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        CeviriKarsiligi();
        inputField.onValueChanged.AddListener(delegate { Cevirmeİslemi(); });
        soundManagerScript = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }
   void Update()
    {
        if (morseArray == null || morseArray.Length == 0)
            return;

        
        if (currentIndex < morseArray.Length)
        {
            string currentToken = morseArray[currentIndex];

        
            if (string.IsNullOrEmpty(currentToken))
            {
                letterGapTimer += Time.deltaTime;
                if (letterGapTimer >= 0.3f)
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
                    float symbolDelay = (currentSymbol == '.') ? 0.1f : (currentSymbol == '-' ? 0.4f : 0.1f);

                    symbolTimer += Time.deltaTime;
                    if (symbolTimer >= symbolDelay)
                    {
                        symbolTimer = 0f;

                        // Play the corresponding sound from SoundManager.
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
                    if (letterGapTimer >= 0.3f)
                    {
                        letterGapTimer = 0f;
                        currentIndex++;
                        symbolIndex = 0;
                    }
                }
            }
        }
    }


    void Cevirmeİslemi()
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
        morseArray = sonuc.Split(' ');
        currentIndex = 0;
        symbolIndex = 0;
        symbolTimer = 0.0f;
        letterGapTimer = 0.0f;
       
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