Shader "Custom/sdr_testShader" {
	Properties {
		_ColorTint ("Tint", Color) = (1.0, 0.1, 0.1, 1.0)
		_MainTex ("Texture", 2D) = "white" {} 
		coverTex ("Base (RGB)", 2D) = "white" {}
		_BumpMap ("Bumpmap", 2D) = "bump" {}
	}
	SubShader {
		Tags { "RenderType" = "Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;
		sampler2D coverTex;
		sampler2D _BumpMap;
		fixed4 _ColorTint;
		float4 _Bounds;
		//float4 _LightColor0; // automaticly from "Lighting.cginc

		struct Input {
			float2 uv_MainTex;
			float2 uv_coverTex;
			float2 uv_BumpMap;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			half4 coverColor = tex2D (coverTex, IN.uv_MainTex);
			
			half coverValue = ( coverColor.r + coverColor.g + coverColor.b ) / 3.0;
			//o.Albedo = c.bgr;
			half lightIntensity = ( _LightColor0.r + _LightColor0.g + _LightColor0.b ) / 3.0;
			
			o.Albedo = lightIntensity * coverColor.rgb + _ColorTint.rgb;
			o.Alpha = 1.0;
			o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap)) * coverValue;
			//o.Alpha = tex2D (_MainTex, IN.uv_MainTex).a;
			
			
		}
		ENDCG

	} 
	FallBack "Diffuse"
}
