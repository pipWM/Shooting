using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClayGenerator : MonoBehaviour {
    public GameObject ClayPrefab;
    public List<GameObject> ClayList = new List<GameObject>();
    void Start () {
        InvokeRepeating("GenClay", 1, 2);
    }

    void GenClay(){
        GameObject clay = Instantiate(ClayPrefab, new Vector3(5 - 10 * Random.value, 0, 8), Quaternion.identity);
        ClayList.Add(clay);
    }
}
