﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReserbizAPP.LIB.DbContexts;

namespace ReserbizAPP.LIB.Migrations.ReserbizClientData
{
    [DbContext(typeof(ReserbizClientDataContext))]
    [Migration("20200301080206_SetupAccountPaymentBreakdownsActionTrackerConstraint")]
    partial class SetupAccountPaymentBreakdownsActionTrackerConstraint
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReserbizAPP.LIB.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateDeactivated");

                    b.Property<DateTime>("DateDeleted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<int?>("DeactivatedById");

                    b.Property<int?>("DeletedById");

                    b.Property<string>("FirstName");

                    b.Property<int>("Gender");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("PhotoUrl");

                    b.Property<int?>("UpdatedById");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DeactivatedById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("UpdatedById");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("ReserbizAPP.LIB.Models.AccountStatement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdvancedPaymentDurationValue");

                    b.Property<int>("ContractId");

                    b.Property<int?>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateDeactivated");

                    b.Property<DateTime>("DateDeleted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<int?>("DeactivatedById");

                    b.Property<int?>("DeletedById");

                    b.Property<int>("DepositPaymentDurationValue");

                    b.Property<DateTime>("DueDate");

                    b.Property<int>("DurationUnit");

                    b.Property<float>("ElectricBill");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDelete");

                    b.Property<int>("PenaltyAmountPerDurationUnit");

                    b.Property<int>("PenaltyEffectiveAfterDurationUnit");

                    b.Property<int>("PenaltyEffectiveAfterDurationValue");

                    b.Property<float>("PenaltyValue");

                    b.Property<int>("PenaltyValueType");

                    b.Property<float>("Rate");

                    b.Property<int?>("UpdatedById");

                    b.Property<float>("WaterBill");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DeactivatedById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("UpdatedById");

                    b.ToTable("AccountStatements");
                });

