Shader "Custom/flashColorShader"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,0)
        [MaterialToggle] PixelSnap ("PixelSnap", Float) = 0

    }
    SubShader
    {
      Tags
      {
        "Queue" = "Transparent"
        "IgnoreProjector"="True"
        "RenderType" = "Transparent"
        "PreviewType" = "Plane"
        "CanUseSpriteAtlas" = "True"
      }

      Cull Off
      Lighting Off
      ZWrite Off
      Blend One OneMinusSrcAlpha


      Pass
      {
        CGProgram
          #pragma vertex vert
          #pragma fragment frag
          #pragma multi_compile _ PIXELSNAP_ON
          #include "UnityCG.cginc"

          struct appdata_t
          {
            float4 vertex : POSITION;
            float4 color : COLOR;
            float2 texcoord : TEXCOORD0;
          };

          struct v2f
          {
            float4 vertex :SV_POSITION;
            fixed4 color :COLOR;
            float2 texcoord : TEXCOORD0;
            };

            fixed4 _Color;


        }
    }
    FallBack "Diffuse"
}
