### Skapa en ny WPF Applikation med stöd för Microsoft.Toolkit.Mvvm 

Börja med att skapa en ny tom WPF application för NET 5

Glöm inte att efterhand som du lägger till kod så får du kontrollpunkta vissa fel så den skapar usings för det som saknas...

Lägg till följande referenser i csproj-filen:

```xml
<PackageReference Include="FluentValidation" Version="10.0.3" />
<PackageReference Include="FluentValidation.DependencyInjectionExtensions" Version="10.0.3" />
<PackageReference Include="Microsoft.Extensions.Hosting" Version="5.0.0" />
<PackageReference Include="Microsoft.Extensions.Http" Version="5.0.0" />
<PackageReference Include="Microsoft.Toolkit.Mvvm" Version="7.0.1" />
<PackageReference Include="Microsoft.Xaml.Behaviors.Wpf" Version="1.1.31" />
<PackageReference Include="ScottPlot.WPF" Version="4.1.12-beta" />
```

Ändra <Project Sdk="Microsoft.NET.Sdk"> till att vara <Project Sdk="Microsoft.NET.Sdk.Worker">

Skapa mappstruktur med följande mappar/namespace:

- Configurations, lägg till en publik statisk klass ConfigurationExtensions enligt nedan
- Converters
- Models
- Services, lägg till en publik statisk klass ServiceExtensions enligt nedan
- Validators
- ViewModels, lägg till en publik statisk klass ViewModelExtensions enligt nedan
- Views, lägg till en publik statisk klass ViewExtensions enligt nedan

I de mappar som ska innehålla klasser enligt ovan så ska dessa se ut så här:

```c#
public static class ConfigurationExtensions
{
    public static IServiceCollection AddApplicationConfiguration(this IServiceCollection services, HostBuilderContext context)
    {
        return services;
    }
}

public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services;
    }
}

public static class ViewModelExtensions
{
    public static IServiceCollection AddApplicationViewModels(this IServiceCollection services)
    {
        services.AddTransient<MainViewModel>();
        return services;
    }
}

public static class ViewExtensions
{
    public static IServiceCollection AddApplicationViews(this IServiceCollection services)
    {
        return services;
    }
}
```

Flytta MainWindow.xaml och MainWindow.xaml.cs till mappen Views, glöm inte att ändra:

I **MainWindow.xaml**:

```
x:Class="WpfApp2.MainWindow"
Ska vara
x:Class="WpfApp2.Views.MainWindow"

xmlns:local="clr-namespace:WpfApp2"
Ska vara
xmlns:local="clr-namespace:WpfApp2.Views"
```

I **MainWindow.xaml.cs**:

```
namespace WpfApp2
Ska vara
namespace WpfApp2.Views
```

Ta bort StartupUri från App.xaml, den ska inte finnas där!

I App.xaml.cs:

```c#
public partial class App : Application
{
    private readonly IHost host;

    public App()
    {
        host = Host.CreateDefaultBuilder()
                 .ConfigureAppConfiguration(builder => builder.AddJsonFile("WindowsInfo.json", optional: true))
                 .ConfigureServices((context, services) => services
                     .AddApplicationConfiguration(context)
                     .AddApplicationViewModels()
                     .AddApplicationViews()
                     .AddApplicationServices())
        .Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await host.StartAsync();
        
        host.Services
            .GetRequiredService<MainWindow>()
            .Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        using (host)
        {
            await host.StopAsync();
        }

        base.OnExit(e);
    }
}
```

Du ska nu ha en fullt körbar applikation, en så kallad BoilerPlate, alltså den innehåller hela plattformen för att kunna bygga en MVVM-baserad applikation, den innehåller fasta positioner/platser för att definiera allt på ett bra sätt.

### Börja bygga MVVM

Det första vi ska göra är att lägga till en ViewModel för MainWindow, vi kallar den MainViewModel

