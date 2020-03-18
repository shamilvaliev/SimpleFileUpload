namespace SimpleFileUpload.Domain
{
    using Microsoft.EntityFrameworkCore;

    using SimpleFileUpload.Domain.Models;

    /// <summary>
    /// Db context
    /// </summary>
    public class FileUploadContext: DbContext
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="options">options</param>
        public FileUploadContext(DbContextOptions<FileUploadContext> options)
               : base(options)
        {
        }

        /// <summary>
        /// Users
        /// </summary>
        public DbSet<UserModel> Users { get; set; }

        /// <summary>
        /// Files
        /// </summary>
        public DbSet<FileModel> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           var userMapp = modelBuilder.Entity<UserModel>().ToTable("Users");
            userMapp.HasKey(t => t.Id);
            userMapp.Property(t => t.Id).ValueGeneratedOnAdd();
            userMapp.Property(t => t.Name).HasMaxLength(50);
            userMapp.Property(t => t.Token).HasMaxLength(50);

            var fileMapp = modelBuilder.Entity<FileModel>().ToTable("Files");
            fileMapp.HasKey(t => t.Id);
            fileMapp.Property(t => t.Id).ValueGeneratedOnAdd();
            fileMapp.HasOne(t => t.User).WithMany().HasForeignKey(t => t.UserId);
            fileMapp.Property(t => t.Name).HasMaxLength(500);
            fileMapp.Property(t => t.Ext).HasMaxLength(50);

            var fileContentMapp = modelBuilder.Entity<FileContentModel>().ToTable("FileContents");
            fileContentMapp.HasKey(t => t.FileId);
            fileContentMapp.HasOne(t => t.File).WithOne(t => t.Content);
        }
    }
}
