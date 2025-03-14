using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DecoderManager : MonoBehaviour
{
    [SerializeField] private Converter converter;
    [SerializeField] private MorseCharacter morseCharacter;
    [SerializeField] private TMPro.TMP_InputField inputField;
    private string oncekiMorseChar = "";
    

    void Update()
    {
        inputField.onValueChanged.AddListener(delegate { DecodeMorse(converter.outputText.text); });
    }

    void DecodeMorse(string morseCode)
    {
            
            string[] morseArray = morseCode.Split(' ');

            foreach (string morseChar in morseArray)
            {
                if (string.IsNullOrEmpty(morseChar)) continue;

                if (morseChar != oncekiMorseChar)
                {
                    morseCharacter.ResetMaterials();
                    oncekiMorseChar = morseChar;
            
                // Triangle Lines (Tüm harfler için ortak)
                morseCharacter.SetOn(morseCharacter.TriangleLine);
                morseCharacter.SetOn(morseCharacter.TriangleLine2);
                morseCharacter.SetOn(morseCharacter.TriangleLine3);
                morseCharacter.SetOn(morseCharacter.TriangleLine4);
                morseCharacter.SetOn(morseCharacter.TriangleLine5);

                switch (morseChar)
                {
                    case ".-": // A
                        morseCharacter.SetOn(morseCharacter.ELine);
                        morseCharacter.SetOn(morseCharacter.EDOT);
                        morseCharacter.SetOn(morseCharacter.ALine);
                        morseCharacter.SetOn(morseCharacter.ADash);
                        break;

                    case "-...": // B
                        morseCharacter.SetOn(morseCharacter.TLine);
                        morseCharacter.SetOn(morseCharacter.TDash);
                        morseCharacter.SetOn(morseCharacter.NLine);
                        morseCharacter.SetOn(morseCharacter.NDOT);
                        morseCharacter.SetOn(morseCharacter.DLine);
                        morseCharacter.SetOn(morseCharacter.DDOT);
                        morseCharacter.SetOn(morseCharacter.BLine);
                        morseCharacter.SetOn(morseCharacter.BDOT);
                        break;

                    case "-.-.": // C
                        morseCharacter.SetOn(morseCharacter.TLine);
                        morseCharacter.SetOn(morseCharacter.TDash);
                        morseCharacter.SetOn(morseCharacter.NLine);
                        morseCharacter.SetOn(morseCharacter.NDOT);
                        morseCharacter.SetOn(morseCharacter.KLine);
                        morseCharacter.SetOn(morseCharacter.KDash);
                        morseCharacter.SetOn(morseCharacter.CLine);
                        morseCharacter.SetOn(morseCharacter.CDOT);
                        break;

                    case "-..": // D
                        morseCharacter.SetOn(morseCharacter.TLine);
                        morseCharacter.SetOn(morseCharacter.TDash);
                        morseCharacter.SetOn(morseCharacter.NLine);
                        morseCharacter.SetOn(morseCharacter.NDOT);
                        morseCharacter.SetOn(morseCharacter.DLine);
                        morseCharacter.SetOn(morseCharacter.DDOT);
                        break;

                    case ".": // E
                        morseCharacter.SetOn(morseCharacter.ELine);
                        morseCharacter.SetOn(morseCharacter.EDOT);
                        break;

                    case "..-.": // F
                        morseCharacter.SetOn(morseCharacter.ELine);
                        morseCharacter.SetOn(morseCharacter.EDOT);
                        morseCharacter.SetOn(morseCharacter.ILine);
                        morseCharacter.SetOn(morseCharacter.IDOT);
                        morseCharacter.SetOn(morseCharacter.FLine);
                        morseCharacter.SetOn(morseCharacter.FDOT);
                        break;

                    case "--.": // G
                        morseCharacter.SetOn(morseCharacter.TLine);
                        morseCharacter.SetOn(morseCharacter.TDash);
                        morseCharacter.SetOn(morseCharacter.MLine);
                        morseCharacter.SetOn(morseCharacter.MDash);
                        morseCharacter.SetOn(morseCharacter.GLine);
                        morseCharacter.SetOn(morseCharacter.GDOT);
                        break;

                    case "....": // H
                        morseCharacter.SetOn(morseCharacter.ELine);
                        morseCharacter.SetOn(morseCharacter.EDOT);
                        morseCharacter.SetOn(morseCharacter.ILine);
                        morseCharacter.SetOn(morseCharacter.IDOT);
                        morseCharacter.SetOn(morseCharacter.SLine);
                        morseCharacter.SetOn(morseCharacter.SDOT);
                        morseCharacter.SetOn(morseCharacter.HLine);
                        morseCharacter.SetOn(morseCharacter.HDOT);
                        break;

                    case "..": // I
                        morseCharacter.SetOn(morseCharacter.ELine);
                        morseCharacter.SetOn(morseCharacter.EDOT);
                        morseCharacter.SetOn(morseCharacter.ILine);
                        morseCharacter.SetOn(morseCharacter.IDOT);
                        break;

                    case ".---": // J
                        morseCharacter.SetOn(morseCharacter.ELine);
                        morseCharacter.SetOn(morseCharacter.EDOT);
                        morseCharacter.SetOn(morseCharacter.ALine);
                        morseCharacter.SetOn(morseCharacter.ADash);
                        morseCharacter.SetOn(morseCharacter.WLine);
                        morseCharacter.SetOn(morseCharacter.WDash);
                        morseCharacter.SetOn(morseCharacter.JLine);
                        morseCharacter.SetOn(morseCharacter.JDash);
                        break;

                    case "-.-": // K
                        morseCharacter.SetOn(morseCharacter.TLine);
                        morseCharacter.SetOn(morseCharacter.TDash);
                        morseCharacter.SetOn(morseCharacter.NLine);
                        morseCharacter.SetOn(morseCharacter.NDOT);
                        morseCharacter.SetOn(morseCharacter.KLine);
                        morseCharacter.SetOn(morseCharacter.KDash);
                        break;

                    case ".-..": // L
                        morseCharacter.SetOn(morseCharacter.ELine);
                        morseCharacter.SetOn(morseCharacter.EDOT);
                        morseCharacter.SetOn(morseCharacter.ILine);
                        morseCharacter.SetOn(morseCharacter.IDOT);
                        morseCharacter.SetOn(morseCharacter.RLine);
                        morseCharacter.SetOn(morseCharacter.RDOT);
                        morseCharacter.SetOn(morseCharacter.LLine);
                        morseCharacter.SetOn(morseCharacter.LDOT);
                        break;

                    case "--": // M
                        morseCharacter.SetOn(morseCharacter.TLine);
                        morseCharacter.SetOn(morseCharacter.TDash);
                        morseCharacter.SetOn(morseCharacter.MLine);
                        morseCharacter.SetOn(morseCharacter.MDash);
                        break;

                    case "-.": // N
                        morseCharacter.SetOn(morseCharacter.TLine);
                        morseCharacter.SetOn(morseCharacter.TDash);
                        morseCharacter.SetOn(morseCharacter.NLine);
                        morseCharacter.SetOn(morseCharacter.NDOT);
                        break;

                    case "---": // O
                        morseCharacter.SetOn(morseCharacter.TLine);
                        morseCharacter.SetOn(morseCharacter.TDash);
                        morseCharacter.SetOn(morseCharacter.MLine);
                        morseCharacter.SetOn(morseCharacter.MDash);
                        morseCharacter.SetOn(morseCharacter.OLine);
                        morseCharacter.SetOn(morseCharacter.ODash);
                        break;

                    case ".--.": // P
                        morseCharacter.SetOn(morseCharacter.ELine);
                        morseCharacter.SetOn(morseCharacter.EDOT);
                        morseCharacter.SetOn(morseCharacter.ALine);
                        morseCharacter.SetOn(morseCharacter.ADash);
                        morseCharacter.SetOn(morseCharacter.RLine);
                        morseCharacter.SetOn(morseCharacter.RDOT);
                        morseCharacter.SetOn(morseCharacter.PLine);
                        morseCharacter.SetOn(morseCharacter.PDOT);
                        break;

                    case "--.-": // Q
                        morseCharacter.SetOn(morseCharacter.TLine);
                        morseCharacter.SetOn(morseCharacter.TDash);
                        morseCharacter.SetOn(morseCharacter.MLine);
                        morseCharacter.SetOn(morseCharacter.MDash);
                        morseCharacter.SetOn(morseCharacter.GLine);
                        morseCharacter.SetOn(morseCharacter.GDOT);
                        morseCharacter.SetOn(morseCharacter.QLine);
                        morseCharacter.SetOn(morseCharacter.QDash);
                        break;
                        
                    case ".-.": // R
                        morseCharacter.SetOn(morseCharacter.ELine);
                        morseCharacter.SetOn(morseCharacter.EDOT);
                        morseCharacter.SetOn(morseCharacter.RLine);
                        morseCharacter.SetOn(morseCharacter.RDOT);
                        break;

                    case "...": // S
                        morseCharacter.SetOn(morseCharacter.ELine);
                        morseCharacter.SetOn(morseCharacter.EDOT);
                        morseCharacter.SetOn(morseCharacter.ILine);
                        morseCharacter.SetOn(morseCharacter.IDOT);
                        morseCharacter.SetOn(morseCharacter.SLine);
                        morseCharacter.SetOn(morseCharacter.SDOT);
                        break;

                    case "-": // T
                        morseCharacter.SetOn(morseCharacter.TLine);
                        morseCharacter.SetOn(morseCharacter.TDash);
                        break;

                    case "..-": // U
                        morseCharacter.SetOn(morseCharacter.ELine);
                        morseCharacter.SetOn(morseCharacter.EDOT);
                        morseCharacter.SetOn(morseCharacter.ULine);
                        morseCharacter.SetOn(morseCharacter.UDash);
                        break;

                    case "...-": // V
                        morseCharacter.SetOn(morseCharacter.ELine);
                        morseCharacter.SetOn(morseCharacter.EDOT);
                        morseCharacter.SetOn(morseCharacter.ILine);
                        morseCharacter.SetOn(morseCharacter.IDOT);
                        morseCharacter.SetOn(morseCharacter.VLine);
                        morseCharacter.SetOn(morseCharacter.VDash);
                        break;

                    case ".--": // W
                        morseCharacter.SetOn(morseCharacter.ELine);
                        morseCharacter.SetOn(morseCharacter.EDOT);
                        morseCharacter.SetOn(morseCharacter.WLine);
                        morseCharacter.SetOn(morseCharacter.WDash);
                        break;

                    case "-..-": // X
                        morseCharacter.SetOn(morseCharacter.TLine);
                        morseCharacter.SetOn(morseCharacter.TDash);
                        morseCharacter.SetOn(morseCharacter.XLine);
                        morseCharacter.SetOn(morseCharacter.XDash);
                        break;

                    case "-.--": // Y
                        morseCharacter.SetOn(morseCharacter.TLine);
                        morseCharacter.SetOn(morseCharacter.TDash);
                        morseCharacter.SetOn(morseCharacter.YLine);
                        morseCharacter.SetOn(morseCharacter.YDash);
                        break;

                    case "--..": // Z
                        morseCharacter.SetOn(morseCharacter.TLine);
                        morseCharacter.SetOn(morseCharacter.TDash);
                        morseCharacter.SetOn(morseCharacter.MLine);
                        morseCharacter.SetOn(morseCharacter.MDash);
                        morseCharacter.SetOn(morseCharacter.ZLine);
                        morseCharacter.SetOn(morseCharacter.ZDOT);
                        break;
                }
            }
        }
    }
}


