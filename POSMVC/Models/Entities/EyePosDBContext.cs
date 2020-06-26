using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace POSMVC.Models.Entities
{
    public partial class EyePosDBContext : DbContext
    {
        public EyePosDBContext()
        {
        }

        public EyePosDBContext(DbContextOptions<EyePosDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Authorizations> Authorizations { get; set; }
        public virtual DbSet<AuthorizeType> AuthorizeType { get; set; }
        public virtual DbSet<Balance> Balance { get; set; }
        public virtual DbSet<BalanceSourceType> BalanceSourceType { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<ContactLensDetail> ContactLensDetail { get; set; }
        public virtual DbSet<ContactLenseRx> ContactLenseRx { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Damage> Damage { get; set; }
        public virtual DbSet<Designation> Designation { get; set; }
        public virtual DbSet<DesignationTypes> DesignationTypes { get; set; }
        public virtual DbSet<Discounts> Discounts { get; set; }
        public virtual DbSet<FrameDetail> FrameDetail { get; set; }
        public virtual DbSet<Health> Health { get; set; }
        public virtual DbSet<HealthDocument> HealthDocument { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PaymentMethods> PaymentMethods { get; set; }
        public virtual DbSet<PersonalDetail> PersonalDetail { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Purchase> Purchase { get; set; }
        public virtual DbSet<PurchaseReturn> PurchaseReturn { get; set; }
        public virtual DbSet<Refunds> Refunds { get; set; }
        public virtual DbSet<SalesReturn> SalesReturn { get; set; }
        public virtual DbSet<SalesTransaction> SalesTransaction { get; set; }
        public virtual DbSet<Scheduler> Scheduler { get; set; }
        public virtual DbSet<SpectacleRx> SpectacleRx { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<StockAdjustment> StockAdjustment { get; set; }
        public virtual DbSet<StockReserved> StockReserved { get; set; }
        public virtual DbSet<StockTrace> StockTrace { get; set; }
        public virtual DbSet<SunglassDetail> SunglassDetail { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<UnitMeasurement> UnitMeasurement { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Vat> Vat { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=AbdHsn-Laptop;Database=EyePosDB;User ID=AbdHsn-dbms; Password=123123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Authorizations>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("UQ__Authoriz__1788CC4D637E3E3C")
                    .IsUnique();

                entity.Property(e => e.AuthorizedDate).HasColumnType("datetime");

                entity.HasOne(d => d.AuthorizeType)
                    .WithMany(p => p.Authorizations)
                    .HasForeignKey(d => d.AuthorizeTypeId)
                    .HasConstraintName("FK__Authoriza__Autho__6EF57B66");
            });

            modelBuilder.Entity<AuthorizeType>(entity =>
            {
                entity.HasIndex(e => e.TypeName)
                    .HasName("UQ__Authoriz__D4E7DFA8FF8BEC50")
                    .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.TypeName).HasMaxLength(100);
            });

            modelBuilder.Entity<Balance>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<BalanceSourceType>(entity =>
            {
                entity.HasIndex(e => e.SourceName)
                    .HasName("UQ__BalanceS__3C28DC1757DEE2E0")
                    .IsUnique();

                entity.Property(e => e.SourceName).HasMaxLength(50);
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Brand__737584F6616BEA47")
                    .IsUnique();

                entity.Property(e => e.BigImage).HasMaxLength(100);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.SmallImage).HasMaxLength(100);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.ParentCategory).HasMaxLength(15);

                entity.Property(e => e.SubCategory).HasMaxLength(15);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.BigLogo).HasMaxLength(100);

                entity.Property(e => e.Branch).HasMaxLength(20);

                entity.Property(e => e.Fax).HasMaxLength(20);

                entity.Property(e => e.Mobile).HasMaxLength(20);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.RegistrationNo).HasMaxLength(20);

                entity.Property(e => e.SmallLogo).HasMaxLength(100);

                entity.Property(e => e.Telephone).HasMaxLength(15);

                entity.Property(e => e.Website).HasMaxLength(100);
            });

            modelBuilder.Entity<ContactLensDetail>(entity =>
            {
                entity.Property(e => e.Bc)
                    .HasColumnName("BC")
                    .HasMaxLength(30);

                entity.Property(e => e.Color).HasMaxLength(30);

                entity.Property(e => e.Diameter).HasMaxLength(30);

                entity.Property(e => e.Features).HasMaxLength(50);

                entity.Property(e => e.Material).HasMaxLength(30);

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<ContactLenseRx>(entity =>
            {
                entity.ToTable("ContactLenseRX");

                entity.Property(e => e.CheckedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Ladd)
                    .HasColumnName("LADD")
                    .HasMaxLength(10);

                entity.Property(e => e.Laxis)
                    .HasColumnName("LAXIS")
                    .HasMaxLength(10);

                entity.Property(e => e.Lbc)
                    .HasColumnName("LBC")
                    .HasMaxLength(10);

                entity.Property(e => e.Lcyl)
                    .HasColumnName("LCYL")
                    .HasMaxLength(10);

                entity.Property(e => e.Ldia)
                    .HasColumnName("LDIA")
                    .HasMaxLength(10);

                entity.Property(e => e.Liop)
                    .HasColumnName("LIOP")
                    .HasMaxLength(10);

                entity.Property(e => e.Lkeratometry)
                    .HasColumnName("LKeratometry")
                    .HasMaxLength(10);

                entity.Property(e => e.Lsph)
                    .HasColumnName("LSPH")
                    .HasMaxLength(10);

                entity.Property(e => e.Lva)
                    .HasColumnName("LVA")
                    .HasMaxLength(10);

                entity.Property(e => e.Note).HasMaxLength(50);

                entity.Property(e => e.Radd)
                    .HasColumnName("RADD")
                    .HasMaxLength(10);

                entity.Property(e => e.Raxis)
                    .HasColumnName("RAXIS")
                    .HasMaxLength(10);

                entity.Property(e => e.Rbc)
                    .HasColumnName("RBC")
                    .HasMaxLength(10);

                entity.Property(e => e.Rcyl)
                    .HasColumnName("RCYL")
                    .HasMaxLength(10);

                entity.Property(e => e.Rdia)
                    .HasColumnName("RDIA")
                    .HasMaxLength(10);

                entity.Property(e => e.Riop)
                    .HasColumnName("RIOP")
                    .HasMaxLength(10);

                entity.Property(e => e.Rkeratometry)
                    .HasColumnName("RKeratometry")
                    .HasMaxLength(10);

                entity.Property(e => e.Rsph)
                    .HasColumnName("RSPH")
                    .HasMaxLength(10);

                entity.Property(e => e.Rva)
                    .HasColumnName("RVA")
                    .HasMaxLength(10);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ContactLenseRx)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__ContactLe__Custo__6FE99F9F");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Customer__A9D10534A2069543")
                    .IsUnique();

                entity.HasIndex(e => e.Phone)
                    .HasName("UQ__Customer__5C7E359E1A832AA5")
                    .IsUnique();

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Icno)
                    .HasColumnName("ICNo")
                    .HasMaxLength(20);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(15);

                entity.Property(e => e.Telephone).HasMaxLength(15);
            });

            modelBuilder.Entity<Damage>(entity =>
            {
                entity.HasIndex(e => e.DamageNo)
                    .HasName("UQ__Damage__8A0F294842C6BD9D")
                    .IsUnique();

                entity.Property(e => e.DamageNo).HasMaxLength(20);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(100);

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Designation>(entity =>
            {
                entity.HasOne(d => d.DesignationType)
                    .WithMany(p => p.Designation)
                    .HasForeignKey(d => d.DesignationTypeId)
                    .HasConstraintName("FK__Designati__Desig__70DDC3D8");
            });

            modelBuilder.Entity<DesignationTypes>(entity =>
            {
                entity.HasIndex(e => e.TypeName)
                    .HasName("UQ__Designat__D4E7DFA8C228D24F")
                    .IsUnique();

                entity.Property(e => e.TypeName).HasMaxLength(15);
            });

            modelBuilder.Entity<Discounts>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.DiscountRate).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(10);
            });

            modelBuilder.Entity<FrameDetail>(entity =>
            {
                entity.Property(e => e.ColorCode).HasMaxLength(30);

                entity.Property(e => e.Size).HasMaxLength(30);

                entity.Property(e => e.Type).HasMaxLength(30);
            });

            modelBuilder.Entity<Health>(entity =>
            {
                entity.Property(e => e.Aperture).HasMaxLength(10);

                entity.Property(e => e.Blink).HasMaxLength(10);

                entity.Property(e => e.CaseHistory).HasMaxLength(50);

                entity.Property(e => e.ChiefComplain).HasMaxLength(50);

                entity.Property(e => e.ColorVision).HasMaxLength(10);

                entity.Property(e => e.ContactLenseWorn).HasMaxLength(20);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EyeHealth).HasMaxLength(10);

                entity.Property(e => e.Eyelids).HasMaxLength(10);

                entity.Property(e => e.HealthCondition).HasMaxLength(10);

                entity.Property(e => e.HealthMedication).HasMaxLength(50);

                entity.Property(e => e.Hvid)
                    .HasColumnName("HVID")
                    .HasMaxLength(10);

                entity.Property(e => e.Lacrimation).HasMaxLength(10);

                entity.Property(e => e.Lbright)
                    .HasColumnName("LBright")
                    .HasMaxLength(10);

                entity.Property(e => e.Ldim)
                    .HasColumnName("LDim")
                    .HasMaxLength(10);

                entity.Property(e => e.LeyeImagePath)
                    .HasColumnName("LEyeImagePath")
                    .HasMaxLength(20);

                entity.Property(e => e.Lhvid)
                    .HasColumnName("LHVID")
                    .HasMaxLength(10);

                entity.Property(e => e.LpalpAperture)
                    .HasColumnName("LPalpAperture")
                    .HasMaxLength(10);

                entity.Property(e => e.OralMedication).HasMaxLength(10);

                entity.Property(e => e.PupilSize).HasMaxLength(10);

                entity.Property(e => e.Rbright)
                    .HasColumnName("RBright")
                    .HasMaxLength(10);

                entity.Property(e => e.Rdim)
                    .HasColumnName("RDim")
                    .HasMaxLength(10);

                entity.Property(e => e.Remark).HasMaxLength(100);

                entity.Property(e => e.ReyeImagePath)
                    .HasColumnName("REyeImagePath")
                    .HasMaxLength(20);

                entity.Property(e => e.Rhvid)
                    .HasColumnName("RHVID")
                    .HasMaxLength(10);

                entity.Property(e => e.RpalpAperture)
                    .HasColumnName("RPalpAperture")
                    .HasMaxLength(10);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Health)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Health__Customer__72C60C4A");
            });

            modelBuilder.Entity<HealthDocument>(entity =>
            {
                entity.Property(e => e.DocumentName).HasMaxLength(20);

                entity.Property(e => e.SavePath).HasMaxLength(20);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.HealthDocument)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__HealthDoc__Custo__73BA3083");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.HasIndex(e => e.ManufacturerName)
                    .HasName("UQ__Manufact__3B9CDE2EE0CEF4E2")
                    .IsUnique();

                entity.Property(e => e.BigImage).HasMaxLength(100);

                entity.Property(e => e.ContactInfo).HasMaxLength(400);

                entity.Property(e => e.ManufacturerName).HasMaxLength(200);

                entity.Property(e => e.SmallImage).HasMaxLength(100);
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.Property(e => e.CollectionDate).HasColumnType("datetime");

                entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DiscountRate).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.GrandTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.VatAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.VatRate).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasIndex(e => e.OrderNo)
                    .HasName("UQ__Orders__C3907C75D1585BAD")
                    .IsUnique();

                entity.Property(e => e.BillingAddress).HasMaxLength(250);

                entity.Property(e => e.CollectionDate).HasColumnType("datetime");

                entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DiscountRate).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FinalTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Note).HasMaxLength(100);

                entity.Property(e => e.OrderNo).HasMaxLength(20);

                entity.Property(e => e.OrderPlaceDate).HasColumnType("datetime");

                entity.Property(e => e.OrderStatus).HasMaxLength(15);

                entity.Property(e => e.VatAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.VatRate).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Orders__Customer__74AE54BC");

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DiscountId)
                    .HasConstraintName("FK__Orders__Discount__75A278F5");

                entity.HasOne(d => d.Vat)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.VatId)
                    .HasConstraintName("FK__Orders__VatId__76969D2E");
            });

            modelBuilder.Entity<PaymentMethods>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__PaymentM__737584F66248325C")
                    .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.LogoPath).HasMaxLength(20);

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.Url).HasMaxLength(100);
            });

            modelBuilder.Entity<PersonalDetail>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("UQ__Personal__1788CC4D4B2A1430")
                    .IsUnique();

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.Language).HasMaxLength(20);

                entity.Property(e => e.MaritalStatus).HasMaxLength(15);

                entity.Property(e => e.MobileNo).HasMaxLength(30);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.OtherPhone).HasMaxLength(100);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.PersonalDetail)
                    .HasForeignKey<PersonalDetail>(d => d.UserId)
                    .HasConstraintName("FK__PersonalD__UserI__403A8C7D");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.Property(e => e.TypeName).HasMaxLength(100);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasIndex(e => e.ProductCode)
                    .HasName("UQ__Products__2F4E024FA30573CB")
                    .IsUnique();

                entity.Property(e => e.Bc)
                    .HasColumnName("BC")
                    .HasMaxLength(30);

                entity.Property(e => e.BigImage).HasMaxLength(100);

                entity.Property(e => e.ColorCode).HasMaxLength(30);

                entity.Property(e => e.CostPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Diameter).HasMaxLength(30);

                entity.Property(e => e.MetaTags).HasMaxLength(150);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.ProductCode).HasMaxLength(300);

                entity.Property(e => e.SellingPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Size).HasMaxLength(30);

                entity.Property(e => e.SmallImage).HasMaxLength(100);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasIndex(e => e.PurchaseNo)
                    .HasName("UQ__Purchase__6B0A9314353F90ED")
                    .IsUnique();

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.FinalTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Note).HasMaxLength(100);

                entity.Property(e => e.PriceRate).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PurchaseDate).HasColumnType("datetime");

                entity.Property(e => e.PurchaseNo).HasMaxLength(20);

                entity.Property(e => e.VatAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.VatRate).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<PurchaseReturn>(entity =>
            {
                entity.HasIndex(e => e.PurchaseReturnNo)
                    .HasName("UQ__Purchase__2C2936398048BAC2")
                    .IsUnique();

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.PurchaseReturnNo).HasMaxLength(20);

                entity.Property(e => e.Reason).HasMaxLength(100);

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Refunds>(entity =>
            {
                entity.HasIndex(e => e.RefundNo)
                    .HasName("UQ__Refunds__725A61B258C99BF1")
                    .IsUnique();

                entity.Property(e => e.RefundAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RefundNo).HasMaxLength(20);

                entity.Property(e => e.RefundedDate).HasColumnType("datetime");

                entity.Property(e => e.SalesReturnNo).HasMaxLength(20);

                entity.HasOne(d => d.SalesReturn)
                    .WithMany(p => p.Refunds)
                    .HasForeignKey(d => d.SalesReturnId)
                    .HasConstraintName("FK__Refunds__SalesRe__787EE5A0");
            });

            modelBuilder.Entity<SalesReturn>(entity =>
            {
                entity.HasIndex(e => e.SalesReturnNo)
                    .HasName("UQ__SalesRet__E09004660ED3F87E")
                    .IsUnique();

                entity.Property(e => e.OrderNo).HasMaxLength(20);

                entity.Property(e => e.Reason).HasMaxLength(100);

                entity.Property(e => e.ReturnDate).HasColumnType("datetime");

                entity.Property(e => e.SalesReturnNo).HasMaxLength(20);

                entity.Property(e => e.Status).HasMaxLength(15);

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.SalesReturn)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__SalesRetu__Custo__797309D9");
            });

            modelBuilder.Entity<SalesTransaction>(entity =>
            {
                entity.Property(e => e.PaidAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SaleTransactionNo).HasMaxLength(20);

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.SalesTransaction)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__SalesTran__Custo__7A672E12");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.SalesTransaction)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__SalesTran__Order__7B5B524B");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.SalesTransaction)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .HasConstraintName("FK__SalesTran__Payme__7C4F7684");
            });

            modelBuilder.Entity<Scheduler>(entity =>
            {
                entity.Property(e => e.MsgContent).HasMaxLength(50);

                entity.Property(e => e.RecallDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<SpectacleRx>(entity =>
            {
                entity.ToTable("SpectacleRX");

                entity.Property(e => e.CheckedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Ladd)
                    .HasColumnName("LAdd")
                    .HasMaxLength(10);

                entity.Property(e => e.Laxis)
                    .HasColumnName("LAxis")
                    .HasMaxLength(10);

                entity.Property(e => e.Lcyl)
                    .HasColumnName("LCyl")
                    .HasMaxLength(10);

                entity.Property(e => e.Lpd)
                    .HasColumnName("LPd")
                    .HasMaxLength(10);

                entity.Property(e => e.Lprism)
                    .HasColumnName("LPrism")
                    .HasMaxLength(10);

                entity.Property(e => e.Lsph)
                    .HasColumnName("LSph")
                    .HasMaxLength(10);

                entity.Property(e => e.Lva)
                    .HasColumnName("LVa")
                    .HasMaxLength(10);

                entity.Property(e => e.Note).HasMaxLength(50);

                entity.Property(e => e.Radd)
                    .HasColumnName("RAdd")
                    .HasMaxLength(10);

                entity.Property(e => e.Raxis)
                    .HasColumnName("RAxis")
                    .HasMaxLength(10);

                entity.Property(e => e.Rcyl)
                    .HasColumnName("RCyl")
                    .HasMaxLength(10);

                entity.Property(e => e.Rpd)
                    .HasColumnName("RPd")
                    .HasMaxLength(10);

                entity.Property(e => e.Rprism)
                    .HasColumnName("RPrism")
                    .HasMaxLength(10);

                entity.Property(e => e.Rsph)
                    .HasColumnName("RSph")
                    .HasMaxLength(10);

                entity.Property(e => e.Rva)
                    .HasColumnName("RVa")
                    .HasMaxLength(10);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.SpectacleRx)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Spectacle__Custo__7D439ABD");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdate).HasColumnType("datetime");
            });

            modelBuilder.Entity<StockAdjustment>(entity =>
            {
                entity.HasIndex(e => e.AdjustmentNo)
                    .HasName("UQ__StockAdj__E60D0EF175548E97")
                    .IsUnique();

                entity.Property(e => e.AdjustmentNo).HasMaxLength(20);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(100);
            });

            modelBuilder.Entity<StockReserved>(entity =>
            {
                entity.Property(e => e.Note).HasMaxLength(50);

                entity.Property(e => e.ReserveStatus).HasMaxLength(15);
            });

            modelBuilder.Entity<StockTrace>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(100);

                entity.Property(e => e.ReferenceId).HasMaxLength(100);

                entity.Property(e => e.TableReference).HasMaxLength(30);
            });

            modelBuilder.Entity<SunglassDetail>(entity =>
            {
                entity.HasIndex(e => e.ProductId)
                    .HasName("UQ__ProductG__2F4E024F572B4401")
                    .IsUnique();

                entity.Property(e => e.FaceShap).HasMaxLength(30);

                entity.Property(e => e.Features).HasMaxLength(200);

                entity.Property(e => e.FrameColor).HasMaxLength(30);

                entity.Property(e => e.Gender).HasMaxLength(20);

                entity.Property(e => e.LenseColor).HasMaxLength(30);

                entity.Property(e => e.Material).HasMaxLength(30);

                entity.Property(e => e.Size).HasMaxLength(100);

                entity.Property(e => e.Style).HasMaxLength(30);

                entity.Property(e => e.Type).HasMaxLength(30);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Supplier__A9D10534FFA32ADD")
                    .IsUnique();

                entity.HasIndex(e => e.Phone)
                    .HasName("UQ__Supplier__5C7E359E7BECE177")
                    .IsUnique();

                entity.Property(e => e.Address).HasMaxLength(150);

                entity.Property(e => e.CompanyName).HasMaxLength(20);

                entity.Property(e => e.Email).HasMaxLength(15);

                entity.Property(e => e.Fax).HasMaxLength(15);

                entity.Property(e => e.Phone).HasMaxLength(15);

                entity.Property(e => e.SupplierName).HasMaxLength(20);

                entity.Property(e => e.Telephone).HasMaxLength(15);
            });

            modelBuilder.Entity<UnitMeasurement>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.HasIndex(e => e.TypeName)
                    .HasName("UQ__UserType__D4E7DFA807F3DAE4")
                    .IsUnique();

                entity.Property(e => e.TypeName).HasMaxLength(30);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Users__A9D10534D36E8D6C")
                    .IsUnique();

                entity.HasIndex(e => e.UserName)
                    .HasName("UQ__Users__C9F284566E18A7D7")
                    .IsUnique();

                entity.Property(e => e.BigImage).HasMaxLength(100);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.SmallImage).HasMaxLength(100);

                entity.Property(e => e.TempField).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(200);
            });

            modelBuilder.Entity<Vat>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Title).HasMaxLength(10);

                entity.Property(e => e.VatRate).HasColumnType("decimal(18, 2)");
            });
        }
    }
}
