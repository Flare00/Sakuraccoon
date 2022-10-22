using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class PSEffect : MonoBehaviour
{
    private List<Particle> particles;

    private class Particle
    {
        public GameObject go;
        public List<ParticleSystem> ps;

        public Particle()
        {
            ps = new List<ParticleSystem>();
        }

        public void AddAll(ParticleSystem[] arrayPS)
        {
            foreach (ParticleSystem p in arrayPS)
            {
                ps.Add(p);
            }
        }

        public bool IsEnd()
        {
            bool end = true;

            for (int i = 0; i < ps.Count && end; i++)
            {
                if (ps[i] != null && ps[i].IsAlive())
                {
                    end = false;
                }
            }

            if (end)
            {
                End();
            }

            return end;
        }

        public void End()
        {
            ps.Clear();
            GameObject.Destroy(go);
        }

        public void Play()
        {
            if (go != null)
            {
                for (int i = 0; i < ps.Count; i++)
                {
                    ps[i].Play();
                }
            }
        }

        public void Flip()
        {
            if (go != null) { 
                for (int i = 0, max = go.transform.childCount; i < max; i++)
                {
                    Transform g = go.transform.GetChild(i);
                    g.localScale = new Vector3(-g.localScale.x, g.localScale.y, g.localScale.z);
                }
            }
        }
    }

    public enum EffectType
    {
        Jump,
        Dash
    }

    private void Start()
    {
        particles = new List<Particle>();
    }

    private void Update()
    {
        for (int i = particles.Count - 1; i >= 0; i--)
        {
            if (particles[i].IsEnd())
            {
                particles.RemoveAt(i);
            }
        }
    }

    public void AddEffect(EffectType type, bool direction=true)
    {
        Particle tmp = new Particle();

        switch (type)
        {
            case EffectType.Jump:
                tmp.go = GameObject.Instantiate(Resources.Load("ParticlesSystem/PS_Jump", typeof(GameObject))) as GameObject;
                break;
            case EffectType.Dash:
                tmp.go = GameObject.Instantiate(Resources.Load("ParticlesSystem/PS_Dash", typeof(GameObject))) as GameObject;
                break;
            default:
                tmp = null;
                break;

        }

        if (tmp != null)
        {
            
            tmp.AddAll(tmp.go.GetComponentsInChildren<ParticleSystem>());
            tmp.go.transform.SetParent(gameObject.transform, false);
            if (!direction)
            {
                tmp.Flip();
            }
            tmp.Play();
            particles.Add(tmp);
        }
    }

    public void stopEveryParticle()
    {
        foreach (Particle p in particles)
        {
            p.End();
        }
    }

    public void Flip()
    {
        foreach (Particle p in particles)
        {
            p.Flip();
        }
    }
}
