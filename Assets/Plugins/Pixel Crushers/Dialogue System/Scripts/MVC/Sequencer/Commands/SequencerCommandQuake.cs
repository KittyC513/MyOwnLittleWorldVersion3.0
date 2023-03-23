using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
    public class SequencerCommandQuake : SequencerCommand
    {
        Vector3 originalPos;
        float shakeDuration;
        // Start is called before the first frame update
        void Start()
        {
            shakeDuration = GetParameterAsFloat(0);
            originalPos = Camera.main.transform.localPosition;

        }

        // Update is called once per frame
        void Update()
        {
            if(shakeDuration > 0)
            {
                Camera.main.transform.localPosition = originalPos + Random.insideUnitSphere * 0.1f;
                shakeDuration -= Time.deltaTime;
            }
            else
            {
                Camera.main.transform.localPosition = originalPos;
                Stop();
            }
        }
    }

}
