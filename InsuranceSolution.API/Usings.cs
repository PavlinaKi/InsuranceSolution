global using MediatR;
global using Asp.Versioning;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.Filters;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.OpenApi.Models;
global using Microsoft.AspNetCore.OutputCaching;
global using System.Collections.Generic;
global using Microsoft.Identity.Web.Resource;
global using System.Reflection;
global using Microsoft.Identity.Web;
global using Serilog;
global using StackExchange.Redis;
global using System.IdentityModel.Tokens.Jwt;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.EntityFrameworkCore;
global using InsuranceSolution.API;
global using System.Net;

global using InsuranceSolution.Persistence;
global using InsuranceSolution.Application;
global using InsuranceSolution.Infrastructure;

global using InsuranceSolution.Application.Contracts.Persistence.Claims;
global using InsuranceSolution.Application.Features.Claims.Commands.CreateClaim;
global using InsuranceSolution.Application.Features.Claims.Commands.DeleteClaim;
global using InsuranceSolution.Application.Features.Claims.Commands.UpdateClaim;
global using InsuranceSolution.Application.Features.Claims.Queries.GetClaims;

global using InsuranceSolution.Application.Contracts.Persistence.Policies;
global using InsuranceSolution.Application.Features.Policies.Commands.CreatePolicy;
global using InsuranceSolution.Application.Features.Policies.Commands.DeletePolicy;
global using InsuranceSolution.Application.Features.Policies.Commands.UpdatePolicy;
global using InsuranceSolution.Application.Features.Policies.Queries.GetPolicies;

global using InsuranceSolution.Application.Contracts.Persistence.Insurers;
global using InsuranceSolution.Application.Features.Insurers.Commands.CreateInsurer;
global using InsuranceSolution.Application.Features.Insurers.Commands.DeleteInsurer;
global using InsuranceSolution.Application.Features.Insurers.Commands.UpdateInsurer;
global using InsuranceSolution.Application.Features.Insurers.Queries.GetInsurers;

global using Microsoft.AspNetCore.Diagnostics;
global using Microsoft.AspNetCore.Http.Features;
global using System.Diagnostics;

global using InsuranceSolution.API.Exceptions;
global using InsuranceSolution.Application.Exceptions;
global using InsuranceSolution.Application.Contracts.Infrastructure;
global using InsuranceSolution.Application.Models.Email;
global using InsuranceSolution.Application.Models.Authentication;
global using InsuranceSolution.Application.Contracts.Infrastructure.Authentication;