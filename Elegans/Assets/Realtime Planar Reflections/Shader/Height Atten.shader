Shader "Realtime Planar Reflections/Height Atten" {
	Properties {
//		_HaStart ("Height Atten Start", Float) = 0
//		_HaLen  ("Height Atten Length", Float) = 5
	}
	SubShader {
		Tags { "RenderType" = "Opaque" }
		Cull Off

		CGPROGRAM
		#pragma surface surf Unlit
//		half _HaStart, _HaLen;
		struct Input
		{
			float3 worldPos;
		};
		void surf (Input IN, inout SurfaceOutput o)
		{
			float h = IN.worldPos.y;
//			float r = abs(h - _HaStart) / _HaLen;
			float r = 1 - (abs(h - 0) / 0.7);   // bad, I can't pass parameters if I use "RenderWithShader"...
			o.Albedo = fixed3(r, r, r);
			o.Alpha = 1;
		}
		fixed4 LightingUnlit (SurfaceOutput s, half3 lightDir, half atten)
		{
			return fixed4(s.Albedo, s.Alpha);
		}
		ENDCG
	}
	FallBack "Diffuse"
}