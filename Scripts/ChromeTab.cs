using UnityEngine;

public static class ChromeTab
{
    public static bool Show(string url, Color32 color)
    {
        bool result = false;

#if UNITY_EDITOR
        Application.OpenURL(url);
        result = true;
#elif UNITY_ANDROID
        AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaClass chromeTab = new AndroidJavaClass("com.unity3d.ChromeTab");

        try
        {
            int red = color.r;
            int green = color.g;
            int blue = color.b;
            chromeTab.CallStatic("Show", url, currentActivity, red, green, blue);
            result = true;
        }
        catch
        {
            // ignored
        }

        unityPlayerClass?.Dispose();
        currentActivity?.Dispose();
        chromeTab?.Dispose();
#endif
        return result;
    }
}