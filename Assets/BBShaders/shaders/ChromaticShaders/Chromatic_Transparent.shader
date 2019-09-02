Shader "BBShader/Chromatic_Transparent"
{
	Properties
	{
		_red ("Red Distort", Range (0.00,0.1)) = 0.00 
		_green ("Green Distort", Range (0.00,0.1)) = 0.00 
		_blue ("Blue Distort", Range (0.00,0.1)) = 0.00 
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
                float4 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
 
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
                fixed4 colred = tex2Dproj(_GrabTexture, i.uv+_red);
                fixed4 colgreen = tex2Dproj(_GrabTexture, i.uv+_green);
                fixed4 colblue = tex2Dproj(_GrabTexture, i.uv+_blue);

                
                
                col.r = colred.r;
                col.g = colgreen.g;
                col.b = colblue.b;
                return col;
            }
            ENDCG
		}
	}
}
