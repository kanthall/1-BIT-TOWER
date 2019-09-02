Shader "BBShader/ColorClamp_Transparent"
{
	Properties
	{
		_intensity ("Clamp Intensity", Range(0,1)) = 1
	}
	SubShader
    {
        Tags { "Queue" = "Transparent" }
        
        	//	Cull Off ZWrite Off ZTest Always

 
        GrabPass
        {
            "_GrabTexture"
        }
 
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
 
            #include "UnityCG.cginc"
             
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
 
            struct v2f
            {
                float4 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
            
            float _intensity;
 
            v2f vert (appdata v)
            {
                v2f o;
                //o.vertex = UnityObjectToClipPos(v.vertex);

                o.vertex = UnityObjectToClipPos(v.vertex);
			
                o.uv = ComputeGrabScreenPos(o.vertex);

                

                return o;
            }
 
            sampler2D _GrabTexture;
 
            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2Dproj(_GrabTexture, i.uv);
                
                col.r = round(col.r/_intensity) * _intensity;
                col.g = round(col.g/_intensity) * _intensity;
                col.b = round(col.b/_intensity) * _intensity;


                return col;
            }
            ENDCG
		}
	}
}
