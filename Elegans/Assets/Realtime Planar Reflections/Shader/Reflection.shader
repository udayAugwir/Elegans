// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Realtime Planar Reflections/Reflection" {
	Properties {
		_MainTex            ("Albedo", 2D) = "white" {}
		_ReflectionTex      ("Reflection", 2D) = "black" {}
		_ReflectionTint     ("Reflection Tint", Color) = (1, 1, 1, 1)
		_ReflectionStrength ("Reflection Strength", Range(0,1)) = 1
		_BumpTex            ("Bump", 2D) = "bump" {}
		_BumpStrength       ("Bump Strength", Float) = 0.5
		_MaskTex            ("Mask", 2D) = "black" {}
		_HeightAttenTex     ("Height Atten", 2D) = "black" {}
		_SharpReflectionTex ("Sharp Reflection", 2D) = "black" {}
	}
	SubShader {
		Tags { "RenderType" = "Opaque" "LightMode" = "ForwardBase" }
		Pass {
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile _ RPR_BUMP_REFLECTION
			#pragma multi_compile _ RPR_HEIGHT_ATTEN
			#pragma multi_compile _ LIGHTMAP_ON
			#pragma multi_compile_fwdbase
			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "AutoLight.cginc"
			struct v2f
			{
				float4 pos : POSITION;
				float4 posscr : TEXCOORD0;
				float2 uvMain : TEXCOORD1;
				float4 uvMaskBump : TEXCOORD2;
				float3 nor : TEXCOORD3;
				float3 lit : TEXCOORD4;
#ifdef LIGHTMAP_ON
				half2 uvlm : TEXCOORD5;
#endif
				LIGHTING_COORDS(6, 7)
			};
			sampler2D _MainTex, _ReflectionTex, _MaskTex, _BumpTex, _HeightAttenTex, _SharpReflectionTex;
			float4 _MainTex_ST, _MaskTex_ST, _BumpTex_ST;
			fixed4 _ReflectionTint;
			fixed _BumpStrength, _ReflectionStrength;
			v2f vert (appdata_full v)
			{
				TANGENT_SPACE_ROTATION;
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.posscr = ComputeScreenPos(o.pos);
				o.uvMain = TRANSFORM_TEX(v.texcoord, _MainTex);
				o.uvMaskBump.xy = TRANSFORM_TEX(v.texcoord, _MaskTex);
				o.uvMaskBump.zw = TRANSFORM_TEX(v.texcoord, _BumpTex);
				o.nor = mul(rotation, SCALED_NORMAL);
				o.lit = mul(rotation, ObjSpaceLightDir(v.vertex));
#ifdef LIGHTMAP_ON
				o.uvlm = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
#endif
				TRANSFER_VERTEX_TO_FRAGMENT(o);
				return o;
			}
			fixed4 frag (v2f i) : COLOR
			{
				// lighting
				fixed4 albedo = tex2D(_MainTex, i.uvMain);
				float3 N = normalize(i.nor);
				float3 L = normalize(i.lit);
				albedo.rgb *= (0.5 * dot(N, L) + 0.5);
				
				// mask out which part of surface has reflection
				fixed4 mask = tex2D(_MaskTex, i.uvMaskBump.xy);
				float4 scrpos = i.posscr;
				
				// bumped
#ifdef RPR_BUMP_REFLECTION
				float3 bump = UnpackNormal(tex2D(_BumpTex, i.uvMaskBump.zw)).xyz * _BumpStrength;
				scrpos.xyz += bump.xyz;
#endif

				// the reflection color from reflection map
				half4 refl = tex2Dproj(_ReflectionTex, UNITY_PROJ_COORD(scrpos)) * _ReflectionTint;
				
				// height based atten, need bilateral blur filter I guess. Now it suffers halo problem
#ifdef RPR_HEIGHT_ATTEN
				half maskHeightAtten = tex2Dproj(_HeightAttenTex, UNITY_PROJ_COORD(scrpos)).r;
				half4 sharpRefl = tex2Dproj(_SharpReflectionTex, UNITY_PROJ_COORD(scrpos)) * _ReflectionTint;
				refl.rgb = lerp(refl.rgb, sharpRefl.rgb, maskHeightAtten);
#endif
				
				// compose reflection color and original surface color
				albedo.rgb = lerp(refl.rgb, albedo.rgb, _ReflectionStrength);
				fixed3 c = lerp(albedo.rgb, refl.rgb, mask.r) * _LightColor0 * LIGHT_ATTENUATION(i);
#ifdef LIGHTMAP_ON
				fixed3 lm = DecodeLightmap (UNITY_SAMPLE_TEX2D(unity_Lightmap, i.uvlm));
				c *= lm;
#endif
				return fixed4(c, 1);
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}