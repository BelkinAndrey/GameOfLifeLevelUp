Shader "CA/Cell ShaderUp" {
	Properties {
		_MainTex ("Cells Texture", 2D) = "white" {}
		_Cells("Amount Cells", int) = 1000

		_Birth0("Birth0", int) = 0
		_Birth1("Birth1", int) = 0
		_Birth2("Birth2", int) = 0
		_Birth3("Birth3", int) = 1
		_Birth4("Birth4", int) = 0
		_Birth5("Birth5", int) = 0
		_Birth6("Birth6", int) = 0
		_Birth7("Birth7", int) = 0
		_Birth8("Birth8", int) = 0

		_Up0("Up0", int) = 0
		_Up1("Up1", int) = 0
		_Up2("Up2", int) = 1
		_Up3("Up3", int) = 1
		_Up4("Up4", int) = 0
		_Up5("Up5", int) = 0
		_Up6("Up6", int) = 0
		_Up7("Up7", int) = 0
		_Up8("Up8", int) = 0

		_Death0("Death0", int) = 0
		_Death1("Death1", int) = 1
		_Death2("Death2", int) = 0
		_Death3("Death3", int) = 0
		_Death4("Death4", int) = 1
		_Death5("Death5", int) = 1
		_Death6("Death6", int) = 1
		_Death7("Death7", int) = 0
		_Death8("Death8", int) = 0 

		_Down0("Down0", int) = 1
		_Down1("Down1", int) = 0
		_Down2("Down2", int) = 0
		_Down3("Down3", int) = 0
		_Down4("Down4", int) = 0
		_Down5("Down5", int) = 0
		_Down6("Down6", int) = 0
		_Down7("Down7", int) = 1
		_Down8("Down8", int) = 1

		_MaxLevel("Max Level", Range (1, 100)) = 10
		_KillMaxUp("Kill Max Up", int) = 0
	}
	SubShader {
		Pass {
			CGPROGRAM
			
			#pragma vertex vert_img
			#pragma fragment frag

			#include "UnityCG.cginc"

			uniform sampler2D _MainTex;
			uniform float _Cells;

			uniform int _Birth0;
			uniform int _Birth1;
			uniform int _Birth2;
			uniform int _Birth3;
			uniform int _Birth4;
			uniform int _Birth5;
			uniform int _Birth6;
			uniform int _Birth7;
			uniform int _Birth8;

			uniform int _Up0;
			uniform int _Up1;
			uniform int _Up2;
			uniform int _Up3;
			uniform int _Up4;
			uniform int _Up5;
			uniform int _Up6;
			uniform int _Up7;
			uniform int _Up8;

			uniform int _Death0;
			uniform int _Death1;
			uniform int _Death2;
			uniform int _Death3;
			uniform int _Death4;
			uniform int _Death5;
			uniform int _Death6;
			uniform int _Death7;
			uniform int _Death8;

			uniform int _Down0;
			uniform int _Down1;
			uniform int _Down2;
			uniform int _Down3;
			uniform int _Down4;
			uniform int _Down5;
			uniform int _Down6;
			uniform int _Down7;
			uniform int _Down8;

			uniform float _MaxLevel;
			uniform int _KillMaxUp;

			float Border(float a)
			{
				float f = a;
				if (a < 0) f = 1 - a;
				if (a > 1) f = a - 1;
				return f;
			}

			float2 BorderOff(float2 uv)
			{
				return float2(Border(uv[0]), Border(uv[1]));
			}


			float4 frag(v2f_img i) : COLOR
			{

				int Birth[9] = {_Birth0, _Birth1, _Birth2, _Birth3, _Birth4, _Birth5, _Birth6, _Birth7, _Birth8}; 
		        int Up[9] = {_Up0, _Up1, _Up2, _Up3, _Up4, _Up5, _Up6, _Up7, _Up8};
			    int Death[9] = {_Death0, _Death1, _Death2, _Death3, _Death4, _Death5, _Death6, _Death7, _Death8};
			    int Down[9] = {_Down0, _Down1, _Down2, _Down3, _Down4, _Down5, _Down6, _Down7, _Down8};



				float2 uv = i.uv;
				float width = 1 / _Cells;

				//1 2 3
				//4 5 6
				//7 8 9

				int calc = 0;

				if (tex2D(_MainTex, BorderOff(uv + float2(-width, -width))).r > 0) calc++;
				if (tex2D(_MainTex, BorderOff(uv + float2(     0, -width))).r > 0) calc++;
				if (tex2D(_MainTex, BorderOff(uv + float2(+width, -width))).r > 0) calc++;
				if (tex2D(_MainTex, BorderOff(uv + float2(-width,      0))).r > 0) calc++;
				if (tex2D(_MainTex, BorderOff(uv + float2(+width,      0))).r > 0) calc++;
				if (tex2D(_MainTex, BorderOff(uv + float2(-width, +width))).r > 0) calc++;
				if (tex2D(_MainTex, BorderOff(uv + float2(     0, +width))).r > 0) calc++;
				if (tex2D(_MainTex, BorderOff(uv + float2(+width, +width))).r > 0) calc++;
				

				float level = 0;
				float levelR = tex2D(_MainTex, uv).r * _MaxLevel;


				if ((levelR == 0) && (Birth[calc] == 1)) levelR = 1;
				if ((levelR > 0)  && (Up[calc] == 1)) levelR++;
				if ((levelR > 0) && (Death[calc] == 1)) levelR = 0;
				if ((levelR > 0) && (Down[calc] == 1)) levelR--;

				if (levelR > _MaxLevel) 
					if (_KillMaxUp > 0) levelR = 0; 
					else levelR = _MaxLevel;
				

				if (levelR > 0) level = levelR / _MaxLevel;

			    return float4(level, level, level, 1);
			}
			ENDCG
		}
	}
}
