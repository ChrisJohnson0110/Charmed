using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using System;


[Serializable]
[PostProcess(typeof(PostProcessOutlineRenderer), PostProcessEvent.AfterStack, "Outline")]
public sealed class PostProcessOutline : PostProcessEffectSettings
{
    
}
