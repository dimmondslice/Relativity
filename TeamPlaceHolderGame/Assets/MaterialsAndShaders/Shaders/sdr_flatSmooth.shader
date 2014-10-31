Shader "Custom/sdr_flatSmooth" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf SmoothLight
		
		half4 LightingSmoothLight ( SurfaceOutput s, half3 lightDir, half atten ) {
			  half NdotL = dot (s.Normal, lightDir);
		      half4 c;
		      c.rgb = (-_LightColor0.rgb * (NdotL * atten * 1)) * 10.0;

		      c.a = s.Alpha;
		      return c;
		}

		sampler2D _MainTex;
		float4 _Color;

		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			float lightIntensity = ( _LightColor0.r + _LightColor0.g + _LightColor0.b ) * 0.3;
			o.Albedo = c.rgb * lightIntensity + _Color;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
