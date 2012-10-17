// Textures
////////////////////////////// 

// entSkin1 ColorMap with alpha
// entSkin2 EffectMask

// Tweakables
//////////////////////////////

//#define GameStudio // make gs-compatible

#define UseSunLight // enable sun light
#define UseSunSpecular // enable sun specular reflections

#define LightBendOver 0.25f // [0 - 1]
#define LightGamma 0.55f

#define SpecularIntensity 0.15f // [0 - 1]
#define SpecularPower 1.0f // [0 - 1]

#define SpecularAddFactor 1.0f // [1+]


#define Luminance 0.5f // enable luminance; luminance intensity (if UseEffectMaskLuminance isn't used)

#define Reflectivity 0.25f // enable reflectivity; (if UseEffectMaskReflectivity isn't used)


#define LuminanceFactor 1.0f
#define LuminanceOverexposure 0.0f

#define ReflectThreshold 0.25f // [0 - <1]

#define SpecularEffectMaskScale 1.75f

#define UseEffectMaskSpecIntensity // enable effect mask specular intensity
#define SpecMaxPower 20.0f
#define SpecPowerIntensityMod 5.0f
#define UseEffectMaskReflectivity // enable effect mask reflectivity
#define UseEffectMaskLuminance // enable effect mask luminance

//#define UseScreenSpaceReflections // enable screen-space reflections

#ifdef GameStudio
	//#define UseNormalmap 0.5f
#endif

/////

#ifdef GameStudio
	#define World matWorld
	#define View matView
	#define Projection matProj
#endif

/////

#define StaticColor

#ifdef StaticColor
   #define GrassCol float3(0.6f, 0.95f, 0.4f)
#endif

//////////////////////////////
// < Code >

float3 vecAmbient;
float3 vecSunColor;
float3 vecSunDir;
float3 vecViewPos;

float4x4 World;
float4x4 View;
float4x4 Projection;

texture entSkin1; // Texture
texture entSkin2; // EffectMask
texture entSkin3; // NormalMap

float3x3 matTangent; // hint for the engine to create tangents in TEXCOORD2

sampler sColorMap = sampler_state
{
	Texture = <entSkin1>;
	MipFilter = Linear;
	#ifdef GameStudio
		MagFilter = None;
	#endif
	AddressU = Clamp;
	AddressV = Clamp;
};

sampler sEffectMask = sampler_state // R = Specular Intensity, G = Reflectivity, B = Luminance
{
	Texture = <entSkin2>;
	MipFilter = Linear;
	#ifdef GameStudio
		MagFilter = None;
	#endif
	AddressU = Clamp;
	AddressV = Clamp;
};

sampler sNormalMap = sampler_state
{
	Texture = <entSkin3>;
	MipFilter = Linear;
	MagFilter = None;
	AddressU = Clamp;
	AddressV = Clamp;
};

struct VertexShaderInput
{
	float4 Position : POSITION0;
	float2 Tex : TEXCOORD0;
	float3 Normal : NORMAL;
	
	#ifdef UseNormalmap
		float4 Tangent : TEXCOORD2;
	#endif
};

struct VertexShaderOutput
{
	float4 Position : POSITION0;
	float2 Tex : TEXCOORD0;
	float3 Normal : TEXCOORD1;
	float3 ViewDir : TEXCOORD2;
	
	#ifdef UseNormalmap
		float3x3 Tangent : TEXCOORD3;
	#endif
};

VertexShaderOutput VertexShaderFunction(VertexShaderInput input)
{
	VertexShaderOutput output;
	
	float4 worldPosition = mul(input.Position, World);
	float4 viewPosition = mul(worldPosition, View);
	output.Position = mul(viewPosition, Projection);
	
	output.Tex = input.Tex;
	
	output.Normal = input.Normal;
	
	output.ViewDir = vecViewPos - mul(input.Position, World); 
	
	#ifdef UseNormalmap
		output.Tangent[0] = mul(input.Tangent.xyz, matWorld); 
		output.Tangent[1] = mul(cross(input.Tangent.xyz, input.Normal), matWorld); 
		output.Tangent[2] = mul(input.Normal, matWorld); 
	#endif
	
	return output;
}

