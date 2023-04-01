using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseUI : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerPressRaycast.gameObject.name == "RedCell")
        {
            
        }
        else if (eventData.pointerPressRaycast.gameObject.name == "BlueCell")
        {

        }
        else if (eventData.pointerPressRaycast.gameObject.name == "PurpleCell")
        {

        }
        else if (eventData.pointerPressRaycast.gameObject.name == "GreenCell")
        {

        }
        else if (eventData.pointerPressRaycast.gameObject.name == "YellowCell")
        {

        }
    }

}
