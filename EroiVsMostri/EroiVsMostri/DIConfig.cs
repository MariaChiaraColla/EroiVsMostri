using EroiVsMostri.ADORepository;
using EroiVsMostri.Core.Interfacce;
using EroiVsMostri.MockRepository;
using EroiVsMostri.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EroiVsMostri
{
    public class DIConfig
    {
        //provider generico di servizio
        public static ServiceProvider Configurazione()
        {
            return new ServiceCollection()
                //aggiungo i servizi
                .AddScoped<ClassiServices>()
                .AddScoped<ArmiServices>()
                .AddScoped<LivelliServices>()
                .AddScoped<GiocatoriServices>()
                .AddScoped<EroiServices>()
                .AddScoped<MostriServices>()
                .AddScoped<LivelliServices>()
                .AddScoped<PassaggiLivelliServices>()

                //aggiungo un servizio che mappa l'astrazione con l'implementazione concreta
                .AddScoped<IClasseRepository, ADOClasseRepository>()
                //.AddScoped<IClasseRepository, MockClassiRepository>()
                .AddScoped<IArmaRepository, ADOArmaRepository>()
                .AddScoped<ILivelloRepository,ADOLivelloRepository>()
                .AddScoped<IGiocatoreRepository,ADOGiocatoreRepository>()
                .AddScoped<IEroeRepository, ADOEroeRepository>()
                .AddScoped<IMostroRepository, ADOMostroRepository>()
                .AddScoped<ILivelloRepository, ADOLivelloRepository>()
                .AddScoped<IPassaggioLivelloRepository, ADOPassaggioLivelloRepository>()

                //costruisco il provider
                .BuildServiceProvider();
        }
    }
}
