﻿global using System.ComponentModel.DataAnnotations;
global using System.Text;
global using System.Text.Json;

global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Design;
global using Microsoft.AspNetCore.Http.HttpResults;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.OpenApi.Models;

global using Carter;
global using AutoMapper;

global using NLog;
global using NLog.Web;

global using Asp.Versioning;
global using Asp.Versioning.Builder;

global using TaskManagementApp.Services.UsersApi.Models;
global using TaskManagementApp.Services.UsersApi.Models.Dtos;
global using TaskManagementApp.Services.UsersApi.Data;
global using TaskManagementApp.Services.UsersApi.Repositories;
global using TaskManagementApp.Services.UsersApi.Repositories.IRepositories;

global using TaskManagementApp.SharedLibraries.BaseSharedLibraries.Repositories;
global using TaskManagementApp.SharedLibraries.BaseSharedLibraries.Repositories.IRepositories;
global using TaskManagementApp.SharedLibraries.BaseSharedLibraries.SharedDtos;
