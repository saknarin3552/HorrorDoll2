using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PagesSystem : MonoBehaviour {

    public int collectionpage;
    public List<GameObject> pages = new List<GameObject>();
    public GameObject pickupPanel;
    public GameObject finishPanel;
    public GameObject pageCounttxt;

    void Update () {
		pageCounttxt.GetComponent<Text>().text="Pages : "+ collectionpage+" / 8";
        if (collectionpage>=8)
        {
            finishPanel.SetActive(true);
            this.gameObject.GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
        }
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag == "Page")
        {
                pickupPanel.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.transform.tag == "Page")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                pickupPanel.SetActive(false);
                pages.Add(other.gameObject);
                collectionpage++;
                other.gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.tag == "Page")
        {
            pickupPanel.SetActive(false);
        }
    }
}
