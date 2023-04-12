using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using TravelAgencyProject.Repository;
using TravelAgencyProject.Applications.Controller;
using TravelAgencyProject.Applications.Services;
using TravelAgencyProject.Domain.Interfaces.RepositoryInterfaces;
using TravelAgencyProject.Domain.Interfaces.Services;
using TravelAgencyProject.Service;
using TravelAgencyProject.Domain.Interfaces.Repositories;

namespace TravelAgencyProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost _host;

        public static IServiceProvider Services { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _host = Host.CreateDefaultBuilder()
                .ConfigureServices(ConfigureServices)
                .Build();

            _host.Start();
        }

        private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            services.AddTransient(typeof(ITourArrangementRepository), typeof(TourArrangementRepository));
            services.AddTransient(typeof(ITourArrangementService), typeof(TourArrangementService));
            services.AddTransient(typeof(ITourArrangementCreationService), typeof(TourArrangementCreationService));
            services.AddTransient(typeof(ITourArrangementStatisticsService), typeof(TourArrangementStatisticsService));
            services.AddTransient<TourArrangementController>();
            services.AddTransient(typeof(IAccommodationReservationRepository), typeof(AccommodationReservationRepository));
            services.AddTransient(typeof(IAccommodationReservationService), typeof(AccommodationReservationService));
            services.AddTransient(typeof(IAccommodationReservationCreationService), typeof(AccommodationReservationCreationService));
            services.AddTransient<AccommodationReservationController>();
            services.AddTransient<RescheduleReservationRequestController>();
            services.AddTransient<RescheduleReservationRequestService>();
            services.AddTransient<AccommodationReservationCreationService>();

            Services = services.BuildServiceProvider();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            _host.Dispose();
        }
    }
}
