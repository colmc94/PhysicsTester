﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void GravityExp()
    {
        SceneManager.LoadScene("Gravity");
    }
    public void VandAExp()
    {
        SceneManager.LoadScene("VandA");
    }
}
