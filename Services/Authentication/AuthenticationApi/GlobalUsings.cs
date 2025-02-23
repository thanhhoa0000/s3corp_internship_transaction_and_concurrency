﻿global using System.ComponentModel.DataAnnotations;
global using System.Text;
global using System.Security.Cryptography;
global using System.Security.Claims;

global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.IdentityModel.JsonWebTokens;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Design;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.AspNetCore.Http.HttpResults;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using Microsoft.Extensions.Options;
global using Microsoft.OpenApi.Models;

global using Carter;
global using AutoMapper;

global using NLog;
global using NLog.Web;

global using Asp.Versioning;
global using Asp.Versioning.Builder;

global using TaskManagementApp.Services.AuthenticationApi.Models;
global using TaskManagementApp.Services.AuthenticationApi.Models.Dtos;
global using TaskManagementApp.Services.AuthenticationApi.Data;
global using TaskManagementApp.Services.AuthenticationApi.Services;
global using TaskManagementApp.Services.AuthenticationApi.Services.IServices;
global using TaskManagementApp.Services.AuthenticationApi.Repositories;
global using TaskManagementApp.Services.AuthenticationApi.Repositories.IRepositories;

global using TaskManagementApp.SharedLibraries.BaseSharedLibraries.SharedDtos;
global using TaskManagementApp.SharedLibraries.BaseSharedLibraries.SharedEnums;
