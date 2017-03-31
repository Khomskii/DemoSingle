using UnityEngine;
using System.Collections;

public class LoginScene : MonoBehaviour {
    private string loginView = "View/LoginView";
    public Transform viewTransform;
    GameObject loginViewPrefab;
	void Start () {
        loginViewPrefab= Instantiate(Resources.Load<GameObject>(loginView)) as GameObject;
        loginViewPrefab.transform.SetParent(viewTransform);
        loginViewPrefab.transform.localPosition = Vector3.zero;
	}
}