            modelBuilder.Entity("ReserbizAPP.LIB.Models.AccountStatementMiscellaneous", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountStatementId");

                    b.Property<float>("Amount");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateDeactivated");

                    b.Property<DateTime>("DateDeleted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AccountStatementId");

                    b.ToTable("AccountStatementMiscellaneous");
                });

            modelBuilder.Entity("ReserbizAPP.LIB.Models.ClientSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateDeactivated");

                    b.Property<DateTime>("DateDeleted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<int?>("DeactivatedById");

                    b.Property<int?>("DeletedById");

                    b.Property<int>("GenerateAccountStatementDaysBeforeValue");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDelete");

                    b.Property<int?>("UpdatedById");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DeactivatedById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("UpdatedById");

                    b.ToTable("ClientSettings");
                });

            modelBuilder.Entity("ReserbizAPP.LIB.Models.ContactPerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactNumber");

                    b.Property<int?>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateDeactivated");

                    b.Property<DateTime>("DateDeleted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<int?>("DeactivatedById");

                    b.Property<int?>("DeletedById");

                    b.Property<string>("FirstName");

                    b.Property<int>("Gender");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.Property<string>("PhotoUrl");

                    b.Property<int>("TenantId");

                    b.Property<int?>("UpdatedById");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DeactivatedById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("TenantId");

                    b.HasIndex("UpdatedById");

                    b.ToTable("ContactPersons");
                });

            modelBuilder.Entity("ReserbizAPP.LIB.Models.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<int?>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateDeactivated");

                    b.Property<DateTime>("DateDeleted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<int?>("DeactivatedById");

                    b.Property<int?>("DeletedById");

                    b.Property<int>("DurationUnit");

                    b.Property<int>("DurationValue");

                    b.Property<DateTime>("EffectiveDate");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDelete");

                    b.Property<bool>("IsOpenContract");

                    b.Property<int>("TenantId");

                    b.Property<int>("TermId");

                    b.Property<int?>("UpdatedById");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DeactivatedById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("TenantId");

                    b.HasIndex("TermId");

                    b.HasIndex("UpdatedById");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("ReserbizAPP.LIB.Models.ErrorLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateDeactivated");

                    b.Property<DateTime>("DateDeleted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("Message");

                    b.Property<string>("Source");

                    b.Property<string>("Stacktrace");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ErrorLogs");
                });

            modelBuilder.Entity("ReserbizAPP.LIB.Models.PaymentBreakdown", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountStatementId");

                    b.Property<float>("Amount");

                    b.Property<int?>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateDeactivated");

                    b.Property<DateTime>("DateDeleted");

                    b.Property<DateTime>("DateTimeReceived");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<int?>("DeactivatedById");

                    b.Property<int?>("DeletedById");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDelete");

                    b.Property<int>("ReceivedById");

                    b.Property<int?>("UpdatedById");

                    b.HasKey("Id");

                    b.HasIndex("AccountStatementId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DeactivatedById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("ReceivedById");

                    b.HasIndex("UpdatedById");

                    b.ToTable("PaymentBreakdowns");
                });

            modelBuilder.Entity("ReserbizAPP.LIB.Models.PenaltyBreakdown", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountStatementId");

                    b.Property<float>("Amount");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateDeactivated");

                    b.Property<DateTime>("DateDeleted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<DateTime>("DueDate");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDelete");

                    b.HasKey("Id");

                    b.HasIndex("AccountStatementId");

                    b.ToTable("PenaltyBreakdowns");
                });

            modelBuilder.Entity("ReserbizAPP.LIB.Models.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateDeactivated");

                    b.Property<DateTime>("DateDeleted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<DateTime>("ExpirationDate");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("Token");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("ReserbizAPP.LIB.Models.SpaceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AvailableSlot");

                    b.Property<int?>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateDeactivated");

                    b.Property<DateTime>("DateDeleted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<int?>("DeactivatedById");

                    b.Property<int?>("DeletedById");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("Name");

                    b.Property<float>("Rate");

                    b.Property<int?>("UpdatedById");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DeactivatedById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("UpdatedById");

                    b.ToTable("SpaceTypes");
                });

            modelBuilder.Entity("ReserbizAPP.LIB.Models.Tenant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("ContactNumber");

                    b.Property<int?>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateDeactivated");

                    b.Property<DateTime>("DateDeleted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<int?>("DeactivatedById");

                    b.Property<int?>("DeletedById");

                    b.Property<string>("EmailAddress");

                    b.Property<string>("FirstName");

                    b.Property<int>("Gender");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("PhotoUrl");

                    b.Property<int?>("UpdatedById");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DeactivatedById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("UpdatedById");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("ReserbizAPP.LIB.Models.Term", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdvancedPaymentDurationValue");

                    b.Property<string>("Code");

                    b.Property<int?>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateDeactivated");

                    b.Property<DateTime>("DateDeleted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<int?>("DeactivatedById");

                    b.Property<int?>("DeletedById");

                    b.Property<int>("DepositPaymentDurationValue");

                    b.Property<int>("DurationUnit");

                    b.Property<float>("ElectricBillAmount");

                    b.Property<bool>("ExcludeElectricBill");

                    b.Property<bool>("ExcludeWaterBill");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDelete");

                    b.Property<int>("MaximumNumberOfOccupants");

                    b.Property<string>("Name");

                    b.Property<int>("PenaltyAmountPerDurationUnit");

                    b.Property<int>("PenaltyEffectiveAfterDurationUnit");

                    b.Property<int>("PenaltyEffectiveAfterDurationValue");

                    b.Property<float>("PenaltyValue");

                    b.Property<int>("PenaltyValueType");

                    b.Property<float>("Rate");

                    b.Property<int>("SpaceTypeId");

                    b.Property<int?>("UpdatedById");

                    b.Property<float>("WaterBillAmount");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DeactivatedById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("SpaceTypeId");

                    b.HasIndex("UpdatedById");

                    b.ToTable("Terms");
                });

            modelBuilder.Entity("ReserbizAPP.LIB.Models.TermMiscellaneous", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Amount");

                    b.Property<int?>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateDeactivated");

                    b.Property<DateTime>("DateDeleted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<int?>("DeactivatedById");

                    b.Property<int?>("DeletedById");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("Name");

                    b.Property<int>("TermId");

                    b.Property<int?>("UpdatedById");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DeactivatedById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("TermId");

                    b.HasIndex("UpdatedById");

                    b.ToTable("TermMiscellaneous");
                });

            modelBuilder.Entity("ReserbizAPP.LIB.Models.Account", b =>
                {
                    b.HasOne("ReserbizAPP.LIB.Models.Account", "CreatedBy")
                        .WithMany("CreatedAccounts")
                        .HasForeignKey("CreatedById")
                        .HasConstraintName("FK_Accounts_CreatedById_Accounts_AccountId");

                    b.HasOne("ReserbizAPP.LIB.Models.Account", "DeactivatedBy")
                        .WithMany("DeactivatedAccounts")
                        .HasForeignKey("DeactivatedById")
                        .HasConstraintName("FK_Accounts_DeactivatedById_Accounts_AccountId");

                    b.HasOne("ReserbizAPP.LIB.Models.Account", "DeletedBy")
                        .WithMany("DeletedAccounts")
                        .HasForeignKey("DeletedById")
                        .HasConstraintName("FK_Accounts_DeletedById_Accounts_AccountId");

                    b.HasOne("ReserbizAPP.LIB.Models.Account", "UpdatedBy")
                        .WithMany("UpdatedAccounts")
                        .HasForeignKey("UpdatedById")
                        .HasConstraintName("FK_Accounts_UpdatedById_Accounts_AccountId");
                });

            modelBuilder.Entity("ReserbizAPP.LIB.Models.AccountStatement", b =>
                {
                    b.HasOne("ReserbizAPP.LIB.Models.Contract", "Contract")
                        .WithMany("AccountStatements")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ReserbizAPP.LIB.Models.Account", "CreatedBy")
                        .WithMany("CreatedAccountStatements")
                        .HasForeignKey("CreatedById")
                        .HasConstraintName("FK_AccountStatements_CreatedById_Accounts_AccountId");

                    b.HasOne("ReserbizAPP.LIB.Models.Account", "DeactivatedBy")
                        .WithMany("DeactivatedAccountStatements")
                        .HasForeignKey("DeactivatedById")
                        .HasConstraintName("FK_AccountStatements_DeactivatedById_Accounts_AccountId");

                    b.HasOne("ReserbizAPP.LIB.Models.Account", "DeletedBy")
                        .WithMany("DeletedAccountStatements")
                        .HasForeignKey("DeletedById")
                        .HasConstraintName("FK_AccountStatements_DeletedById_Accounts_AccountId");

                    b.HasOne("ReserbizAPP.LIB.Models.Account", "UpdatedBy")
                        .WithMany("UpdatedAccountStatements")
                        .HasForeignKey("UpdatedById")
                        .HasConstraintName("FK_AccountStatements_UpdatedById_Accounts_AccountId");
                });

            modelBuilder.Entity("ReserbizAPP.LIB.Models.AccountStatementMiscellaneous", b =>
                {
                    b.HasOne("ReserbizAPP.LIB.Models.AccountStatement", "AccountStatement")
                        .WithMany("AccountStatementMiscellaneous")
                        .HasForeignKey("AccountStatementId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ReserbizAPP.LIB.Models.ClientSettings", b =>
                {
                    b.HasOne("ReserbizAPP.LIB.Models.Account", "CreatedBy")
                        .WithMany("CreatedClientSettings")
                        .HasForeignKey("CreatedById")
                        .HasConstraintName("FK_ClientSettings_CreatedById_Accounts_AccountId");

                    b.HasOne("ReserbizAPP.LIB.Models.Account", "DeactivatedBy")
                        .WithMany("DeactivatedClientSettings")
                        .HasForeignKey("DeactivatedById")
                        .HasConstraintName("FK_ClientSettings_DeactivatedById_Accounts_AccountId");

                    b.HasOne("ReserbizAPP.LIB.Models.Account", "DeletedBy")
                        .WithMany("DeletedClientSettings")
                        .HasForeignKey("DeletedById")
                        .HasConstraintName("FK_ClientSettings_DeletedById_Accounts_AccountId");

                    b.HasOne("ReserbizAPP.LIB.Models.Account", "UpdatedBy")
                        .WithMany("UpdatedClientSettings")
                        .HasForeignKey("UpdatedById")
                        .HasConstraintName("FK_ClientSettings_UpdatedById_Accounts_AccountId");
                });

            modelBuilder.Entity("ReserbizAPP.LIB.Models.ContactPerson", b =>
                {
                    b.HasOne("ReserbizAPP.LIB.Models.Account", "CreatedBy")
                        .WithMany("CreatedContactPersons")
                        .HasForeignKey("CreatedById")
                        .HasConstraintName("FK_ContactPersons_CreatedById_Accounts_AccountId");

                    b.HasOne("ReserbizAPP.LIB.Models.Account", "DeactivatedBy")
                        .WithMany("DeactivatedContactPersons")
                        .HasForeignKey("DeactivatedById")
                        .HasConstraintName("FK_ContactPersons_DeactivatedById_Accounts_AccountId");

                    b.HasOne("ReserbizAPP.LIB.Models.Account", "DeletedBy")
                        .WithMany("DeletedContactPersons")
                        .HasForeignKey("DeletedById")
                        .HasConstraintName("FK_ContactPersons_DeletedById_Accounts_AccountId");

                    b.HasOne("ReserbizAPP.LIB.Models.Tenant", "Tenant")
                        .WithMany("ContactPersons")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ReserbizAPP.LIB.Models.Account", "UpdatedBy")
                        .WithMany("UpdatedContactPersons")
                        .HasForeignKey("UpdatedById")
                        .HasConstraintName("FK_ContactPersons_UpdatedById_Accounts_AccountId");
                });

            modelBuilder.Entity("ReserbizAPP.LIB.Models.Contract", b =>
                {
                    b.HasOne("ReserbizAPP.LIB.Models.Account", "CreatedBy")
                        .WithMany("CreatedContracts")
                        .HasForeignKey("CreatedById")
                        .HasConstraintName("FK_Contracts_CreatedById_Accounts_AccountId");

                    b.HasOne("ReserbizAPP.LIB.Models.Account", "DeactivatedBy")
                        .WithMany("DeactivatedContracts")
                        .HasForeignKey("DeactivatedById")
                        .HasConstraintName("FK_Contracts_DeactivatedById_Accounts_AccountId");

                    b.HasOne("ReserbizAPP.LIB.Models.Account", "DeletedBy")
                        .WithMany("DeletedContracts")
                        .HasForeignKey("DeletedById")
                        .HasConstraintName("FK_Contracts_DeletedById_Accounts_AccountId");

                    b.HasOne("ReserbizAPP.LIB.Models.Tenant", "Tenant")
                        .WithMany("Contracts")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ReserbizAPP.LIB.Models.Term", "Term")
                        .WithMany()
                        .HasForeignKey("TermId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ReserbizAPP.LIB.Models.Account", "UpdatedBy")
                        .WithMany("UpdatedContracts")
                        .HasForeignKey("UpdatedById")
                        .HasConstraintName("FK_Contracts_UpdatedById_Accounts_AccountId");
                });

            modelBuilder.Entity("ReserbizAPP.LIB.Models.ErrorLog", b =>
                {
                    b.HasOne("ReserbizAPP.LIB.Models.Account", "User")
                        .WithMany("ErrorLogs")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_ErrorLogs_Accounts_UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ReserbizAPP.LIB.Models.PaymentBreakdown", b =>
                {
                    b.HasOne("ReserbizAPP.LIB.Models.AccountStatement", "AccountStatement")
                        .WithMany("PaymentBreakdowns")
                        .HasForeignKey("AccountStatementId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ReserbizAPP.LIB.Models.Account", "CreatedBy")
                        .WithMany("CreatedPaymentBreakdowns")
                        .HasForeignKey("CreatedById")
                        .HasConstraintName("FK_PaymentBreakdown_CreatedById_Accounts_AccountId");

                    b.HasOne("ReserbizAPP.LIB.Models.Account", "DeactivatedBy")
                        .WithMany("DeactivatedPaymentBreakdowns")
                        .HasForeignKey("DeactivatedById")
                        .HasConstraintName("FK_PaymentBreakdowns_DeactivatedById_Accounts_AccountId");

                    b.HasOne("ReserbizAPP.LIB.Models.Account", "DeletedBy")
                        .WithMany("DeletedPaymentBreakdowns")
                        .HasForeignKey("DeletedById")
                        .HasConstraintName("FK_PaymentBreakdown_DeletedById_Accounts_AccountId");

                    b.HasOne("ReserbizAPP.LIB.Models.Account", "ReceivedBy")
                        .WithMany()
                        .HasForeignKey("ReceivedById")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ReserbizAPP.LIB.Models.Account", "UpdatedBy")
                        .WithMany("UpdatedPaymentBreakdowns")
                        .HasForeignKey("UpdatedById")
                        .HasConstraintName("FK_PaymentBreakdowns_UpdatedById_Accounts_AccountId");
                });

            modelBuilder.Entity("ReserbizAPP.LIB.Models.PenaltyBreakdown", b =>
                {
                    b.HasOne("ReserbizAPP.LIB.Models.AccountStatement", "AccountStatement")
                        .WithMany("PenaltyBreakdowns")
                        .HasForeignKey("AccountStatementId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ReserbizAPP.LIB.Models.RefreshToken", b =>
                {
                    b.HasOne("ReserbizAPP.LIB.Models.Account", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("FK_RefreshToken_Accounts_AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ReserbizAPP.LIB.Models.SpaceType", b =>
                {
                    b.HasOne("ReserbizAPP.LIB.Models.Account", "CreatedBy")
                        .WithMany("CreatedSpaceTypes")
                        .HasForeignKey("CreatedById")
                        .HasConstraintName("FK_SpaceTypes_CreatedById_Accounts_AccountId");

                    b.HasOne("ReserbizAPP.LIB.Models.Account", "DeactivatedBy")
                        .WithMany("DeactivatedSpaceTypes")
                        .HasForeignKey("DeactivatedById")
                        .HasConstraintName("FK_SpaceTypes_DeactivatedById_Accounts_AccountId");

                    b.HasOne("ReserbizAPP.LIB.Models.Account", "DeletedBy")
                        .WithMany("DeletedSpaceTypes")
                        .HasForeignKey("DeletedById")
                        .HasConstraintName("FK_SpaceTypes_DeletedById_Accounts_AccountId");

                    b.HasOne("ReserbizAPP.LIB.Models.Account", "UpdatedBy")
                        .WithMany("UpdatedSpaceTypes")
                        .HasForeignKey("UpdatedById")
                        .HasConstraintName("FK_SpaceTypes_UpdatedById_Accounts_AccountId");
                });

            modelBuilder.Entity("ReserbizAPP.LIB.Models.Tenant", b =>
                {
                    b.HasOne("ReserbizAPP.LIB.Models.Account", "CreatedBy")
                        .WithMany("CreatedTenants")
                        .HasForeignKey("CreatedById")
                        .HasConstraintName("FK_Tenants_CreatedById_Accounts_AccountId");

                    b.HasOne("ReserbizAPP.LIB.Models.Account", "DeactivatedBy")
                        .WithMany("DeactivatedTenants")
                        .HasForeignKey("DeactivatedById")
                        .HasConstraintName("FK_Tenants_DeactivatedById_Accounts_AccountId");

                    b.HasOne("ReserbizAPP.LIB.Models.Account", "DeletedBy")
                        .WithMany("DeletedTenants")
                        .HasForeignKey("DeletedById")
                        .HasConstraintName("FK_Tenants_DeletedById_Accounts_AccountId");

                    b.HasOne("ReserbizAPP.LIB.Models.Account", "UpdatedBy")
                        .WithMany("UpdatedTenants")
                        .HasForeignKey("UpdatedById")
                        .HasConstraintName("FK_Tenants_UpdatedById_Accounts_AccountId");
                });

            modelBuilder.Entity("ReserbizAPP.LIB.Models.Term", b =>
                {
                    b.HasOne("ReserbizAPP.LIB.Models.Account", "CreatedBy")
                        .WithMany("CreatedTerms")
                        .HasForeignKey("CreatedById")
                        .HasConstraintName("FK_Terms_CreatedById_Accounts_AccountId");

                    b.HasOne("ReserbizAPP.LIB.Models.Account", "DeactivatedBy")
                        .WithMany("DeactivatedTerms")
                        .HasForeignKey("DeactivatedById")
                        .HasConstraintName("FK_Terms_DeactivatedById_Accounts_AccountId");

                    b.HasOne("ReserbizAPP.LIB.Models.Account", "DeletedBy")
                        .WithMany("DeletedTerms")
                        .HasForeignKey("DeletedById")
                        .HasConstraintName("FK_Terms_DeletedById_Accounts_AccountId");

                    b.HasOne("ReserbizAPP.LIB.Models.SpaceType", "SpaceType")
                        .WithMany()
                        .HasForeignKey("SpaceTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ReserbizAPP.LIB.Models.Account", "UpdatedBy")
                        .WithMany("UpdatedTerms")
                        .HasForeignKey("UpdatedById")
                        .HasConstraintName("FK_Terms_UpdatedById_Accounts_AccountId");
                });

            modelBuilder.Entity("ReserbizAPP.LIB.Models.TermMiscellaneous", b =>
                {
                    b.HasOne("ReserbizAPP.LIB.Models.Account", "CreatedBy")
                        .WithMany("CreatedTermMiscellaneous")
                        .HasForeignKey("CreatedById")
                        .HasConstraintName("FK_TermMiscellaneous_CreatedById_Accounts_AccountId");

                    b.HasOne("ReserbizAPP.LIB.Models.Account", "DeactivatedBy")
                        .WithMany("DeactivatedTermMiscellaneous")
                        .HasForeignKey("DeactivatedById")
                        .HasConstraintName("FK_TermMiscellaneous_DeactivatedById_Accounts_AccountId");

                    b.HasOne("ReserbizAPP.LIB.Models.Account", "DeletedBy")
                        .WithMany("DeletedTermMiscellaneous")
                        .HasForeignKey("DeletedById")
                        .HasConstraintName("FK_TermMiscellaneous_DeletedById_Accounts_AccountId");

                    b.HasOne("ReserbizAPP.LIB.Models.Term", "Term")
                        .WithMany("TermMiscellaneous")
                        .HasForeignKey("TermId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ReserbizAPP.LIB.Models.Account", "UpdatedBy")
                        .WithMany("UpdatedTermMiscellaneous")
                        .HasForeignKey("UpdatedById")
                        .HasConstraintName("FK_TermMiscellaneous_UpdatedById_Accounts_AccountId");
                });
#pragma warning restore 612, 618
        }
    }
}
