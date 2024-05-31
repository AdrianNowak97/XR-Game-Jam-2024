using System;
using UnityEngine;
using UnityEngine.UI;

public class CameraFade : MonoBehaviour
{
    public KeyCode key = KeyCode.Space; // Which key should trigger the fade?
    public float speedScale = 1f;
    public Color fadeColor = Color.black;
    // Rather than Lerp or Slerp, we allow adaptability with a configurable curve
    public AnimationCurve Curve = new AnimationCurve(new Keyframe(0, 1),
        new Keyframe(0.5f, 0.5f, -1.5f, -1.5f), new Keyframe(1, 0));
    public bool startFadedOut = false;
    
    private float alpha = 0f; 
    private Texture2D texture;
    private int direction = 0;
    private float time = 0f;

    [SerializeField] private AfterBattleScreenManager _afterBattleScreenManager; 
    [SerializeField] private GameObject FadeImg;
    
    //Animations
    private bool animationStart = false;

    private void Start()
    {
        if (startFadedOut) alpha = 1f; else alpha = 0f;
        texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha));
        texture.Apply();
        FadeImg.GetComponent<RawImage>().texture = texture;
        FadeImg.GetComponent<RawImage>().color = new Color(1, 1, 1, 1);
    }

    private void Update()
    {
        if (direction == 0 && animationStart)
        {
            print("odpalam fade");
            if (alpha >= 1f) // Fully faded out
            {
                alpha = 1f;
                time = 0f;
                direction = 1;
            }
            else // Fully faded in
            {
                alpha = 0f;
                time = 1f;
                direction = -1;
            }

            animationStart = false;
        }
    }
    public void OnGUI()
    {
        if (alpha > 0f) GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);
        if (direction != 0)
        {
            time += direction * Time.deltaTime * speedScale;
            alpha = Curve.Evaluate(time);
            texture.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha));
            texture.Apply();
            if (alpha <= 0f || alpha >= 1f) direction = 0;
        }
    }

    public void AnimatorChangeAnimation()
    {
        gameObject.GetComponent<Animator>().Play("Fade In Fade Out Camera");
    }
    
    public void AnimationStart()
    {
        print("Start Fade");
        animationStart = true;
    }

    public void AnimationEnd()
    {
        print("End Fade");
        _afterBattleScreenManager.SpawnScreen();
        gameObject.GetComponent<Animator>().Play("Idle Camera");
        animationStart = false;
        direction = 0;
    }

    public void ReturnItems()
    {
        WinningConditionEventSystem.KnightComeBack(0);
    }
}