using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickCtrl : MonoBehaviour {

	public static JoystickCtrl instance;
	public Image stick;
	public Vector3 originPos = Vector3.zero;
	public float angle = 0;
	public Vector3 dir = Vector3.zero;
	float stickRadius = 0;
	public bool drag = false;

	void Awake() {
		originPos = gameObject.GetComponent<Image> ().rectTransform.position;
		JoystickCtrl.instance = this;
	}

	void Start() {
		originPos = stick.transform.position;

		stickRadius = stick.rectTransform.sizeDelta.x - 180;
	}

	public void OnDrag() {
	#if UNITY_EDITOR
		drag = true;
		Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
		dir = (mousePos - originPos).normalized;
		Vector3 v = (originPos - mousePos) * -1;
		angle = (Mathf.Atan2((v.y * -1), v.x) * Mathf.Rad2Deg - 90) + 225;
		float touchAreaRadius = Vector3.Distance (originPos, mousePos);

		if (touchAreaRadius > stickRadius) {
			stick.rectTransform.position = originPos + (dir * stickRadius);
		} else {
			stick.rectTransform.position = mousePos;
		}
	#else
		drag = true;
		Touch touch = Input.GetTouch (0);
		dir = (new Vector3(touch.position.x, touch.position.y, originPos.z) - originPos).normalized;
		Vector3 v = (originPos - new Vector3(touch.position.x, touch.position.y, originPos.z)) * -1;
		angle = (Mathf.Atan2((v.y * -1), v.x) * Mathf.Rad2Deg - 90) + 225;
		float touchAreaRadius = Vector3.Distance (originPos, new Vector3 (touch.position.x, touch.position.y, originPos.z));

		if (touchAreaRadius > stickRadius) {
			stick.rectTransform.position = originPos + (dir * stickRadius);
		} else {
			stick.rectTransform.position = touch.position;
		}
	#endif
	}

	public void OnEndDrag() {
		if (stick != null) {
			drag = false;
			stick.rectTransform.position = originPos;
		}
	}
}
