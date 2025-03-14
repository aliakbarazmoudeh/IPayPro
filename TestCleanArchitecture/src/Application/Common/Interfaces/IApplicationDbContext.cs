

using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TestCleanArchitecture.Domain.Entities;

namespace TestCleanArchitecture.Application.Common.Interfaces;

public interface IApplicationDbContext : IDisposable 
{
    // DbSet Properties
    DbSet<AuthGroup> AuthGroups { get; set; }
    DbSet<AuthGroupPermission> AuthGroupPermissions { get; set; }
    DbSet<AuthPermission> AuthPermissions { get; set; }
    DbSet<AuthUser> AuthUsers { get; set; }
    DbSet<AuthUserGroup> AuthUserGroups { get; set; }
    DbSet<AuthUserUserPermission> AuthUserUserPermissions { get; set; }
    DbSet<DjangoAdminLog> DjangoAdminLogs { get; set; }
    DbSet<DjangoContentType> DjangoContentTypes { get; set; }
    DbSet<DjangoMigration> DjangoMigrations { get; set; }
    DbSet<DjangoSession> DjangoSessions { get; set; }
    DbSet<PanelAccount> PanelAccounts { get; set; }
    DbSet<PanelBank> PanelBanks { get; set; }
    DbSet<PanelFeestructure> PanelFeestructures { get; set; }
    DbSet<PanelOrder> PanelOrders { get; set; }
    DbSet<PanelPayment> PanelPayments { get; set; }
    DbSet<PanelPaymentbank> PanelPaymentbanks { get; set; }
    DbSet<PanelPaymentcash> PanelPaymentcashes { get; set; }
    DbSet<PanelPaymentdeposite> PanelPaymentdeposites { get; set; }
    DbSet<PanelPaymentgateway> PanelPaymentgateways { get; set; }
    DbSet<PanelProduct> PanelProducts { get; set; }
    DbSet<PanelProfile> PanelProfiles { get; set; }
    DbSet<PanelReadycommand> PanelReadycommands { get; set; }
    DbSet<PanelReservation> PanelReservations { get; set; }
    DbSet<PanelSurvey> PanelSurveys { get; set; }
    DbSet<PanelSurveyanswer> PanelSurveyanswers { get; set; }
    DbSet<PanelSurveyoption> PanelSurveyoptions { get; set; }
    DbSet<PanelSurveyquestion> PanelSurveyquestions { get; set; }
    DbSet<PanelTelegramuser> PanelTelegramusers { get; set; }
    DbSet<PanelTransaction> PanelTransactions { get; set; }
    DbSet<PanelWallet> PanelWallets { get; set; }

    // Core DbContext Methods
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    int SaveChanges();
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    DatabaseFacade Database { get; }
    EntityEntry Entry(object entity);
    EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
}
