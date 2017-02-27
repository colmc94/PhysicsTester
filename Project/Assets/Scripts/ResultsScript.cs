using UnityEngine;
using System.Collections;
public class ResultsScript : MonoBehaviour {
    public GUIStyle heading, result,title,box;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void TwoResults(string heading1,string heading2,float[]results1,float[]results2)
    {
        GUI.Box(new Rect(550, 250, 800, 700), "");
        GUI.Label(new Rect(650, 300, 240, 60), heading1,heading);
        GUI.Label(new Rect(1000, 300, 240, 60), heading2,heading);
        for(int i = 0; i < results1.Length; i++)
        {
            GUI.Label(new Rect(650, 400+(i*40), 240, 60), results1[i].ToString(),result);
            GUI.Label(new Rect(1000, 400 + (i * 40), 240, 60), results2[i].ToString(),result);
        }
    }
    public void ThreeResults(string h1,string h2,string h3,float[]r1,float[]r2,float[]r3,int size)
    {
        GUI.Box(new Rect(550, 250, 800, 700), "",box);
        GUI.Label(new Rect(700, 75, 300, 100), "", title);
        GUI.Label(new Rect(600, 300, 240, 60), h1, heading);
        GUI.Label(new Rect(825, 300, 240, 60), h2, heading);
        GUI.Label(new Rect(1050, 300, 240, 60), h3, heading);
        for (int i = 0; i < size; i++)
        {
            GUI.Label(new Rect(600, 400 + (40 * i), 240, 60), "0." + r1[i].ToString(), result);
            GUI.Label(new Rect(825, 400 + (40 * i), 240, 60), r2[i].ToString("f4"), result);
            GUI.Label(new Rect(1050, 400 + (40 * i), 240, 60), r3[i].ToString(), result);
        }
    }
    public void FourColumns()
    {

    }
    public void FiveColumns(string h1,string h2,string h3,string h4,string h5, float[] r1, float[] r2, float[] r3, float[] r4, float[] r5,int size)
    {
        GUI.Box(new Rect(350, 250, 1200, 700), "");
        GUI.Label(new Rect(750, 75, 300, 100),"", title);
        GUI.Label(new Rect(350, 300, 240, 60), h1,heading);
        GUI.Label(new Rect(550, 300, 240, 60), h2, heading);
        GUI.Label(new Rect(800, 300, 240, 60), h3, heading);
        GUI.Label(new Rect(1050, 300, 240, 60), h4, heading);
        GUI.Label(new Rect(1300, 300, 240, 60), h5, heading);
        for(int i = 0; i< size; i++)
        {
            GUI.Label(new Rect(350, 400 + (40 * i), 240, 60), r1[i].ToString(), result);
            GUI.Label(new Rect(550, 400 + (40 * i), 240, 60), r2[i].ToString(), result);
            GUI.Label(new Rect(800, 400 + (40 * i), 240, 60), r3[i].ToString(), result);
            GUI.Label(new Rect(1050, 400 + (40 * i), 240, 60), r4[i].ToString(), result);
            GUI.Label(new Rect(1300, 400 + (40 * i), 240, 60), r5[i].ToString(), result);
        }
    }
}
