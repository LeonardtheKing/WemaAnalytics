﻿global using AutoMapper;
global using FluentValidation;
global using FluentValidation.AspNetCore;
global using Hangfire;
global using Hangfire.SqlServer;
global using MediatR;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.ModelBinding;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;
global using Newtonsoft.Json;
global using Newtonsoft.Json.Serialization;
global using System.IdentityModel.Tokens.Jwt;
global using System.Linq.Expressions;
global using System.Net.Http.Headers;
global using System.Security.Claims;
global using System.Security.Cryptography;
global using System.Text;
global using WemaAnalytics.Application.Constants;
global using WemaAnalytics.Application.Helpers;
global using WemaAnalytics.Application.Jobs;
global using WemaAnalytics.Application.Models.Common;
global using WemaAnalytics.Application.Services;
global using WemaAnalytics.Domain.Entities;
global using WemaAnalytics.Domain.Enums;
global using WemaAnalytics.Domain.Pagination;
global using WemaAnalytics.Infrastructure.Data.DbContexts;