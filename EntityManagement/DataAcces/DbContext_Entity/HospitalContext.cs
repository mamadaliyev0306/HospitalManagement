using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityManagement.DataAcces.DbContext_Entity
{
    public class HospitalContext:DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options)
        {
        }

        public  DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientBlank> PatientBlanks { get; set; }
        public DbSet<Speciality> Speciality { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(builder =>
            {
                builder.HasKey(r => r.AppointmentId);

                builder.HasOne(r => r.Patient)
                    .WithMany(r => r.Appointments);

                builder.HasOne(r => r.Doctor)
                    .WithMany(r => r.Appointments);
            });

            modelBuilder.Entity<Doctor>(builder =>
            {
                builder.HasKey(r => r.DoctorId);

                builder.HasOne(r => r.Speciality)
                    .WithMany();
            });

            modelBuilder.Entity<Patient>(builder =>
            {
                builder.HasKey(r => r.PatientId);
            });

            modelBuilder.Entity<PatientBlank>(builder =>
            {
                builder.HasKey(r => r.PatientBlankId);

                builder.HasOne(r => r.Patient)
                    .WithOne(r => r.PatientBlank)
                    .HasForeignKey<PatientBlank>(r => r.PatientId);
            });

            modelBuilder.Entity<Speciality>(builder =>
            {
                builder.HasKey(r => r.SpecialityId);
            });
        }

    }
}
