namespace StaffSkillModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StaffSkillModel1 : DbContext
    {
        public StaffSkillModel1()
            : base("name=n3276931Task4db")
        {
        }

        public virtual DbSet<StaffSkill> StaffSkills { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
