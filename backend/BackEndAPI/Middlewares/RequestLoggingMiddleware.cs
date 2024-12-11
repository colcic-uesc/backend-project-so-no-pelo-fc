using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BackEndAPI.Middlewares;

public class RequestLoggingMiddleware
{
    private static long _requestCounter = 1;
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
        // Contador de tempo de execução da requisição
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

        // 5. Tempo total de processamento
        var totalProcessingTime = stopwatch.ElapsedMilliseconds;

        string info = $"Requisição recebida nº: {_requestCounter}" +
             $"\nIP do cliente: {clientIp}" +
             $"\nPossui JWT: {hasJwtToken}" +
             $"\nData e Hora: {requestTime}" +
             $"\nMétodo HTTP: {httpMethod}" +
             $"\nURL da requisição: {requestUrl}" +
             $"\nTempo total de processamento: {totalProcessingTime}ms" + "\n\n";

        // Logando as informações no console
        _logger.LogInformation(info);

        string logFilePath = _configuration.GetSection("Logger").GetSection("LoggerFilePath").Value ?? throw new ArgumentNullException();
        if (File.Exists(logFilePath)) File.Delete(logFilePath); // --> Deletar o arquivo de log antes de criar um novo

        // Escrevendo as informações no arquivo de log
        LogToTheFile(logFilePath, info);

        _requestCounter += 1;
    }

    // Método para escrever no arquivo de log
    private static void LogToTheFile(string path, string data)
    {
        using (StreamWriter writter = new StreamWriter(path, true))
        {
            writter.WriteLine(data);
        }
    }


}