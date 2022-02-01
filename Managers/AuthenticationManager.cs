using Microsoft.AspNetCore.Identity;
using ProiectSK8.Entities;
using ProiectSK8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectSK8.Managers
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly ITokenManager tokenManager;
        
        public AuthenticationManager(UserManager<User> userManager, SignInManager<User> sign, ITokenManager token)
        {
            this.userManager = userManager;
            this.signInManager = sign;
            this.tokenManager = token;
        }
        public async Task<TokensModel> Login(LoginModel loginModel)
        {
            var user = await userManager.FindByEmailAsync(loginModel.Email);
            if (user != null)
            {
                var result = await signInManager.CheckPasswordSignInAsync(user, loginModel.Password, true);
                if (result.Succeeded)
                {
                    var token = await tokenManager.GenerateToken(user);

                    return new TokensModel
                    {
                        AccessToken = token
                    };
                }
            }
            return null;
        }

        public async Task Signup(RegisterModel registerModel)
        {
            var user = new User
            {
                Email = registerModel.Email,
                UserName = registerModel.Email
            };

            var result = await userManager.CreateAsync(user, registerModel.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, registerModel.Role);
            }
        }
    }
}
