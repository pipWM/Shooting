using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClayController : MonoBehaviour {
    private GameObject SE;
    private ClayGenerator claygenerator;
    private List<GameObject> ClayList = new List<GameObject>();
    private UIController ui;
	// Use this for initialization
	void Start () {
        SE = GameObject.Find("SE");
        claygenerator = GameObject.Find("ClayGene").GetComponent<ClayGenerator>();
        ClayList = claygenerator.ClayList;
        ui = GameObject.Find("Canvas").GetComponent<UIController>();

        Vector3 force = new Vector3(0.0f, 7f, -5f);
        float rnd = Random.value;
        Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();
        rb.AddForce(force,ForceMode.Impulse);
    }
	
	void Update () {
        if(this.gameObject.transform.position.y < -10){
            MissClay();
            ui.Miss();
        }
        this.gameObject.transform.Rotate(5.0f,0f,0f,Space.World);
    }

    public void ClashClay(){
        //皿を撃ち落とす
        SE.GetComponent<AudioController>().ClaySE();
        ClayList.Remove(this.gameObject);
        Destroy(this.gameObject);
    }

    private void MissClay()
    {
        //皿が地面に落ちる
        ClayList.Remove(this.gameObject);
        Destroy(this.gameObject);
    }
}
