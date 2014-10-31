Shader "Custom/sdr_pencil" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf InverseLight
		
		half4 LightingInverseLight ( SurfaceOutput s, half3 lightDir, half atten ) {
			  half NdotL = dot (s.Normal, lightDir);
		      half4 c;
		      c.rgb = (0.1 - s.Albedo) *  (_LightColor0.rgb * (NdotL * atten * 1.0));
		      //c.rgb = (_LightColor0.rgb * (NdotL * atten * 1.0));
		      c.a = s.Alpha;
		      return c;
		}
		
		struct Input {
			float2 uv_MainTex;
		};
		sampler2D _MainTex;
		
		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			//half4 coverColor = tex2D (coverTex, IN.uv_MainTex);
			
			half coverValue = ( c.r + c.g + c.b ) / 3.0;
			//o.Albedo = c.bgr;
			float lightIntensity = ( _LightColor0.r + _LightColor0.g + _LightColor0.b ) * 10.0;
				
			//Everything not in light is white
			o.Albedo = (0.1 - (lightIntensity * c.rgb));
			//o.Albedo = (1.0 - c.rgb) * (lightIntensity );//_LightColor0 * c.rgb;//1.0 - (c.rgb + _ColorTint.rgb);
			//clamp((c.rgb * lightIntensity ) - ( c.rgb * lightIntensity ), 0.0, 1.0);
			
			//o.Alpha = (1.0 - coverValue) * lightIntensity;
			o.Alpha = c.a;// * lightIntensity * ( 1.0 - (coverValue * 1.0 ) );//coverValue * _LightColor0 + _ColorTint;
			//o.Alpha = 1.0;
			//o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap)) * coverValue;
			//o.Alpha = tex2D (_MainTex, IN.uv_MainTex).a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
