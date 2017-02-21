using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GravityScript : MonoBehaviour {

    
    public GameObject Hbar,Magnet;
    public Slider HeightSlider,SpeedSlider;
    public Text HeightText,TimeText,ResultsText;
    private Rigidbody ball;
    private Vector3 startPosition;
    private float height, startTime, finishTime, tempTime;
    // Use this for initialization
    void Start () {
        ball = GetComponent<Rigidbody>();
        height = HeightSlider.value;
        setPosition();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (ball.useGravity == true) {
            tempTime = tempTime + Time.fixedDeltaTime;
            TimeText.text = (tempTime).ToString("f4");
        }
        else
        {
            TimeText.text = finishTime.ToString("f4");
        }
	}
    void OnCollisionEnter(Collision collisionInfo)
    {
        finishTime = tempTime;
        getValue();
        ball.useGravity = false;
        HeightSlider.enabled =true;
    }
    public void StartExp()
    {
        HeightSlider.enabled = false;
        setPosition();
        startPosition = transform.position;
        tempTime = 0.0f;
        ball.useGravity = true;
    }
    public void ResetExp()
    {
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
        Time.timeScale = SpeedSlider.value/10;
    }
    private void setPosition()
    {
        transform.position = new Vector3(transform.position.x, height + 7.5f, transform.position.z);
        Hbar.transform.position = new Vector3(Hbar.transform.position.x, height + 17f, Hbar.transform.position.z);
        Magnet.transform.position = new Vector3(Magnet.transform.position.x, height + 13f, Magnet.transform.position.z);
    }
    private void getValue()
    {
        finishTime = Mathf.Round(finishTime * 10000.0f) * 0.0001f;
        float temp = ((2 * height) / 100) / Mathf.Pow(finishTime, 2);
        ResultsText.text = (((height * 2)/100) / (finishTime * finishTime)).ToString("f4") +" height is : "+((height*2)/100).ToString()+ " time is : "+(finishTime).ToString()+" temp = "+temp +" distance = "+(transform.position.y)/100;
    }
}
