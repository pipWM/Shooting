using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAction : MonoBehaviour {
    public Transform GunVerRot;
    public Transform GunHorRot;
    private Transform muzzle;
    private Transform aim;
    private GameObject AimObject;
    private float muzzleRadius;
    private float Range;
    private GameObject nearEnemy;
    private AudioController AudioC;
    private UIController ui;
    private ClayGenerator claygenerator;
    private global::System.Int32 maxDistance;

    // Use this for initialization
    void Start () {
        muzzle = GameObject.Find("Muzzle").transform;
        muzzleRadius = muzzle.GetComponent<SphereCollider>().radius;
        aim = GameObject.Find("aim4").GetComponent<Transform>();
        AimObject = GameObject.Find("aim4");
        Range = 100;
        GunVerRot = transform.parent;
        GunHorRot = GetComponent<Transform>();
        ui = GameObject.Find("Canvas").GetComponent<UIController>();
        AudioC = GameObject.Find("SE").GetComponent<AudioController>();
        claygenerator = GameObject.Find("ClayGene").GetComponent<ClayGenerator>();
	}
	
	// Update is called once per frame
	void Update () {
        //銃を動かす  
        float XRotation = Input.GetAxis("Mouse X");
        float YRotation = Input.GetAxis("Mouse Y");
        GunVerRot.transform.Rotate(0, 5*XRotation, 0);
        GunHorRot.transform.Rotate(0, 0, -3 * YRotation);
        //　銃を撃つ
        Judge();
    }

    void Judge(){
        //飛ばす位置と飛ばす方向を設定
        Ray ray = new Ray(muzzle.transform.position, muzzle.transform.forward);
        Vector3 point = Input.mousePosition;
        Debug.Log(point);
        List<GameObject> list = claygenerator.ClayList;
        if(list.Count > 0){
            float z = list[0].transform.position.z;
            point = new Vector3(point.x, point.y, z);
        }

        //当たったコライダを入れておく変数
        RaycastHit[] hits;
        //Sphereの形でレイを飛ばしEnemyレイヤーのものをhitsに入れる
        hits = Physics.SphereCastAll(ray, muzzleRadius, Range);
        //射程距離をdistanceに入れる
        var distance = Range;
        //nearEnemyを初期化
        nearEnemy = null;

        //Debug.DrawRay(ray.origin, ray.direction * 100, Color.green, 5, false);

        //銃口の先に的がない
        bool NoneEnemy = true;

        //レイと接触したコライダで一番近い距離の物を探す
        foreach (var hit in hits){
            if (hit.collider.CompareTag("Enemy") && Vector3.Distance(transform.position, hit.point) < distance)
            {
                NoneEnemy = false;
                distance = Vector3.Distance(transform.position, hit.point);
                nearEnemy = hit.collider.gameObject;
                AimObject.SetActive(true);
                aim.position = nearEnemy.GetComponent<Transform>().position;
            }
        }

        if(NoneEnemy) AimObject.SetActive(false);

        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown("space")) && !ui.GameOverIs){
            AudioC.GunSE();
            //一番近い物を消す
            if (nearEnemy != null){
                ui.AddScore();
                ClayController script = nearEnemy.GetComponent<ClayController>();
                script.ClashClay();
            }
        }

    }
}
