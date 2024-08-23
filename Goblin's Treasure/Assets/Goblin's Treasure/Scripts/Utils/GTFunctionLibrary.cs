using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public static class GTFunctionLibrary {

    #region DEBUG

    public static void Debug(this string message) {

#if UNITY_EDITOR
        UnityEngine.Debug.Log(message);
#endif
    }

    public static void DebugWarning(this string message) {
#if UNITY_EDITOR
        UnityEngine.Debug.LogWarning(message);
#endif
    }

    public static void DebugError(this string message) {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
        UnityEngine.Debug.LogError(message);
#endif
    }

    #endregion

    #region Transforms

    public static void DestroyAllChildrens(this Transform transform) {

        foreach (Transform child in transform) Object.Destroy(child.gameObject);
    }
    #endregion

    #region Tasks

    public static async void WrapErrors(this Task task) => await task;

    #endregion

    #region Image

    public static void SetAlpha(this Image image, float alpha) => image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);

    #endregion
}