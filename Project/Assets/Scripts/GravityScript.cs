using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class GravityScript : MonoBehaviour {

    public GUIStyle heading,result;
    public GameObject Hbar,Magnet;
    public Slider HeightSlider,SpeedSlider;
    public Text HeightText,TimeText,ResultsText,SpeedText;
    public Toggle UI;
    private Rigidbody ball;
    private float height, startTime, finishTime, elapsedTime,gravity,w,h;
    private int count;
    private float[] heightResults, timeResults, gravityResults;
    // Use this for initialization
    void Start () {
        ball = GetComponent<Rigidbody>();
        height = HeightSlider.value;
        Time.timeScale = SpeedSlider.value / 10;
        setPosition();
        heightResults = new float[10];
        timeResults = new float[10];
        gravityResults = new float[10];
        count = 0;
        w = 1920f;
        h = 1080;
    }
	// Update is called once per frame
	void FixedUpdate () {
        if (ball.useGravity == true) {
            elapsedTime = elapsedTime + Time.fixedDeltaTime;
            TimeText.text = (elapsedTime).ToString("f4");
        }
        else
        {
            TimeText.text = finishTime.ToString("f4");
        }
	}
    void OnCollisionEnter(Collision collisionInfo)
    {
        finishTime = elapsedTime;
        getValue();
        ball.useGravity = false;
        HeightSlider.enabled =true;
    }
    public void StartExp()
    {
        HeightSlider.enabled = false;
        setPosition();
        elapsedTime = 0.0f;
        ball.useGravity = true;
    }
    public void ResetExp()
    {
        storeValue();
        HeightSlider.enabled = true;
        setPosition();
        finishTime = 0f;
    }
    public void AdjustHeight()
    {
        height = HeightSlider.value;
        HeightText.text = (height / 100).ToString("f2") + " m";
        setPosition();
    }
    public void AdjustSpeed()
    {
        SpeedText.text = (SpeedSlider.value / 10).ToString() + " X Speed";
        Time.timeScale = SpeedSlider.value/10;
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    private void setPosition()
    {
        transform.position = new Vector3(transform.position.x, height + 7.5f, transform.position.z);
        Hbar.transform.position = new Vector3(Hbar.transform.position.x, height + 17f, Hbar.transform.position.z);
        Magnet.transform.position = new Vector3(Magnet.transform.position.x, height + 13f, Magnet.transform.position.z);
    }
    private void getValue()
    {
        gravity = ((2 * height) / 100) / (finishTime*finishTime);
        gravity = Mathf.Round(gravity * 1000f) / 1000;
        ResultsText.text = "G = " + gravity+ " m/s^2";
    }
    private void storeValue()
    {
        heightResults[count] = height;
        timeResults[count] = finishTime;
        gravityResults[count] = gravity;
        count++;
    }
    public void OnGUI()
    {
        float ratioX = Screen.width / w;
        float ratioY = Screen.height / h;
        GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(ratioX, ratioY, 1));
        if (UI.isOn == true)
        {
            GUI.Box(new Rect(550,150, 800, 700),"");
            GUI.Label(new Rect(600, 200, 240, 60), "Height(m)",heading);
            GUI.Label(new Rect(880, 200, 240, 60), "Time(s)",heading);
            GUI.Label(new Rect(1100, 200, 240, 60), "Gravity(m/s^2)",heading);
            for (int i = 0; i < count; i++)
            {
                GUI.Label(new Rect(640, 250+(50*i), 240, 60), "0."+heightResults[i].ToString(),result);
                GUI.Label(new Rect(900, 250 + (50 * i), 240, 60), timeResults[i].ToString("f4"),result);
                GUI.Label(new Rect(1140, 250 + (50 * i), 240, 60), gravityResults[i].ToString(),result);
            }
        }
    }
}
