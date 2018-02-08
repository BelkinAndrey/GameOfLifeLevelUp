Shader "CA/RenderShaderGradient" {
	Properties {
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_GradientTex ("Albedo (RGB)", 2D) = "white" {}
	}
	SubShader {
		Pass {
			CGPROGRAM
			
			#pragma vertex vert_img
			#pragma fragment frag

			#include "UnityCG.cginc"

			uniform sampler2D _MainTex;
			uniform sampler2D _GradientTex;

			
			float4 frag(v2f_img i) : COLOR
			{
				float2 uv = i.uv;
                float2 guv = (0.5, tex2D(_MainTex, uv).r);
				float4 a = tex2D(_GradientTex, guv);
				
				return  a;
			}
			ENDCG
		}
		
	}
}
