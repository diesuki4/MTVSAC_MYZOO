using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
public class CameraShot : MonoBehaviour
{
    public bool hideGUI = false;
    public Texture2D texture;
    public Image screenshot;
    private string paths = null;

    void OnEnable()
    {
        // call backs
        ScreenshotManager.OnScreenshotTaken += ScreenshotTaken;
        ScreenshotManager.OnScreenshotSaved += ScreenshotSaved;
        ScreenshotManager.OnImageSaved += ImageSaved;
    }

    void OnDisable()
    {
        ScreenshotManager.OnScreenshotTaken -= ScreenshotTaken;
        ScreenshotManager.OnScreenshotSaved -= ScreenshotSaved;
        ScreenshotManager.OnImageSaved -= ImageSaved;
    }

    //스크린샷찍고 저장.
    public void OnSaveScreenshotPress()
    {
        ScreenshotManager.SaveScreenshot("MyScreenshot", "ScreenshotApp", "jpeg");
    }

    //이미지 저장.
    public void OnSaveImagePress()
    {
        ScreenshotManager.SaveImage(texture, "MyImage", "MyImages", "png");
    }

    void ScreenshotTaken(Texture2D image)
    {
        Debug.Log("\nScreenshot has been taken and is now saving...");
        screenshot.sprite = Sprite.Create(image, new Rect(0, 0, image.width, image.height), new Vector2(.5f, .5f));
        screenshot.color = Color.white;
    }

    void ScreenshotSaved(string path)
    {
        Debug.Log("\nScreenshot finished saving to " + path);
        paths = path;
    }

    void ImageSaved(string path)
    {
        Debug.Log( "\n" + texture.name + " finished saving to " + path);
        paths = path;
    }
}
