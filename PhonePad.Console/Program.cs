using System;
using Microsoft.Extensions.DependencyInjection;
using PhonePad.Application;
using PhonePad.Application.Services;
using PhonePad.Domain.Interfaces;
using PhonePad.Infrastructure.Keymaps;
using PhonePad.Infrastructure.Rules;

var services = new ServiceCollection();

// infrastructure bindings (concrete implementations)
services.AddSingleton<IKeyMap, OldPhonePadKeys>();
services.AddSingleton<IProcessingRules, OldPhonePadRules>();
services.AddTransient<IPhonePad>(sp => new PhonePadService(
    sp.GetRequiredService<IInputProcessor>()
));


// application bindings (InputProcessor depends on IKeyMap & IProcessingRules)
services.AddTransient<IInputProcessor>(sp =>
    new InputProcessorImpl(
        sp.GetRequiredService<IKeyMap>(),
        sp.GetRequiredService<IProcessingRules>()));

services.AddTransient<IPhonePad>(sp => new PhonePadService(sp.GetRequiredService<IInputProcessor>()));

using var provider = services.BuildServiceProvider();
var pad = provider.GetRequiredService<IPhonePad>();

Console.WriteLine(pad.ProcessInput("33#"));                // E
Console.WriteLine(pad.ProcessInput("227*#"));              // B
Console.WriteLine(pad.ProcessInput("4433555 555666#"));    // HELLO
Console.WriteLine(pad.ProcessInput("8 88777444666*664#")); // TURING
