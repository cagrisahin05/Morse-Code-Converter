using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MorseCharacter : MonoBehaviour
{

  [Header("Materials")]
    public Material onMaterial;
    public Material offMaterial;

    [Header("Lines")]
    public GameObject TriangleLine;
    public GameObject TriangleLine2;
    public GameObject TriangleLine3;
    public GameObject TriangleLine4;
    public GameObject TriangleLine5;
    public GameObject TLine;
    public GameObject ELine;
    public GameObject ALine;
    public GameObject NLine;
    public GameObject DLine;
    public GameObject KLine;
    public GameObject GLine;
    public GameObject OLine;
    public GameObject MLine;
    public GameObject RLine;
    public GameObject WLine;
    public GameObject JLine;
    public GameObject PLine;
    public GameObject ULine;
    public GameObject FLine;
    public GameObject ILine;
    public GameObject LLine;
    public GameObject VLine;
    public GameObject SLine;
    public GameObject HLine;
    public GameObject BLine;
    public GameObject XLine;
    public GameObject CLine;
    public GameObject YLine;
    public GameObject ZLine;
    public GameObject QLine;

    [Header("Dots")]
    public GameObject SDOT;
    public GameObject HDOT;
    public GameObject LDOT;
    public GameObject BDOT;
    public GameObject FDOT;
    public GameObject IDOT;
    public GameObject EDOT;
    public GameObject RDOT;
    public GameObject PDOT;
    public GameObject DDOT;
    public GameObject CDOT;
    public GameObject NDOT;
    public GameObject ZDOT;
    public GameObject GDOT;


    [Header("Dashes")]
    public GameObject TDash;
    public GameObject UDash;
    public GameObject ADash;
    public GameObject WDash;
    public GameObject JDash;
    public GameObject VDash;
    public GameObject MDash;
    public GameObject ODash;
    public GameObject QDash;
    public GameObject XDash;
    public GameObject YDash;
    public GameObject KDash;

    public void ResetMaterials()
    {
        foreach (GameObject obj in new GameObject[] { TriangleLine, TriangleLine2, TriangleLine3, TriangleLine4, TriangleLine5, TLine, ELine, ALine, NLine, DLine, KLine, GLine, OLine, MLine, RLine, WLine, JLine, PLine, ULine, FLine, ILine, LLine, VLine, SLine, HLine, BLine, XLine, CLine, YLine, ZLine, GDOT, ZDOT, NDOT, CDOT, DDOT, PDOT, RDOT, FDOT, EDOT, IDOT, SDOT, HDOT, LDOT, BDOT, TDash, UDash, ADash, WDash, JDash, VDash, MDash, ODash, QDash, XDash, YDash, KDash, QLine })
        {
            SetMaterial(obj, offMaterial);
        }
    }
    public void SetOn(GameObject obj)
    {
        SetMaterial(obj, onMaterial);
    }

    private void SetMaterial(GameObject obj, Material material)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = material;
        }
    }
    
}
