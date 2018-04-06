using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVisual : MonoBehaviour {
    private const int SAMPLE_SIZE = 1024;

    public GameObject spawnLine;
    public float rmsValue;
    public float dbValue;
    public float pitchValue;
    public float visualModifier = 50.0f;
    public float smoothSpeed = 10.0f;

    private AudioSource source;
    private float[] samples;
    private float[] spectrum;
    private float sampleRate;

    private RectTransform[] visualList;
    private float[] visualScale;
    private int amnVisual = 64;
	void Start () {
        source = Camera.main.GetComponent<AudioSource>();
        samples = new float[SAMPLE_SIZE];
        spectrum = new float[SAMPLE_SIZE];
        sampleRate = AudioSettings.outputSampleRate;

        SpawnLine();
	}
	
	// Update is called once per frame
	void Update () {
        AnalyzeSound();
        UpdateVisual();
	}

    private void UpdateVisual()
    {
        int visualIndex = 0;
        int spectrumIndex = 0;
        int averageSize = SAMPLE_SIZE / amnVisual;

        while (visualIndex < amnVisual)
        {
            int j = 0;
            float sum = 0;

            while(j < averageSize)
            {
                sum += spectrum[spectrumIndex];
                spectrumIndex++;
                j++;
            }

            float scaleY = sum / averageSize * visualModifier;
            visualScale[visualIndex] -= Time.deltaTime * smoothSpeed;

            if (visualScale[visualIndex] < scaleY)
                visualScale[visualIndex] = scaleY;

            visualList[visualIndex].localScale = new Vector3(5, 0.3f, 1) + Vector3.up * visualScale[visualIndex] * 3;
            visualIndex++;
        }
    }
    private void SpawnLine()
    {
        GameObject Visual = GameObject.Find("Visual");
        visualScale = new float[amnVisual];
        visualList = new RectTransform[amnVisual];

        for(int i = 0; i < amnVisual; i++)
        {
            GameObject go = Instantiate(spawnLine, Visual.transform);

            visualList[i] = go.GetComponent<RectTransform>();

            visualList[i].localPosition = new Vector3(1f, 0, 0) * i;

        }
    }
    private void AnalyzeSound()
    {
        source.GetOutputData(samples, 0);
        

        int i = 0;
        float sum = 0;

        for(; i< SAMPLE_SIZE; i++)
        {
            sum += samples[i] * samples[i];
        }

        rmsValue = Mathf.Sqrt(sum / SAMPLE_SIZE);

        //get the dB Value
        dbValue = 20 * Mathf.Log10(rmsValue / 0.1f);

        //get sound spectrum

        source.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

        //find pitch value

        //float maxV = 0;
        //var maxN = 0;
        //for(i = 0; i < SAMPLE_SIZE; i++)
        //{
        //    if (!(spectrum[i] > maxV || !(spectrum[i] > 0.0f)))
        //        continue;

        //    maxV = spectrum[i];
        //    maxN = i;
        //}

        //float freqN = maxN;
        //if(maxN > 0 && maxN < SAMPLE_SIZE - 1)
        //{
        //    var dL = spectrum[maxN - 1] / spectrum[maxN];
        //    var dR = spectrum[maxN + 1] / spectrum[maxN];
        //    freqN += 0.5f * (dR * dR - dL * dL);
        //}

        //pitchValue = freqN * (sampleRate / 2) / SAMPLE_SIZE;
    }
}
