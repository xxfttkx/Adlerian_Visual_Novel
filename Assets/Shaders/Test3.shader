// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Test3"
{
    Properties
	{
		_MainTex1 ("Texture", 2D) = "white" {}
		_MainTex2 ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOaORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
                // fixed4 color : TEXCOORD0;
			};

			sampler2D _MainTex1;
			sampler2D _MainTex2;
			float4 _MainTex1_ST;
			float4 _MainTex2_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
 				o.uv = TRANSFORM_TEX(v.uv, _MainTex1);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			fixed progress=0;
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col1 = tex2D(_MainTex1, i.uv);
				fixed4 col2 = tex2D(_MainTex2, i.uv);
				// fixed4 col = i.color
				// apply fog
				// UNITY_APPLY_FOG(i.fogCoord, col);
				fixed a = frac(_Time.y);
				fixed flag = floor(_Time.y)%2;
				if (progress >= 1) {
					a=0; // 将时间设置为动画结束的时间，以停止动画
				}
				if(a==1){
					progress = 1;
				}
				fixed4 c = flag==1?a*col1 + (1-a)*col2:(1-a)*col1 + a*col2;
				return c;
			}
			ENDCG
		}
	}
}
