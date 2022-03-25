using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BtcTrader.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    DayOfMonth = table.Column<byte>(type: "smallint", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    AllowSmsNotification = table.Column<bool>(type: "boolean", nullable: false),
                    AllowEmailNotification = table.Column<bool>(type: "boolean", nullable: false),
                    AllowPushNotification = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SendDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NotificationText = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    IsSendSms = table.Column<bool>(type: "boolean", nullable: false),
                    IsSendEmail = table.Column<bool>(type: "boolean", nullable: false),
                    IsSendPushNotification = table.Column<bool>(type: "boolean", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationHistories_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationHistories_OrderId",
                table: "NotificationHistories",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificationHistories");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
