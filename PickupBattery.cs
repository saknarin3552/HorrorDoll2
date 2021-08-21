using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBattery : MonoBehaviour {

    public GameObject player;
    public float changeValue;//ค่าแบตเตอรี่

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag=="Player")
        {
            //ทำอะไร
            other.gameObject.GetComponent<BatterySystem>().pickupPanel.SetActive(true);

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.transform.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                other.gameObject.GetComponent<BatterySystem>().pickupPanel.SetActive(false);
                this.gameObject.SetActive(false);
                AddBattery(player,changeValue);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.tag == "Player")
        {
            //ทำอะไร
            other.gameObject.GetComponent<BatterySystem>().pickupPanel.SetActive(false);

        }
    }
    void AddBattery(GameObject player,float value)
    {
        if (player.GetComponent<BatterySystem>().battery < player.GetComponent<BatterySystem>().batteryMax)
        {
            player.GetComponent<BatterySystem>().battery += value;
        }
    }
}
