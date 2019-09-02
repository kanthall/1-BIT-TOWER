Shader "BBShader/Chromatic_PostEffect_Static"
{
	Properties
	{
	    [HideInInspector] 
		_MainTex ("Texture", 2D) = "white" {}
		_red ("Red Distort", Range (0.00,0.01)) = 0.00 
		_green ("Green Distort", Range (0.00,0.01)) = 0.00 
		_blue ("Blue Distort", Range (0.00,0.01)) = 0.00 

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
						            
			 float _red;
			 float _green;
			 float _blue;


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
                fixed4 colred = tex2D(_MainTex, i.uv+_red);
                fixed4 colgreen = tex2D(_MainTex, i.uv+_green);
                fixed4 colblue = tex2D(_MainTex, i.uv+_blue);
                col.r = colred.r;
                col.g = colgreen.g;
                col.b = colblue.b;

                return col;
            }
			ENDCG
		}
	}
}
