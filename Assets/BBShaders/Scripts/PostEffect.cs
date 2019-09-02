
using UnityEngine;

[ExecuteInEditMode]
public class PostEffect : MonoBehaviour
{


	public Material mat;
	

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		Graphics.Blit(src, dest, mat);
	}

}
