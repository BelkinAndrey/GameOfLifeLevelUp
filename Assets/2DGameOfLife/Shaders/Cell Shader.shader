Shader "CA/Cell Shader" {
	Properties {
		_MainTex ("Cells Texture", 2D) = "white" {}
		_Cells("Amount Cells", int) = 1000

	}
	SubShader {
		Pass {
			CGPROGRAM
			
			#pragma vertex vert_img
			#pragma fragment frag

			#include "UnityCG.cginc"

			uniform sampler2D _MainTex;
			uniform float _Cells;

			static int array1[9] = {0, 0, 1, 1, 0, 0, 0, 0, 0 };
			static int array2[9] = { 0, 0, 0, 1, 0, 0, 0, 0, 0 };

			float4 frag(v2f_img i) : COLOR
			{
				float2 uv = i.uv;
				float width = 1 / _Cells;

				//1 2 3
				//4 5 6
				//7 8 9
				float cell1 = tex2D(_MainTex, uv + float2(-width, -width)).r;
				float cell2 = tex2D(_MainTex, uv + float2(     0, -width)).r;
				float cell3 = tex2D(_MainTex, uv + float2(+width, -width)).r;
				float cell4 = tex2D(_MainTex, uv + float2(-width,      0)).r;
				float cell6 = tex2D(_MainTex, uv + float2(+width,      0)).r;
				float cell7 = tex2D(_MainTex, uv + float2(-width, +width)).r;
				float cell8 = tex2D(_MainTex, uv + float2(     0, +width)).r;
				float cell9 = tex2D(_MainTex, uv + float2(+width, +width)).r;

				int neighbors = cell1 + cell2 + cell3 + cell4 + cell6 + cell7 + cell8 + cell9;

				if (tex2D(_MainTex, uv).r == 1)
				{
					return  float4(array1[neighbors], array1[neighbors], array1[neighbors], 1);
				}
				else
				{
					return float4(array2[neighbors], array2[neighbors],  array2[neighbors], 1);
				}

			}
			ENDCG
		}
	}
}
