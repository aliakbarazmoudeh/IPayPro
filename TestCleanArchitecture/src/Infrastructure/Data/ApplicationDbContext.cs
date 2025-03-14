using Microsoft.EntityFrameworkCore;
using TestCleanArchitecture.Application.Common.Interfaces;
using TestCleanArchitecture.Domain.Entities;

namespace TestCleanArchitecture.Infrastructure.Data;

public partial class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuthGroup> AuthGroups { get; set; }

    public virtual DbSet<AuthGroupPermission> AuthGroupPermissions { get; set; }

    public virtual DbSet<AuthPermission> AuthPermissions { get; set; }

    public virtual DbSet<AuthUser> AuthUsers { get; set; }

    public virtual DbSet<AuthUserGroup> AuthUserGroups { get; set; }

    public virtual DbSet<AuthUserUserPermission> AuthUserUserPermissions { get; set; }

    public virtual DbSet<DjangoAdminLog> DjangoAdminLogs { get; set; }

    public virtual DbSet<DjangoContentType> DjangoContentTypes { get; set; }

    public virtual DbSet<DjangoMigration> DjangoMigrations { get; set; }

    public virtual DbSet<DjangoSession> DjangoSessions { get; set; }

    public virtual DbSet<PanelAccount> PanelAccounts { get; set; }

    public virtual DbSet<PanelBank> PanelBanks { get; set; }

    public virtual DbSet<PanelFeestructure> PanelFeestructures { get; set; }

    public virtual DbSet<PanelOrder> PanelOrders { get; set; }

    public virtual DbSet<PanelPayment> PanelPayments { get; set; }

    public virtual DbSet<PanelPaymentbank> PanelPaymentbanks { get; set; }

    public virtual DbSet<PanelPaymentcash> PanelPaymentcashes { get; set; }

    public virtual DbSet<PanelPaymentdeposite> PanelPaymentdeposites { get; set; }

    public virtual DbSet<PanelPaymentgateway> PanelPaymentgateways { get; set; }

    public virtual DbSet<PanelProduct> PanelProducts { get; set; }

    public virtual DbSet<PanelProfile> PanelProfiles { get; set; }

    public virtual DbSet<PanelReadycommand> PanelReadycommands { get; set; }

    public virtual DbSet<PanelReservation> PanelReservations { get; set; }

    public virtual DbSet<PanelSurvey> PanelSurveys { get; set; }

    public virtual DbSet<PanelSurveyanswer> PanelSurveyanswers { get; set; }

    public virtual DbSet<PanelSurveyoption> PanelSurveyoptions { get; set; }

    public virtual DbSet<PanelSurveyquestion> PanelSurveyquestions { get; set; }

    public virtual DbSet<PanelTelegramuser> PanelTelegramusers { get; set; }

    public virtual DbSet<PanelTransaction> PanelTransactions { get; set; }

    public virtual DbSet<PanelWallet> PanelWallets { get; set; }

    public virtual DbSet<TempLogin> TempLogins { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=ipaypro;User=aliakbar;Password=Aliakbar@6979;",
            ServerVersion.AutoDetect(
                "Server=localhost;Port=3306;Database=ipaypro;User=aliakbar;Password=Aliakbar@6979;"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<AuthGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("auth_group")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.Name, "name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
        });

        modelBuilder.Entity<AuthGroupPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("auth_group_permissions")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.PermissionId, "auth_group_permissio_permission_id_84c5c92e_fk_auth_perm");

            entity.HasIndex(e => new { e.GroupId, e.PermissionId },
                "auth_group_permissions_group_id_permission_id_0cd325b0_uniq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.PermissionId).HasColumnName("permission_id");

            entity.HasOne(d => d.Group).WithMany(p => p.AuthGroupPermissions)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_group_permissions_group_id_b120cbf9_fk_auth_group_id");

            entity.HasOne(d => d.Permission).WithMany(p => p.AuthGroupPermissions)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_group_permissio_permission_id_84c5c92e_fk_auth_perm");
        });

        modelBuilder.Entity<AuthPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("auth_permission")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => new { e.ContentTypeId, e.Codename },
                "auth_permission_content_type_id_codename_01ab375a_uniq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Codename)
                .HasMaxLength(100)
                .HasColumnName("codename");
            entity.Property(e => e.ContentTypeId).HasColumnName("content_type_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

            entity.HasOne(d => d.ContentType).WithMany(p => p.AuthPermissions)
                .HasForeignKey(d => d.ContentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_permission_content_type_id_2f476e4b_fk_django_co");
        });

        modelBuilder.Entity<AuthUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("auth_user")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.Username, "username").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateJoined)
                .HasMaxLength(6)
                .HasColumnName("date_joined");
            entity.Property(e => e.Email)
                .HasMaxLength(254)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(150)
                .HasColumnName("first_name");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsStaff).HasColumnName("is_staff");
            entity.Property(e => e.IsSuperuser).HasColumnName("is_superuser");
            entity.Property(e => e.LastLogin)
                .HasMaxLength(6)
                .HasColumnName("last_login");
            entity.Property(e => e.LastName)
                .HasMaxLength(150)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(128)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(150)
                .HasColumnName("username");
        });

        modelBuilder.Entity<AuthUserGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("auth_user_groups")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.GroupId, "auth_user_groups_group_id_97559544_fk_auth_group_id");

            entity.HasIndex(e => new { e.UserId, e.GroupId }, "auth_user_groups_user_id_group_id_94350c0c_uniq")
                .IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Group).WithMany(p => p.AuthUserGroups)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_user_groups_group_id_97559544_fk_auth_group_id");

            entity.HasOne(d => d.User).WithMany(p => p.AuthUserGroups)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_user_groups_user_id_6a12ed8b_fk_auth_user_id");
        });

        modelBuilder.Entity<AuthUserUserPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("auth_user_user_permissions")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.PermissionId, "auth_user_user_permi_permission_id_1fbb5f2c_fk_auth_perm");

            entity.HasIndex(e => new { e.UserId, e.PermissionId },
                "auth_user_user_permissions_user_id_permission_id_14a6b632_uniq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PermissionId).HasColumnName("permission_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Permission).WithMany(p => p.AuthUserUserPermissions)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_user_user_permi_permission_id_1fbb5f2c_fk_auth_perm");

            entity.HasOne(d => d.User).WithMany(p => p.AuthUserUserPermissions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_user_user_permissions_user_id_a95ead1b_fk_auth_user_id");
        });

        modelBuilder.Entity<DjangoAdminLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("django_admin_log")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.ContentTypeId, "django_admin_log_content_type_id_c4bce8eb_fk_django_co");

            entity.HasIndex(e => e.UserId, "django_admin_log_user_id_c564eba6_fk_auth_user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionFlag).HasColumnName("action_flag");
            entity.Property(e => e.ActionTime)
                .HasMaxLength(6)
                .HasColumnName("action_time");
            entity.Property(e => e.ChangeMessage).HasColumnName("change_message");
            entity.Property(e => e.ContentTypeId).HasColumnName("content_type_id");
            entity.Property(e => e.ObjectId).HasColumnName("object_id");
            entity.Property(e => e.ObjectRepr)
                .HasMaxLength(200)
                .HasColumnName("object_repr");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.ContentType).WithMany(p => p.DjangoAdminLogs)
                .HasForeignKey(d => d.ContentTypeId)
                .HasConstraintName("django_admin_log_content_type_id_c4bce8eb_fk_django_co");

            entity.HasOne(d => d.User).WithMany(p => p.DjangoAdminLogs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("django_admin_log_user_id_c564eba6_fk_auth_user_id");
        });

        modelBuilder.Entity<DjangoContentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("django_content_type")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => new { e.AppLabel, e.Model }, "django_content_type_app_label_model_76bd3d3b_uniq")
                .IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AppLabel)
                .HasMaxLength(100)
                .HasColumnName("app_label");
            entity.Property(e => e.Model)
                .HasMaxLength(100)
                .HasColumnName("model");
        });

        modelBuilder.Entity<DjangoMigration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("django_migrations")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.App)
                .HasMaxLength(255)
                .HasColumnName("app");
            entity.Property(e => e.Applied)
                .HasMaxLength(6)
                .HasColumnName("applied");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<DjangoSession>(entity =>
        {
            entity.HasKey(e => e.SessionKey).HasName("PRIMARY");

            entity
                .ToTable("django_session")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.ExpireDate, "django_session_expire_date_a5c62663");

            entity.Property(e => e.SessionKey)
                .HasMaxLength(40)
                .HasColumnName("session_key");
            entity.Property(e => e.ExpireDate)
                .HasMaxLength(6)
                .HasColumnName("expire_date");
            entity.Property(e => e.SessionData).HasColumnName("session_data");
        });

        modelBuilder.Entity<PanelAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("panel_account")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.Code, "code").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ban).HasColumnName("ban");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.Rank).HasColumnName("rank");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(6)
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<PanelBank>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("panel_bank")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountNumber)
                .HasMaxLength(200)
                .HasColumnName("account_number");
            entity.Property(e => e.BankName)
                .HasMaxLength(200)
                .HasColumnName("bank_name");
            entity.Property(e => e.Cardnum)
                .HasMaxLength(200)
                .HasColumnName("cardnum");
            entity.Property(e => e.Inventory).HasColumnName("inventory");
            entity.Property(e => e.Owner)
                .HasMaxLength(200)
                .HasColumnName("owner");
            entity.Property(e => e.Shaba)
                .HasMaxLength(256)
                .HasColumnName("shaba");
        });

        modelBuilder.Entity<PanelFeestructure>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("panel_feestructure");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.Fee)
                .HasPrecision(5, 2)
                .HasColumnName("fee");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.Rank).HasColumnName("rank");
            entity.Property(e => e.Threshold)
                .HasPrecision(10, 2)
                .HasColumnName("threshold");
        });

        modelBuilder.Entity<PanelOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("panel_order")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.AccountId, "panel_order_account_id_3d84fac8_fk_panel_account_id");

            entity.HasIndex(e => e.ProductId, "panel_order_product_id_6a18a101_fk_panel_product_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Amount)
                .HasPrecision(25, 6)
                .HasColumnName("amount");
            entity.Property(e => e.Comment)
                .HasMaxLength(500)
                .HasColumnName("comment");
            entity.Property(e => e.ConvertToUsd).HasColumnName("convert_to_usd");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.Fee)
                .HasPrecision(25, 6)
                .HasColumnName("fee");
            entity.Property(e => e.Item)
                .HasMaxLength(2)
                .HasColumnName("item");
            entity.Property(e => e.Lock).HasColumnName("lock");
            entity.Property(e => e.MsgId).HasColumnName("msg_id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.RialRate).HasColumnName("rial_rate");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Type).HasColumnName("_type");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(6)
                .HasColumnName("updated_at");
            entity.Property(e => e.UsdRate)
                .HasPrecision(25, 6)
                .HasColumnName("usd_rate");

            entity.HasOne(d => d.Account).WithMany(p => p.PanelOrders)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("panel_order_account_id_3d84fac8_fk_panel_account_id");

            entity.HasOne(d => d.Product).WithMany(p => p.PanelOrders)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("panel_order_product_id_6a18a101_fk_panel_product_id");
        });

        modelBuilder.Entity<PanelPayment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("panel_payment")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.AccountId, "panel_payment_account_id_0a5b37a9");

            entity.HasIndex(e => e.RelatedPaymentId, "related_payment_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.Method)
                .HasMaxLength(10)
                .HasColumnName("method");
            entity.Property(e => e.RelatedPaymentId).HasColumnName("related_payment_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(6)
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Account).WithMany(p => p.PanelPayments)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("panel_payment_account_id_0a5b37a9_fk_panel_account_id");

            entity.HasOne(d => d.RelatedPayment).WithOne(p => p.InverseRelatedPayment)
                .HasForeignKey<PanelPayment>(d => d.RelatedPaymentId)
                .HasConstraintName("panel_payment_related_payment_id_3f6ad867_fk");
        });

        modelBuilder.Entity<PanelPaymentbank>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("panel_paymentbank")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.BankId, "panel_paymentbank_bank_id_3788c47d_fk");

            entity.HasIndex(e => e.PaymentId, "payment_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BankId).HasColumnName("bank_id");
            entity.Property(e => e.PaymentId).HasColumnName("payment_id");

            entity.HasOne(d => d.Bank).WithMany(p => p.PanelPaymentbanks)
                .HasForeignKey(d => d.BankId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("panel_paymentbank_bank_id_3788c47d_fk");

            entity.HasOne(d => d.Payment).WithOne(p => p.PanelPaymentbank)
                .HasForeignKey<PanelPaymentbank>(d => d.PaymentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("panel_paymentbank_payment_id_f4d112e4_fk");
        });

        modelBuilder.Entity<PanelPaymentcash>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("panel_paymentcash")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.PaymentId, "payment_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountantApproval).HasColumnName("accountant_approval");
            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.Receiver)
                .HasMaxLength(10)
                .HasColumnName("receiver");

            entity.HasOne(d => d.Payment).WithOne(p => p.PanelPaymentcash)
                .HasForeignKey<PanelPaymentcash>(d => d.PaymentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("panel_paymentcash_payment_id_3f012643_fk");
        });

        modelBuilder.Entity<PanelPaymentdeposite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("panel_paymentdeposite")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.PaymentId, "payment_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountantApproval).HasColumnName("accountant_approval");
            entity.Property(e => e.PaymentId).HasColumnName("payment_id");

            entity.HasOne(d => d.Payment).WithOne(p => p.PanelPaymentdeposite)
                .HasForeignKey<PanelPaymentdeposite>(d => d.PaymentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("panel_paymentdeposite_payment_id_aaa24a45_fk");
        });

        modelBuilder.Entity<PanelPaymentgateway>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("panel_paymentgateway")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.PaymentId, "payment_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GatewayConfirmation).HasColumnName("gateway_confirmation");
            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.TransactionDetails).HasColumnName("transaction_details");

            entity.HasOne(d => d.Payment).WithOne(p => p.PanelPaymentgateway)
                .HasForeignKey<PanelPaymentgateway>(d => d.PaymentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("panel_paymentgateway_payment_id_24c16ea7_fk");
        });

        modelBuilder.Entity<PanelProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("panel_product")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.Iso, "iso").IsUnique();

            entity.HasIndex(e => e.SortOrder, "sort_order").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ConvertToUsd).HasColumnName("convert_to_usd");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.Iso)
                .HasMaxLength(4)
                .HasColumnName("iso");
            entity.Property(e => e.Limit).HasColumnName("limit");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.RialRate).HasColumnName("rial_rate");
            entity.Property(e => e.SortOrder).HasColumnName("sort_order");
            entity.Property(e => e.Type).HasColumnName("_type");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(6)
                .HasColumnName("updated_at");
            entity.Property(e => e.UsdRate)
                .HasPrecision(25, 6)
                .HasColumnName("usd_rate");
        });

        modelBuilder.Entity<PanelProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("panel_profile")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.AccountId, "account_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Address)
                .HasMaxLength(150)
                .HasColumnName("address");
            entity.Property(e => e.Comment)
                .HasMaxLength(256)
                .HasColumnName("comment");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.Idcode)
                .HasMaxLength(150)
                .HasColumnName("idcode");
            entity.Property(e => e.Mobile)
                .HasMaxLength(150)
                .HasColumnName("mobile");
            entity.Property(e => e.Pin)
                .HasMaxLength(150)
                .HasColumnName("pin");
            entity.Property(e => e.ProfileName)
                .HasMaxLength(150)
                .HasColumnName("profile_name");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(6)
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Account).WithOne(p => p.PanelProfile)
                .HasForeignKey<PanelProfile>(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("panel_profile_account_id_aad41293_fk_panel_account_id");
        });

        modelBuilder.Entity<PanelReadycommand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("panel_readycommand")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Command)
                .HasMaxLength(50)
                .HasColumnName("command");
            entity.Property(e => e.Text)
                .HasMaxLength(500)
                .HasColumnName("text");
        });

        modelBuilder.Entity<PanelReservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("panel_reservation");

            entity.HasIndex(e => e.AccountId, "panel_reservation_account_id_5a81ce0c_fk_panel_account_id");

            entity.HasIndex(e => new { e.Date, e.Time }, "panel_reservation_date_time_7c4ecc81_uniq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.ApprovedAt)
                .HasMaxLength(6)
                .HasColumnName("approved_at");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .HasColumnName("status");
            entity.Property(e => e.Time)
                .HasMaxLength(6)
                .HasColumnName("time");

            entity.HasOne(d => d.Account).WithMany(p => p.PanelReservations)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("panel_reservation_account_id_5a81ce0c_fk_panel_account_id");
        });

        modelBuilder.Entity<PanelSurvey>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("panel_survey")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.UserId, "panel_survey_user_id_9ec07856_fk_panel_account_id");

            entity.HasIndex(e => e.PaymentId, "payment_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.Status)
                .HasMaxLength(200)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(6)
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Payment).WithOne(p => p.PanelSurvey)
                .HasForeignKey<PanelSurvey>(d => d.PaymentId)
                .HasConstraintName("panel_survey_payment_id_4be68a8e_fk_panel_transaction_id");

            entity.HasOne(d => d.User).WithMany(p => p.PanelSurveys)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("panel_survey_user_id_9ec07856_fk_panel_account_id");
        });

        modelBuilder.Entity<PanelSurveyanswer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("panel_surveyanswer")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.OptionId, "panel_surveyanswer_option_id_178e8ab2_fk_panel_surveyoption_id");

            entity.HasIndex(e => e.QuestionId, "panel_surveyanswer_question_id_ecb4a1a6_fk_panel_sur");

            entity.HasIndex(e => e.SurveyId, "panel_surveyanswer_survey_id_8b423669_fk_panel_survey_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.OptionId).HasColumnName("option_id");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.SurveyId).HasColumnName("survey_id");

            entity.HasOne(d => d.Option).WithMany(p => p.PanelSurveyanswers)
                .HasForeignKey(d => d.OptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("panel_surveyanswer_option_id_178e8ab2_fk_panel_surveyoption_id");

            entity.HasOne(d => d.Question).WithMany(p => p.PanelSurveyanswers)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("panel_surveyanswer_question_id_ecb4a1a6_fk_panel_sur");

            entity.HasOne(d => d.Survey).WithMany(p => p.PanelSurveyanswers)
                .HasForeignKey(d => d.SurveyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("panel_surveyanswer_survey_id_8b423669_fk_panel_survey_id");
        });

        modelBuilder.Entity<PanelSurveyoption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("panel_surveyoption")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.Enable).HasColumnName("enable");
            entity.Property(e => e.Text)
                .HasMaxLength(200)
                .HasColumnName("text");
        });

        modelBuilder.Entity<PanelSurveyquestion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("panel_surveyquestion")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.Enable).HasColumnName("enable");
            entity.Property(e => e.Text)
                .HasMaxLength(200)
                .HasColumnName("text");
        });

        modelBuilder.Entity<PanelTelegramuser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("panel_telegramuser")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.AccountId, "account_id").IsUnique();

            entity.HasIndex(e => e.UserId, "user_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Bio)
                .HasMaxLength(200)
                .HasColumnName("bio");
            entity.Property(e => e.Fullname)
                .HasMaxLength(150)
                .HasColumnName("fullname");
            entity.Property(e => e.Profilepic)
                .HasMaxLength(200)
                .HasColumnName("profilepic");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Username)
                .HasMaxLength(200)
                .HasColumnName("username");

            entity.HasOne(d => d.Account).WithOne(p => p.PanelTelegramuser)
                .HasForeignKey<PanelTelegramuser>(d => d.AccountId)
                .HasConstraintName("panel_telegramuser_account_id_ac84abce_fk_panel_account_id");
        });

        modelBuilder.Entity<PanelTransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("panel_transaction")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.AccountId, "panel_transaction_account_id_0e48b70d_fk_panel_account_id");

            entity.HasIndex(e => e.ProductId, "panel_transaction_product_id_2a4035c9_fk_panel_product_id");

            entity.HasIndex(e => e.RelatedTransactionId, "panel_transaction_related_transaction_id_26497809_uniq")
                .IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Amount)
                .HasPrecision(15, 6)
                .HasColumnName("amount");
            entity.Property(e => e.Comment)
                .HasMaxLength(500)
                .HasColumnName("comment");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.MsgId).HasColumnName("msg_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.RelatedTransactionId).HasColumnName("related_transaction_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Type)
                .HasMaxLength(2)
                .HasColumnName("_type");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(6)
                .HasColumnName("updated_at");
            entity.Property(e => e.WebFee)
                .HasPrecision(15, 6)
                .HasColumnName("web_fee");

            entity.HasOne(d => d.Account).WithMany(p => p.PanelTransactions)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("panel_transaction_account_id_0e48b70d_fk_panel_account_id");

            entity.HasOne(d => d.Product).WithMany(p => p.PanelTransactions)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("panel_transaction_product_id_2a4035c9_fk_panel_product_id");

            entity.HasOne(d => d.RelatedTransaction).WithOne(p => p.InverseRelatedTransaction)
                .HasForeignKey<PanelTransaction>(d => d.RelatedTransactionId)
                .HasConstraintName("panel_transaction_related_transaction__26497809_fk_panel_tra");
        });

        modelBuilder.Entity<PanelWallet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("panel_wallet")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.ProductId, "panel_wallet_product_id_52ca1e8e_fk_panel_product_id");

            entity.HasIndex(e => new { e.AccountId, e.ProductId }, "unique appversion").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Balance)
                .HasPrecision(25, 6)
                .HasColumnName("balance");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(6)
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Account).WithMany(p => p.PanelWallets)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("panel_wallet_account_id_efe6f1c2_fk_panel_account_id");

            entity.HasOne(d => d.Product).WithMany(p => p.PanelWallets)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("panel_wallet_product_id_52ca1e8e_fk_panel_product_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
