﻿using Microsoft.Extensions.DependencyInjection;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;

namespace MyCliToolTemplate {
    public class TemplatesProgram {
        private Parser _parser;
        private ServiceCollection _services;
        private ServiceProvider _serviceProvider;

        public TemplatesProgram() {
            RegisterServices();
        }
        public Task<int> Execute(string[] args) {
            _parser = new CommandLineBuilder()
                        .AddCommand(
                            new Subcommand(GetFromServices<IReporter>()).CreateCommand())
                        .UseDefaults()
                        .Build();

            return _parser.InvokeAsync(args);
        }
        private void RegisterServices() {
            _services = new ServiceCollection();
            _serviceProvider = _services
                                .AddSingleton<IReporter, Reporter>()
                                .BuildServiceProvider();
        }
        private TType GetFromServices<TType>() {
            return _serviceProvider.GetRequiredService<TType>();
        }
    }
}
