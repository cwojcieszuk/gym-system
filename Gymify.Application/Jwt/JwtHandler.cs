﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Gymify.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Gymify.Application.JWT;

public class JwtHandler
{
    private readonly IConfiguration _configuration;
    private readonly IConfigurationSection _jwtSettings;

    public JwtHandler(IConfiguration configuration)
    {
        _configuration = configuration;
        _jwtSettings = _configuration.GetSection("JwtSettings");
    }

    public JwtSecurityToken GenerateTokenOptions(AspNetUser user)
    {
        var tokenOptions = new JwtSecurityToken(
            issuer: _jwtSettings["validIssuer"],
            audience: _jwtSettings["validAudience"],
            claims: GetClaims(user),
            expires: DateTime.Now.AddMinutes(GetRefreshTokenExpiration()),
            signingCredentials: GetSigningCredentials());

        return tokenOptions;
    }
    
    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    public double GetRefreshTokenExpiration()
    {
        return Convert.ToDouble(_jwtSettings["expiryInMinutes"]);
    }
    
    private SigningCredentials GetSigningCredentials()
    {
        var key = Encoding.UTF8.GetBytes(_jwtSettings.GetSection("securityKey").Value);
        var secret = new SymmetricSecurityKey(key);

        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }
    
    private List<Claim> GetClaims(AspNetUser user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        };

        return claims;
    }
}