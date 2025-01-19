global using System.Text;
global using System.Security.Claims;

global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.Extensions.Hosting;
global using Microsoft.OpenApi.Models;

global using PagePass.Domain.Interfaces;
global using PagePass.Domain.Account;

global using PagePass.Application.Interfaces;
global using PagePass.Application.Mappings;
global using PagePass.Application.Services;

global using PagePass.Infrastructure.Repositories;
global using PagePass.Infrastructure.Data;
global using PagePass.Infrastructure.Identity;






