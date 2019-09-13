using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visualizer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject audio;
    private float[] spectrumData;
    public ParticleSystem ps;
    ParticleSystem.MainModule psMain;
    ParticleSystem.Particle[] particles;
    int maxParticles;
    public Sprite psImage;
    public float xIntensity = 1f;
    public float yIntensity = 1f;
    public float zIntensity = 1f;
    public float radialIntensity = 1f;
    public float lifeIntensity = 1f;
    public float angularIntensity =1f;
    public float orbitalZIntensity =1f;
    public float orbitalYIntensity =1f;
    public float orbitalXntensity = 1f;

    public float masterScale = 100f;

    void Start()
    {
        maxParticles = audio.GetComponent<Audio>().bufferSize;
        psMain = ps.main;
        //psMain.maxParticles = maxParticles;
        ps.Stop();
        psMain.duration = audio.GetComponent<Audio>().iAmWeather.length;
        ps.Play();





    }

    // Update is called once per frame
    void Update()
    {
    
        if (audio)
        {
            particles = new ParticleSystem.Particle[ps.particleCount];
            ps.GetParticles(particles);
            spectrumData = audio.GetComponent<Audio>().spectrumData;

            for (int i=0; i < particles.Length; i++)
            {
                ParticleSystem.Particle p = particles[i];

                if (i < spectrumData.Length)
                {
                    p.velocity = masterScale* new Vector3(Mathf.Pow(xIntensity *spectrumData[i], xIntensity), Mathf.Pow( yIntensity *spectrumData[i], yIntensity), Mathf.Pow( zIntensity* spectrumData[i], zIntensity));
                  //  p.angularVelocity3D += new Vector3(Mathf.Pow(spectrumData[i], angularIntensity) * angularIntensity, Mathf.Pow(spectrumData[i], angularIntensity) * angularIntensity, Mathf.Pow(spectrumData[i], angularIntensity) * angularIntensity);
                    p.remainingLifetime = Mathf.Pow(masterScale*lifeIntensity* spectrumData[i], lifeIntensity);
                    float dScale = particles.Length / 255f;
                    if (i <= spectrumData.Length / 3 && i >= 0)
                    {

                        p.startColor = new Color(0f, 0f, i / dScale);
                        Color pColor = p.GetCurrentColor(ps);
                        pColor = new Color(0f, 0f, i / dScale);
                        p.color = new Color(0f, 0f, i / dScale);
                    }
                    if (i <= spectrumData.Length * 2 / 3 && i >= spectrumData.Length / 3)
                    {
                        p.startColor = new Color(0f, i / dScale, 255f);
                        Color pColor = p.GetCurrentColor(ps);
                        pColor = new Color(0f, i / dScale, 255f / i);
                        p.color = new Color(0f, i / dScale, 255f / i);
                    }
                    if (i <= spectrumData.Length && i >= spectrumData.Length * 2 / 3)
                    {
                        p.startColor = new Color(i / dScale, 255 / i, 255 / i);
                        Color pColor = p.GetCurrentColor(ps);
                        pColor = new Color(i / dScale, 255 / i, 255 / i);
                        p.color = new Color(i / dScale, 255 / i, 255 / i);
                    }
                    particles[i] = p;
                }
                else
                {
                    float dScale = particles.Length / 255f;
                    if (i <= particles.Length / 3 && i >= 0)
                    {

                        p.startColor = new Color(0f, 0f, i / dScale);
                        Color pColor = p.GetCurrentColor(ps);
                        pColor = new Color(0f, 0f, i / dScale);
                        p.color = new Color(0f, 0f, i / dScale);
                    }
                    if (i <= particles.Length * 2 / 3 && i >= particles.Length / 3)
                    {
                        p.startColor = new Color(0f, i / dScale, 255f);
                        Color pColor = p.GetCurrentColor(ps);
                        pColor = new Color(0f, i / dScale, 255f / i);
                        p.color = new Color(0f, i / dScale, 255f / i);
                    }
                    if (i <= particles.Length && i >= particles.Length * 2 / 3)
                    {
                        p.startColor = new Color(i / dScale, 255 / i, 255 / i);
                        Color pColor = p.GetCurrentColor(ps);
                        pColor = new Color(i / dScale, 255 / i, 255 / i);
                        p.color = new Color(i / dScale, 255 / i, 255 / i);
                    }
                    particles[i] = p;
                }
            }
            ps.SetParticles(particles);

            ParticleSystem.VelocityOverLifetimeModule psVelOverLife = ps.velocityOverLifetime;
            psVelOverLife.orbitalZMultiplier =  orbitalZIntensity * Mathf.Pow(masterScale * orbitalZIntensity * audio.GetComponent<Audio>().GetSpecAverage() , orbitalZIntensity);
            psVelOverLife.orbitalYMultiplier =  orbitalYIntensity * Mathf.Pow(masterScale * orbitalYIntensity * audio.GetComponent<Audio>().GetSpecAverage() , orbitalYIntensity);
            psVelOverLife.orbitalXMultiplier = orbitalXntensity*  Mathf.Pow(masterScale* orbitalXntensity * audio.GetComponent<Audio>().GetSpecAverage() , orbitalXntensity);
            psVelOverLife.radial = radialIntensity *  Mathf.Pow(masterScale * radialIntensity* audio.GetComponent<Audio>().GetSpecAverage(), radialIntensity);
        }
    }
}