float4 PixelShaderFunction(VertexShaderOutput input) : COLOR0
{
	/////
	
	float4 Color = tex2D(sColorMap, input.Tex); // read the texture
	
	clip(Color.a < 0.1f ? -1:1 );

	int Tile[2];
	Tile [0] = (int)(input.Tex.x * 16) + 1;
	Tile [1] = (int)(input.Tex.y * 16) + 1;
	
	if(Tile[0] == 1 && Tile[1] == 1 || Tile[0] == 9 && Tile[1] == 4 || Tile[0] == 5 && Tile[1] == 4 || Tile[0] == 8 && Tile[1] == 3 || Tile[0] == 5 && Tile[1] == 9 || Tile[0] == 5 && Tile[1] == 13) 
	{
	    Color.rgb *= GrassCol;
	}
	
	if(Tile[0] == 4 && Tile[1] == 1) // Grass Side
	{
		float4 GrassTex = tex2D(sColorMap, input.Tex + float2((1.0f / 16.0f) * 3.0f, (1.0f / 16.0f) * 2.0f)) * float4(GrassCol, 1.0f);
	    Color.rgb = Color.rgb * (1.0f - GrassTex.a) + GrassTex.rgb;
	}
	
	float3 EffectMask = tex2D(sEffectMask, input.Tex).rgb; // read the effect mask
//	float4 LightMap = tex2D(sLightMap, input.Tex); // read the light map | not implemented, yet
	
	float3 LightDiffuse = 0.0f;
	float4 LightSpecular = 0.0f;
	
	#ifdef UseNormalmap
		float2 NormalMap = tex2D(sNormalMap, input.Tex).rg;
		input.Normal = normalize(input.Normal + (NormalMap.r * input.Tangent[0] + NormalMap.g *  input.Tangent[1]) * UseNormalmap);
	#else
		input.Normal = normalize(input.Normal);
	#endif
	
	/////
	
	#ifdef UseScreenSpaceReflections // keep the reflectivity factor
		float ScreenSpaceReflectivity = saturate(EffectMaks.g * Color.a - ReflectThreshold) / (1.0f - ReflectThreshold);
	#endif
	
	#ifndef UseEffectMaskSpecIntensity // is spec intensity used instead of EffectMask.r ?
		EffectMask.r = SpecularIntensity * (1.0f + EffectMask.g * SpecPowerIntensityMod);
	#else
		EffectMask.r *= SpecularEffectMaskScale * (1.0f + EffectMask.g * SpecPowerIntensityMod);
	#endif
	
	#ifndef UseEffectMaskReflectivity // is spec power used instead of EffectMask.g ?
		EffectMask.g = SpecularPower;
	#else
		EffectMask.g *= 1.5f;
		EffectMask.g = (pow(EffectMask.g + 1.0f, 8) - 1.0f) * SpecMaxPower + 1; // calculate specular power from effect-mask [0 - 50]
	#endif
	
	#ifndef UseEffectMaskLuminance // is luminance used instead of EffectMask.b ?
		#ifdef Luminance
			EffectMask.b = Luminance;
		#endif
	#endif
	
	
	EffectMask.b = EffectMask.b * (1.0f - (Color.r + Color.g + Color.b) / 3) * 0.5f + EffectMask.b * 0.5f; // modify luminance-map
	
	// calculate modificated specular information based on effect mask or the #defines
//	EffectMask.rg = float2(EffectMask.r * (EffectMask.g / 32.0f), EffectMask.g); // x = specular intensity, y = specular power
	
	float3 R;
	
	#ifdef UseSunLight //--------------- UseSunLight
		
		float3 SunDirection = normalize(vecSunDir);
		
		//#ifdef GameStudio
		//	SunDirection *= -1;
		//#endif
		
		float SunNormalDot = dot(input.Normal, SunDirection);
		
		LightDiffuse += pow(abs(saturate(SunNormalDot + LightBendOver) * vecSunColor), LightGamma); // UseSunLight diffuse
		
		#ifdef UseSunSpecular // UseSunLight specular
			R = normalize(2 * saturate(dot(input.Normal, SunDirection)) * input.Normal + vecSunDir);
			
			LightSpecular.rgb += pow(saturate(dot(R, normalize(input.ViewDir))), EffectMask.g) * vecSunColor * EffectMask.r;
		#endif
		
	#endif //---------------
	
	if(EffectMask.b)
		LightDiffuse += LuminanceFactor * ((saturate(EffectMask.b * (1.0f - (LightDiffuse.r - LightDiffuse.g - LightDiffuse.b) / 3.0f)) * LuminanceOverexposure) + EffectMask.b) / (1.0f + LuminanceOverexposure);
	
	// Combine
	
	float LightIntensity = LightDiffuse.r * 0.333f + LightDiffuse.g * 0.333f + LightDiffuse.b * 0.333f; // calculate overall light brightness
	
	Color.rgb = saturate(Color * vecAmbient * (1.0f - LightIntensity)) + Color * LightDiffuse; // calculate the final color (light additive blending + ambient alpha blending)
	
	LightSpecular.a = (LightSpecular.r + LightSpecular.g + LightSpecular.b) / 3 * Color.a; // calculate the alpha
	
	if(LightSpecular.a > 0)
	{
		//Color.rgb += LightSpecular.rgb;
		LightSpecular.rgb /= LightSpecular.a;
		Color.rgb = (Color.rgb * (1.0f - LightSpecular.a) + LightSpecular.rgb * LightSpecular.a * SpecularAddFactor) / SpecularAddFactor;
	}

	//

	return Color;
}

technique Technique1
{
	pass Pass1
	{
		AlphaBlendEnable = TRUE;
		
		//DestBlend = INVSRCALPHA;
		//SrcBlend = SRCALPHA;
		//zWriteEnable = true;
		
		VertexShader = compile vs_3_0 VertexShaderFunction();
		PixelShader = compile ps_3_0 PixelShaderFunction();
	}
}
