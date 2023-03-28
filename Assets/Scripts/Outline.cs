using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour
{
    [SerializeField] Material OutlineMaterial;
    bool HoveringDamageable;
    bool HoveringNonDamageable;

    Renderer OBJRenderer; //objects renderer
    Material[] RendererMaterials; //objects materials
    Material[] MaterialsWithOutline; //list of new materials

    // Start is called before the first frame update
    void Start()
    {
        OBJRenderer = GetComponent<Renderer>(); //objects renderer
        RendererMaterials = OBJRenderer.materials; //objects materials
        MaterialsWithOutline = new Material[RendererMaterials.Length + 1]; //list of new materials

        for (int i = 0; i < RendererMaterials.Length; i++) //put all obj materials into new mat array
        {
            MaterialsWithOutline[i] = RendererMaterials[i];
        }

        MaterialsWithOutline[RendererMaterials.Length] = OutlineMaterial; //set last mat of new mat array to outline mat


        //OBJRenderer.materials = MaterialsWithOutline; //ouline renderer material
        OBJRenderer.materials = RendererMaterials; //default render materials
    }

    // Update is called once per frame
    void Update()
    {
        //////////////////Outline//////////////////
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform.gameObject.tag == "Damageable")
            {
                OBJRenderer.materials = MaterialsWithOutline; //ouline renderer material
            }
            else
            {
                if (OBJRenderer.materials != RendererMaterials)
                {
                    OBJRenderer.materials = RendererMaterials; //ouline renderer material
                }
            }
        }
    }
}
