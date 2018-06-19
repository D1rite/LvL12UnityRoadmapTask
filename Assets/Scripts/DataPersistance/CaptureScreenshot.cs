using UnityEngine;
using System.Collections;
using System.IO;

// Screen Recorder will save individual images of active scene in any resolution and of a specific image format
// including raw, jpg, png, and ppm.  Raw and PPM are the fastest image formats for saving.
//
// You can compile these images into a video using ffmpeg:
// ffmpeg -i screen_3840x2160_%d.ppm -y test.avi

public class CaptureScreenshot : MonoBehaviour
{
    public static bool m_screenShotLock = false;
    public static string scName;

    private void LateUpdate()
    {
        if (m_screenShotLock)
        {
            StartCoroutine(TakeScreenShotCo());
        }
    }

    private IEnumerator TakeScreenShotCo()
    {
        if(!Directory.Exists(Application.persistentDataPath + "/SaveFiles/ScreenShots"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/SaveFiles/ScreenShots");
        }
        yield return new WaitForEndOfFrame();

        var directory = Directory.CreateDirectory(Application.persistentDataPath + "/SaveFiles/ScreenShots/" + scName + "/sc");
        var path = Path.Combine(directory.Parent.FullName, scName + ".png");
        Debug.Log("Taking screenshot to " + path);
        ScreenCapture.CaptureScreenshot(path);
        m_screenShotLock = false;
    }
}