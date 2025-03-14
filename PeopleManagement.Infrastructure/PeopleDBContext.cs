using PeopleManagement.Domain;
using PeopleManagement.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManagement.Infrastructure {
    public class PeopleDBContext : DbContext {
        public PeopleDBContext()
            : base(ConfigurationManager.ConnectionStrings["PeopleDBConnection"].ConnectionString) {
        }

        public DbSet<PersonEntity> Person { get; set; }
        public DbSet<PhonePersonEntity> PhonePerson { get; set; }
        public DbSet<EmailPersonEntity> EmailPerson { get; set; }
        public DbSet<AddressPersonEntity> AddressPerson { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {

            modelBuilder.Entity<PhonePersonEntity>()
             .HasRequired(p => p.Person)  // A PhonePerson requires a Person
             .WithMany(p => p.Phones)  // A Person has many PhonePersons
             .HasForeignKey(p => p.PersonId)  // Explicit foreign key
             .WillCascadeOnDelete(true);  // Cascade delete

            modelBuilder.Entity<EmailPersonEntity>()
              .HasRequired(e => e.Person)  // An EmailPerson requires a Person
              .WithMany(p => p.Emails)  // A Person has many EmailPersons
              .HasForeignKey(e => e.PersonId)  // Explicit foreign key
              .WillCascadeOnDelete(true);  // Cascade delete

            modelBuilder.Entity<AddressPersonEntity>()
            .HasRequired(a => a.Person)  // An AddressPerson requires a Person
            .WithMany(p => p.Addresses)  // A Person has many AddressPersons
            .HasForeignKey(a => a.PersonId)  // Explicit foreign key
            .WillCascadeOnDelete(true);  // Cascade delete
         }
    }
}
