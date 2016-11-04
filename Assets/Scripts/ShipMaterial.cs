using UnityEngine;
using System.Collections;

public class ShipMaterial : MonoBehaviour {

    private Renderer rend;

    private Texture textureUsed;

    public ParticleSystem particles;

	void Start ()
    {
        rend = GetComponent<Renderer>();               
	}

	void Update ()
    {
	
	}

    public void changeTexture(Texture texture)
    {
        rend.material.mainTexture = texture;
    }

    public void SetTexture(Texture texture)
    {
        textureUsed = texture;
        PlayFire();
    }

    public void ResetTexture()
    {
        rend.material.mainTexture = textureUsed;
    }

    void PlayFire()
    {
        particles.Play();
    }
}
