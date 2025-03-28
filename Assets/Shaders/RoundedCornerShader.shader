Shader "Custom/RoundedCornerShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Radius ("Radius", Float) = 0.1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200
        
        CGPROGRAM
        #pragma surface surf Lambert
        
        sampler2D _MainTex;
        float _Radius;
        
        struct Input
        {
            float2 uv_MainTex;
        };
        
        void surf (Input IN, inout SurfaceOutput o)
        {
            float3 pos = float3(0,0,0); // Center of cube
            float3 normal = float3(0,0,0); // Normal of cube surface
            
            // Calculate distance from center
            float dist = length(IN.uv_MainTex - pos.xy);
            
            // Apply rounding if within radius
            if (dist < _Radius)
            {
                float blend = dist / _Radius;
                pos += normal * (_Radius - dist);
            }
            
            o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
            o.Alpha = 1.0;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
