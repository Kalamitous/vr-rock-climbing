using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
    public GameObject HoldPrefab;
    public int HoldCount;

    void Start() {
        Generate();
    }

    void Generate() {
        Vector3 wallSize = GetComponent<MeshRenderer>().bounds.size;
        float border = 1f;
        float dimension = Mathf.Floor((wallSize.x - 2 * border) / Mathf.Sqrt(HoldCount));
        for (int i = 0; i < Mathf.Sqrt(HoldCount); i++) {
            for (int j = 0; j < Mathf.Sqrt(HoldCount); j++) {
                GameObject hold = Instantiate(HoldPrefab);
                Vector3 holdSize = hold.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size;
                float x = Random.Range(0, dimension);
                float y = Random.Range(0, dimension);
                hold.transform.position = new Vector3(border + dimension * i + x - wallSize.x / 2, border + dimension * j + y, holdSize.z / 2);
            }
        }
    }
}
