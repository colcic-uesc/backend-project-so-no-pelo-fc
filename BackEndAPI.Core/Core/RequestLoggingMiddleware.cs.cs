using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BackEndAPI.Core;

/*
1 - IP DO CLIENTE
2 - POSSUI TOKEN JWT
3 - DATA E HORA DA REQUISIÇÃO
4 - MÉTODO E URL DE REQUISIÇÃO
5 - TEMPO TOTAL DO PROCESSAMENTO ATÉ A RESPOSTA AO CLIENTE
*/

public class RequestLoggingMiddleware
{
    private static Int64 _requestCounter = 1;
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;
    private readonly IConfiguration _configuration;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger, IConfiguration configuration)
    {
        _configuration = configuration;
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Início da requisição
        var stopwatch = new Stopwatch();

        // 1. IP do cliente
        var clientIp = context.Connection.RemoteIpAddress?.ToString();

        // 2. Verificar se a requisição tem um token JWT
        bool hasJwtToken = context.Request.Headers.ContainsKey("Authorization") &&
                           context.Request.Headers["Authorization"].ToString().StartsWith("Bearer ");

        // 3. Data e Hora da requisição
        var requestTime = DateTime.UtcNow;

        // 4. Método HTTP e URL da requisição
        var httpMethod = context.Request.Method;
        var requestUrl = context.Request.Path;

        // Executa a requisição
        stopwatch.Start();
        await _next(context);

        // Após a execução da requisição
        stopwatch.Stop();
        var totalProcessingTime = stopwatch.ElapsedMilliseconds;

        string info = $"Requisição recebida nº: {_requestCounter}" +
             $"\nIP do cliente: {clientIp}" +
             $"\nPossui JWT: {hasJwtToken}" +
             $"\nData e Hora: {requestTime}" +
             $"\nMétodo HTTP: {httpMethod}" +
             $"\nURL da requisição: {requestUrl}" +
             $"\nTempo total de processamento: {totalProcessingTime}ms" + "\n\n\n";

        // Logando as informações
        _logger.LogInformation(info);

        string logFilePath = _configuration.GetSection("Logger").GetSection("LoggerFilePath").Value ?? throw new ArgumentNullException();

        LogToTheFile(logFilePath, info);

        _requestCounter += 1;
    }

    private static void LogToTheFile(string path, string data)
    {
        using (StreamWriter writter = new StreamWriter(path, true))
        {
            writter.WriteLine(data);
        }
    }


}