using UnityEngine;
using UnityEngine.EventSystems;  
using UnityEngine.UI;
using TMPro;

public class Buttons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    [SerializeField] TextMeshProUGUI text;

    public void Start() {
        text.faceColor = new Color32(255, 255, 255, 180); 
    }

    public void OnPointerEnter(PointerEventData eventData) {
        text.faceColor = new Color32(255, 0, 0, 180);
    }
 
    public void OnPointerExit(PointerEventData eventData){
        text.faceColor = new Color32(255, 255, 255, 180); 
    }
}