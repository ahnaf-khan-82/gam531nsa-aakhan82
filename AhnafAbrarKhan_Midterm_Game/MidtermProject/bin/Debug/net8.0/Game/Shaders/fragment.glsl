#version 330 core
out vec4 FragColor;

in vec3 vFragPos;
in vec3 vNormal;
in vec2 vUV;

uniform vec3 uViewPos;
uniform vec3 lightDir;       

uniform vec3 lightAmbient;
uniform vec3 lightDiffuse;

uniform vec3 lightSpecular;

uniform sampler2D uTexture0;
uniform int  uUseTexture;    
uniform int  uUnlit;       

uniform vec3 uTint;          

uniform float uShininess;

void main()
{
    vec3 baseColor = (uUseTexture == 1)
        ? texture(uTexture0, vUV).rgb
        : uTint;

    if (uUnlit == 1)
    {
        FragColor = vec4(baseColor, 1.0);
        return;
    }

    vec3 N = normalize(vNormal);

    vec3 L = normalize(-lightDir);          
    vec3 V = normalize(uViewPos - vFragPos);
    vec3 R = reflect(-L, N);

    float diff = max(dot(N, L), 0.0);
    float spec = pow(max(dot(R, V), 0.0), uShininess);

    vec3 ambient = lightAmbient * baseColor;
    vec3 diffuse = lightDiffuse * diff * baseColor;
    vec3 specular = lightSpecular * spec;

    vec3 color = ambient + diffuse + specular;
    FragColor = vec4(color, 1.0);
}
