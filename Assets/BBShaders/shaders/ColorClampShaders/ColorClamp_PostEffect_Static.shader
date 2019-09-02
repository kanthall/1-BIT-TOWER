Shader "BBShader/ColorClamp_PostEffect_Static"
{
	Properties
	{
	    [HideInInspector] 
		_MainTex ("Texture", 2D) = "white" {}
		_intensity ("Clamp Intensity", Range(0.01,1)) = 1
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			
            float _intensity;

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                col.r = round(col.r/_intensity) * _intensity;
                col.g = round(col.g/_intensity) * _intensity;
                col.b = round(col.b/_intensity) * _intensity;

                return col;
            }
			ENDCG
		}
	}
}