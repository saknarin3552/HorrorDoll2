using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BatterySystem : MonoBehaviour {

    public float battery = 100f;
    public float batteryMax = 100f;
    public GameObject flashLight;
    public float removeBattery = 1f;//ค่าแบตที่ลดลง
    public float secondRemove = 1f;//เวลา
    public Slider batterySlider;
    public GameObject pickupPanel;

	void Start () {

        battery = batteryMax;
        batterySlider.GetComponent<Slider>().maxValue = batteryMax;
        batterySlider.GetComponent<Slider>().value = battery;
        StartCoroutine(RemoveBattery(removeBattery,secondRemove));

    }
	
	
	void Update () {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            this.GetComponent<Animation>().CrossFade("Run",1);
        }
        else
        {
            this.GetComponent<Animation>().CrossFade("Idle", 1);
        }

        batterySlider.GetComponent<Slider>().value = battery;
        // 50%
        if (battery/batteryMax*100<=50)
        {
            flashLight.transform.Find("Spotlight").GetComponent<Light>().intensity=2.8f;
        }
        if (battery / batteryMax * 100 <= 25)
        {
            flashLight.transform.Find("Spotlight").GetComponent<Light>().intensity = 2.0f;
        }
        if (battery / batteryMax * 100 <= 10)
        {
            flashLight.transform.Find("Spotlight").GetComponent<Light>().intensity = 1.0f;
        }
        if (battery / batteryMax * 100 <= 0)
        {
            flashLight.transform.Find("Spotlight").GetComponent<Light>().intensity = 0.0f;
        }
    }
    public IEnumerator RemoveBattery(float value,float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            if (battery>0)
            {
                battery -= value;
            }
        }
    }
}
