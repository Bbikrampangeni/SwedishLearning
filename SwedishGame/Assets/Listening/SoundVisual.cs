using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVisual : MonoBehaviour {
    private const int SAMPLE_SIZE = 1024;

    public float rmsValue;
    public float dbValue;
    public float pickValue;

    private AudioSource source;
    private float[] samples;
    private float[] spectrum;
    private float sampleRate;


	void Start () {
        source = Camera.main.GetComponent<AudioSource>();
        samples = new float[SAMPLE_SIZE];
        spectrum = new float[SAMPLE_SIZE];
        sampleRate = AudioSettings.outputSampleRate;
	}
	
	// Update is called once per frame
	void Update () {
        AnalyzeSound();
	}

    private void AnalyzeSound()
    {
        source.GetOutputData(samples, 0);

        //Get the RMS

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
    }
}
