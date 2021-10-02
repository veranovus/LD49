#version 330

// Input vertex attributes (from vertex shader)
in vec2 fragTexCoord;
in vec4 fragColor;

// Input uniform values
uniform sampler2D texture0;
uniform vec4 colDiffuse;

// Output fragment color
out vec4 finalColor;

// NOTE: Add here your custom variables
uniform vec4 u_Color;

void main()
{
    // Texel color fetching from texture sampler
    vec4 texelColor = texture(texture0, fragTexCoord);
    
    // NOTE: Implement here your fragment shader code
    if (texelColor == vec4(1.0f, 0.0f, 0.0f, 1.0f)) {
        finalColor = u_Color;
    }
    else {
        finalColor = texelColor; // colDiffuse
    }
}