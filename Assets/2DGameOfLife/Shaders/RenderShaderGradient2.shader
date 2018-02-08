Shader "CA/RenderShaderGradient2" {
	Properties {
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_GradientTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5

	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _GradientTex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;

		UNITY_INSTANCING_CBUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_CBUFFER_END

		void surf (Input IN, inout SurfaceOutputStandard o) {

			float2 guv = (0.5, tex2D (_MainTex, IN.uv_MainTex).r);


			fixed4 c = tex2D (_GradientTex, guv);
			o.Albedo = c.rgb;

			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
