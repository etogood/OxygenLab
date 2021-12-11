using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PolyclinicApp.Data.DataAccess;
using PolyclinicApp.WPF.ViewModels.Base;
using PolyclinicApplication.Data.Models;
using System.Collections.ObjectModel;

namespace PolyclinicApp.WPF.ViewModels
{
    internal class DoctorsScheduleViewModel : ViewModel
    {
        private ObservableCollection<Schedule> _scheduleTable;

        public ObservableCollection<Schedule> ScheduleTable
        {
            get => _scheduleTable;
            set => Set(ref _scheduleTable, value);
        }

        public DoctorsScheduleViewModel(IHost host)
        {
            using (var appDbContext = host.Services.GetRequiredService<AppDbContextFactory>().CreateDbContext(null))
            {
                _scheduleTable = new ObservableCollection<Schedule>(appDbContext.Schedules!
                    .Include(x => x.Doctor));
            }
        }
    }
}