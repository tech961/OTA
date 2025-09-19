using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rs.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_RealEstate_Model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "RealEstate");

            migrationBuilder.CreateTable(
                name: "RealEstates",
                schema: "RealEstate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Loaction = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    NeighborhoodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LogoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Credit = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstates_AspNetUsers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealEstates_Neighborhoods_NeighborhoodId",
                        column: x => x.NeighborhoodId,
                        principalSchema: "Province",
                        principalTable: "Neighborhoods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealEstateCreditTransactions",
                schema: "RealEstate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RealEstateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreditCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateCreditTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstateCreditTransactions_RealEstates_RealEstateId",
                        column: x => x.RealEstateId,
                        principalSchema: "RealEstate",
                        principalTable: "RealEstates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RealEstatePersons",
                schema: "RealEstate",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RealEstateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstatePersons", x => new { x.RealEstateId, x.UserId });
                    table.ForeignKey(
                        name: "FK_RealEstatePersons_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RealEstatePersons_RealEstates_RealEstateId",
                        column: x => x.RealEstateId,
                        principalSchema: "RealEstate",
                        principalTable: "RealEstates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RealEstateTrackingRequests",
                schema: "RealEstate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RealEstateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrackingById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResponseDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpiredTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Response = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    ResponseDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateTrackingRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstateTrackingRequests_AspNetUsers_TrackingById",
                        column: x => x.TrackingById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RealEstateTrackingRequests_RealEstates_RealEstateId",
                        column: x => x.RealEstateId,
                        principalSchema: "RealEstate",
                        principalTable: "RealEstates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealEstateTrackingRequests_Requests_RequestId",
                        column: x => x.RequestId,
                        principalSchema: "Request",
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateCreditTransactions_RealEstateId",
                schema: "RealEstate",
                table: "RealEstateCreditTransactions",
                column: "RealEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstatePersons_UserId",
                schema: "RealEstate",
                table: "RealEstatePersons",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstates_ManagerId",
                schema: "RealEstate",
                table: "RealEstates",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstates_NeighborhoodId",
                schema: "RealEstate",
                table: "RealEstates",
                column: "NeighborhoodId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateTrackingRequests_RealEstateId",
                schema: "RealEstate",
                table: "RealEstateTrackingRequests",
                column: "RealEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateTrackingRequests_RequestId",
                schema: "RealEstate",
                table: "RealEstateTrackingRequests",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateTrackingRequests_TrackingById",
                schema: "RealEstate",
                table: "RealEstateTrackingRequests",
                column: "TrackingById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RealEstateCreditTransactions",
                schema: "RealEstate");

            migrationBuilder.DropTable(
                name: "RealEstatePersons",
                schema: "RealEstate");

            migrationBuilder.DropTable(
                name: "RealEstateTrackingRequests",
                schema: "RealEstate");

            migrationBuilder.DropTable(
                name: "RealEstates",
                schema: "RealEstate");
        }
    }
}
