Shader "Custom/WaterShader" {
    Properties {
        _Color ("Water Color", Color) = (0.0, 0.5, 1.0, 1.0)
        _MainTex ("Base (RGB)", 2D) = "white" { }
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _Amplitude ("Wave Amplitude", Range(0, 1)) = 0.1
        _WaveLength ("Wave Length", Range(0, 10)) = 1.0
        _WaveSpeed ("Wave Speed", Range(0, 5)) = 1.0
        _Direction ("Wave Direction", Vector) = (1, 0, 0, 0)
        _Steepness ("Wave Steepness", Range(0, 1)) = 0.5
        _NormalScale ("Normal Scale", Range(0, 1)) = 0.5
        _FoamIntensity ("Foam Intensity", Range(0, 1)) = 0.1
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 100

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        struct Input {
            float2 uv_MainTex;
        };

        fixed4 _Color;
        sampler2D _MainTex;
        fixed _Glossiness;
        fixed _Metallic;
        fixed _Amplitude;
        fixed _WaveLength;
        fixed _WaveSpeed;
        float4 _Direction;
        fixed _Steepness;
        fixed _NormalScale;
        fixed _FoamIntensity;

        void surf(Input IN, inout SurfaceOutputStandard o) {
            float wave = _Amplitude * _Steepness * _FoamIntensity * sin(dot(IN.uv_MainTex, _Direction.xy) * _WaveLength + _Time.y * _WaveSpeed);
            float3 normal = float3(0, wave, 1);
            normal = normalize(normal);
            normal *= _NormalScale;

            o.Normal = UnityObjectToWorldNormal(normal);
            o.Albedo = _Color.rgb;
            o.Alpha = 1.0;
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
