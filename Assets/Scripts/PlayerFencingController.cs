using UnityEngine;
using System.Collections.Generic;

public class PlayerFencingController : MonoBehaviour {

	// Use this for initialization

	void Start () {
        guiIndicatorTexture = Resources.Load("GUIFencingIndicator") as Texture;
        mouseIndicatorTexture = Resources.Load("GUIMouseIndicator") as Texture;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private Vector2 IndicatorSize = new Vector2(320,320)/2;
    private Vector2 MouseIndicatorSize = new Vector2(48, 48)/2;
    private Texture guiIndicatorTexture;
    private Texture mouseIndicatorTexture;

    private Vector2? previouseMousePosition;
    private Vector2 CollectedMouseMove = new Vector2();
    private float roundingFactor = 1 / 5f;
    //private float mouseSpeed;
    private Matrix4x4 InverseY = new Matrix4x4() { m00 = 1, m11 = -1 };
    void OnGUI() {
        if (previouseMousePosition.HasValue) {
            Vector2 mouseMove = InverseY * ((Vector2)Input.mousePosition - previouseMousePosition.Value) / Time.deltaTime; // Это скорость мыши в секунду
            
            var mul = Mathf.Pow(1 - roundingFactor, Time.deltaTime); // (1-roundingFactor) = a^n, n=1/Time.deltaTime => pow(1-roundingFactor, Time.deltaTime) = a;
            //mouseSpeed = mouseSpeed * mul + mouseMove.magnitude * (1 - mul);
            CollectedMouseMove = CollectedMouseMove * mul + mouseMove * (1 - mul);
            
        }
        previouseMousePosition = Input.mousePosition;
        // Отрисовка чё получилось
        Vector2 ScreenSize = new Vector2(Screen.width, Screen.height);
        GUI.DrawTexture(IndicatorSize.Rect().RightBottom(ScreenSize), guiIndicatorTexture);
        GUI.DrawTexture((ScreenSize - IndicatorSize / 2 - MouseIndicatorSize / 2 + CollectedMouseMove * 2).Rect(MouseIndicatorSize), mouseIndicatorTexture);
    }
}
