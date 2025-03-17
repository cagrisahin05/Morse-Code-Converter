using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Converter : MonoBehaviour
{
    private SoundManager soundManagerScript;
    public TMP_InputField inputField;
    public TMP_Text outputText;

    private Dictionary<string, string> latinToMorse;
    private string[] morseArray;
    private Queue<string> letterQueue = new Queue<string>();

    private int currentIndex = 0;
    private int symbolIndex = 0;
    private float symbolTimer = 0.0f;
    private float letterGapTimer = 0.0f;

    private bool shouldPlay = false;
    private bool isCurrentlyPlaying = false;
    private bool isPlayingLetter = false;
    private bool playNewLetterOnly = false;

    private float dotDuration = 0.2f;
    private float dashDuration = 0.5f;
    private float symbolGap = 0.2f;
    private string previousInput = "";

    void Start()
    {
        InitializeMorseDictionary();
        inputField.onValueChanged.AddListener(OnInputValueChanged);
        soundManagerScript = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    void Update()
    {
        if (!shouldPlay || morseArray == null || morseArray.Length == 0) return;

        HandleMorsePlayback();
    }

    private void OnInputValueChanged(string newValue)
    {
        if (newValue.Length > previousInput.Length)
        {
            string newLetter = newValue[newValue.Length - 1].ToString().ToLower();

            if (latinToMorse.ContainsKey(newLetter))
            {
                string morseCode = latinToMorse[newLetter];
                outputText.text += morseCode + " ";

                letterQueue.Enqueue(morseCode);

                if (!isPlayingLetter)
                {
                    PlayNextLetter();
                }
            }
        }

        previousInput = newValue;
        UpdateMorseOutput();
    }

    private void HandleMorsePlayback()
    {
        if (isCurrentlyPlaying)
        {
            symbolTimer += Time.deltaTime;
            float currentDuration = morseArray[currentIndex][symbolIndex] == '.' ? dotDuration : dashDuration;

            if (symbolTimer >= currentDuration)
            {
                symbolTimer = 0;
                symbolIndex++;

                if (symbolIndex >= morseArray[currentIndex].Length)
                {
                    symbolIndex = 0;
                    currentIndex++;

                    if (currentIndex >= morseArray.Length)
                    {
                        FinishCurrentLetter();
                    }
                    else
                    {
                        letterGapTimer = 0;
                        isCurrentlyPlaying = false;
                    }
                }
                else
                {
                    isCurrentlyPlaying = false;
                }
            }
        }
        else
        {
            letterGapTimer += Time.deltaTime;
            if (letterGapTimer >= symbolGap)
            {
                if (currentIndex < morseArray.Length && symbolIndex < morseArray[currentIndex].Length)
                {
                    PlaySymbol(morseArray[currentIndex][symbolIndex]);
                    isCurrentlyPlaying = true;
                    letterGapTimer = 0;
                }
            }
        }
    }

    private void PlayNextLetter()
    {
        if (letterQueue.Count > 0 && !isPlayingLetter)
        {
            string nextMorse = letterQueue.Dequeue();
            morseArray = new string[] { nextMorse };
            isPlayingLetter = true;
            StartPlayback();
        }
    }

    private void StartPlayback()
    {
        shouldPlay = true;
        ResetTimers();
    }

    private void StopPlayback()
    {
        shouldPlay = false;
        ResetTimers();
        isCurrentlyPlaying = false;
    }

    private void ResetTimers()
    {
        currentIndex = 0;
        symbolIndex = 0;
        symbolTimer = 0;
        letterGapTimer = 0;
    }

    private void FinishCurrentLetter()
    {
        StopPlayback();
        isPlayingLetter = false;
        PlayNextLetter();
    }

    private void UpdateMorseOutput()
    {
        if (!playNewLetterOnly)
        {
            string latinText = inputField.text.ToLower();
            string result = "";

            foreach (char character in latinText)
            {
                if (character == ' ')
                {
                    result += " ";
                }
                else if (latinToMorse.ContainsKey(character.ToString()))
                {
                    result += latinToMorse[character.ToString()] + " ";
                }
            }

            outputText.text = result;
        }

        playNewLetterOnly = false;
    }

    private void PlaySymbol(char symbol)
    {
        if (symbol == '.')
        {
            soundManagerScript.PlayDotSound();
        }
        else if (symbol == '-')
        {
            soundManagerScript.PlayDashSound();
        }
    }

    private void InitializeMorseDictionary()
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
