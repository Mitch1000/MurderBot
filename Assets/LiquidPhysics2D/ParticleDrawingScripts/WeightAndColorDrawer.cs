﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeightAndColorDrawer : LPDrawParticleSystem
{
	public Color AddColor = Color.white;
	public Color SubtractColor = Color.black;
	
	public AnimationCurve curve;
	
	public float divisor = 5f;
	public float threshold = 0.8f;
	
	public override void UpdateParticles(List<LPParticle> partdata)
	{		
        if (GetComponent<ParticleEmitter>().particleCount < partdata.Count) 
		{
            GetComponent<ParticleEmitter>().Emit(partdata.Count - GetComponent<ParticleEmitter>().particleCount);		
			particles = GetComponent<ParticleEmitter>().particles;
		}
		
		for (int i=0; i < particles.Length; i ++)
		{		
            if (i > partdata.Count - 1)
			{
				particles[i].energy = 0f;
			}
			else
			{
				particles[i].position  = partdata[i].Position;
				
				float val = 1- ( curve.Evaluate(partdata[i].Weight/divisor));
				
				if (val < threshold)
				{
					particles[i].color = Color.Lerp(partdata[i]._Color - SubtractColor,partdata[i]._Color ,val/threshold) ;
				}
				else
				{
					particles[i].color = Color.Lerp(partdata[i]._Color,partdata[i]._Color + AddColor,(val-threshold)/(1f-threshold));
				}				
			}		
		}		
		GetComponent<ParticleEmitter>().particles = particles;
	}
}
