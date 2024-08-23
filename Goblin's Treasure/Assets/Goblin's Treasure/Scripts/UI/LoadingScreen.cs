using UnityEngine;

public class LoadingScreen : MonoBehaviour {

    private void Awake() => Hide();
    
    public void Show() => gameObject.SetActive(true);
    
    public void Hide() => gameObject.SetActive(false);
}