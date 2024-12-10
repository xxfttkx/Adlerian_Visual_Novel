// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Test"
{
    Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
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
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
                // fixed4 color : TEXCOORD0;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
				// fixed4 col = i.color
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
                // ---------这里是修改为灰度值--------
				float val = 0.03;
				float s = 300;
				float x = floor(i.uv.x * s)/s;
				float y = floor(i.uv.y * s)/s;
				fixed4 c = tex2D(_MainTex, float2(i.uv.x,i.uv.y));
				// c+=tex2D(_MainTex, float2(i.uv.x+val*(i.uv.x-0.5),i.uv.y+val*(i.uv.y-0.5)));
				// c+=tex2D(_MainTex, float2(i.uv.x+val*2*(i.uv.x-0.5),i.uv.y+val*2*(i.uv.y-0.5)));
				// c = c/3;
				c = tex2D(_MainTex, float2(x,y));
				return c;
			}
			ENDCG
		}
	}
}
