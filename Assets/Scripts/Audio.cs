using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip iAmWeather;
    public AudioSource audioSource;

    public float sampleRate;
    public int bufferSize = 2048;

    public float arraySize;
    public float[] spectrumData;
    public float[] outputData;
    public float output;
    
        void Start()
    {
        sampleRate = AudioSettings.outputSampleRate;
        arraySize = sampleRate / 2f;
        bufferSize = 2048;
        spectrumData = audioSource.GetSpectrumData(bufferSize, 0, FFTWindow.BlackmanHarris);
        audioSource.GetOutputData(outputData, 0);

        
    }

    internal float GetSpecAverage()
    {
        float avg = 0f;
        float sum = 0f;
       foreach (float amp in spectrumData)
        {
            sum += amp;
        }
       avg = sum/spectrumData.Length;
        return avg;
    }

    internal void Play()
    {
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
      //  spectrumData = audioSource.GetSpectrumData(bufferSize, 0, FFTWindow.BlackmanHarris);
        AudioListener.GetSpectrumData(spectrumData, 0, FFTWindow.Rectangular);
        audioSource.GetOutputData(outputData, 0);

        //   print("Spectrum Data...");
        //   print(spectrumData);

        //   print("Output Data..");
        //   print(outputData);
    }

    internal void Pause()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.Play();
        }
            
    }
}
