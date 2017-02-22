using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class VandAScript : MonoBehaviour {
    public Rigidbody vehicle;
    public Text time1Text, time2Text,v1Text,v2Text,accelerationText;
    private Rigidbody card;
    private int count;
    private float time1, time2,velocity1,velocity2,acceleration;
    private Vector3 cardPosition, vehiclePosition;
	// Use this for initialization
	void Start () {
        Physics.gravity = new Vector3(0, 0, 10f);
        vehicle.useGravity = false;
        card = GetComponent<Rigidbody>();
        cardPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        vehiclePosition = new Vector3(vehicle.transform.position.x, vehicle.transform.position.y, vehicle.transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.z >= 55)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 55f);
            vehicle.transform.position = new Vector3(vehicle.transform.position.x, vehicle.transform.position.y, 58.5f);
        }
    }
    public void StartExp()
    {
        vehicle.useGravity = true;
        card.useGravity = true;
        transform.position = cardPosition;
        vehicle.transform.position = vehiclePosition;
    }
    public void ResetExp()
    {
        vehicle.useGravity = true;
        card.useGravity = true;
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter");
        count++;
    }
    void OnTriggerStay(Collider other)
    {
        if (count==1)
        {
            time1 = time1 + Time.fixedDeltaTime;
            time1Text.text = "Time 1: " + time1.ToString("f4") + " s";
        }
        if (count==2)
        {
            time2 = time2 + Time.fixedDeltaTime;
            time2Text.text = "Time 2: " + time2.ToString("f4") + " s";
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (count == 1)
        {
            velocity1 = 0.07f / time1;
            v1Text.text = "Velocity 1 : " + velocity1.ToString("f4") + " m/s";
        }
        if (count == 2)
        {
            velocity2 = 0.07f / time2;
            v2Text.text = "Velocity 2 : " + velocity2.ToString("f4") + " m/s";
            acceleration = ((velocity2 * velocity2) - (velocity1 * velocity1)) / 0.6f; //(v^2-u^2)/2s
            accelerationText.text = "Acceleration : "+acceleration.ToString("f4")+" m/s^2";
        }
    }
}
