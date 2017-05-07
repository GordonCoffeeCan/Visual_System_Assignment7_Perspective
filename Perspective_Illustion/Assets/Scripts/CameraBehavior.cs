using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {

    private Transform _camTran;
    private float _camSpeed = 10;

    private Vector3 _perspPos;
    private Quaternion _perspRots;

    private Vector3 _orthPos;
    private Quaternion _orthRots;

    private bool inPerspective;

    // Use this for initialization
    void Start () {
        _camTran = Camera.main.transform;

        _perspPos = new Vector3(-12.04f, 18.19f, -13.74f);
        _perspRots = Quaternion.Euler(48.916f, 47f, 0);

        _orthPos = new Vector3(0, 30, 0);
        _orthRots = Quaternion.Euler(90, 0, 0);

        inPerspective = true;

    }
	
	// Update is called once per frame
	void Update () {
        if (inPerspective == true) {
            _camTran.position = Vector3.Lerp(_camTran.position, _perspPos, _camSpeed * Time.deltaTime);
            _camTran.rotation = Quaternion.Slerp(_camTran.rotation, _perspRots, _camSpeed * Time.deltaTime);
        } else {
            _camTran.position = Vector3.Lerp(_camTran.position, _orthPos, _camSpeed * Time.deltaTime);
            _camTran.rotation = Quaternion.Slerp(_camTran.rotation, _orthRots, _camSpeed * Time.deltaTime);
        }
	}

    public void ToPerspec() {
        inPerspective = true;
    }

    public void ToOrtho() {
        inPerspective = false;
    }
}
