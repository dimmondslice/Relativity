Shader "Custom/sdr_testShader" {
	Properties {
		_ColorTint ("Tint", Color) = (1.0, 0.1, 0.1, 1.0)
		_MainTex ("Color (RGB) Alpha (A)", 2D) = "white" {} 
		//coverTex ("Base (RGB)", 2D) = "white" {}
		//_BumpMap ("Bumpmap", 2D) = "bump" {}
	}
	Category {
		Blend SrcAlpha OneMinusSrcAlpha
		SubShader {
			Tags { "Queue"="Transparent" "RenderType"="Transparent" }
			LOD 200
	
			CGPROGRAM
			#pragma surface surf Lambert alpha
			
			
			sampler2D _MainTex;
			//sampler2D coverTex;
			sampler2D _BumpMap;
			fixed4 _ColorTint;
			//float4 _Bounds;
			//float4 _LightColor0; // automaticly from "Lighting.cginc
	
			struct Input {
				float2 uv_MainTex;
				float2 uv_coverTex;
				float2 uv_BumpMap;
			};
	
			void surf (Input IN, inout SurfaceOutput o) {
				half4 c = tex2D (_MainTex, IN.uv_MainTex);
				//half4 coverColor = tex2D (coverTex, IN.uv_MainTex);
				
				half coverValue = ( c.r + c.g + c.b ) / 3.0;
				//o.Albedo = c.bgr;
				float lightIntensity = ( _LightColor0.r + _LightColor0.g + _LightColor0.b ) * 10.0;
				
				//Everything not in light is white
				o.Albedo = (1.0 - c.rgb) * lightIntensity;//_LightColor0 * c.rgb;//1.0 - (c.rgb + _ColorTint.rgb);
				//clamp((c.rgb * lightIntensity ) - ( c.rgb * lightIntensity ), 0.0, 1.0);
				
				//o.Alpha = (1.0 - coverValue) * lightIntensity;
				o.Alpha = c.a* lightIntensity + lightIntensity;// * lightIntensity * ( 1.0 - (coverValue * 1.0 ) );//coverValue * _LightColor0 + _ColorTint;
				//o.Alpha = 1.0;
				//o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap)) * coverValue;
				//o.Alpha = tex2D (_MainTex, IN.uv_MainTex).a;
				
				
			}
			ENDCG
			
			
			
	
		} 
		FallBack "Diffuse"
	}
}
