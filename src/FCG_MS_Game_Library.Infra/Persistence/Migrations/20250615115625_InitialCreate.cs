using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserRegistrationAndGameLibrary.Infra.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "game_platform");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "games",
                schema: "game_platform",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    release_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    genre = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    cover_image_url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_games", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "game_platform",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "gamelibraries",
                schema: "game_platform",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    GameId = table.Column<Guid>(type: "uuid", nullable: false),
                    purchase_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    purchase_price = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    is_installed = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gamelibraries", x => x.id);
                    table.CheckConstraint("ck_game_libraries_positive_price", "purchase_price >= 0");
                    table.ForeignKey(
                        name: "FK_gamelibraries_games_GameId",
                        column: x => x.GameId,
                        principalSchema: "game_platform",
                        principalTable: "games",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_gamelibraries_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "game_platform",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userAuthorizations",
                schema: "game_platform",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    permission = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userAuthorizations", x => x.id);
                    table.ForeignKey(
                        name: "FK_userAuthorizations_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "game_platform",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_game_libraries_game_id",
                schema: "game_platform",
                table: "gamelibraries",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "ix_game_libraries_user_id",
                schema: "game_platform",
                table: "gamelibraries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "ux_game_libraries_user_game",
                schema: "game_platform",
                table: "gamelibraries",
                columns: new[] { "UserId", "GameId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_games_genre",
                schema: "game_platform",
                table: "games",
                column: "genre");

            migrationBuilder.CreateIndex(
                name: "IX_games_release_date",
                schema: "game_platform",
                table: "games",
                column: "release_date");

            migrationBuilder.CreateIndex(
                name: "IX_games_title",
                schema: "game_platform",
                table: "games",
                column: "title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_userAuthorizations_UserId",
                schema: "game_platform",
                table: "userAuthorizations",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gamelibraries",
                schema: "game_platform");

            migrationBuilder.DropTable(
                name: "userAuthorizations",
                schema: "game_platform");

            migrationBuilder.DropTable(
                name: "games",
                schema: "game_platform");

            migrationBuilder.DropTable(
                name: "users",
                schema: "game_platform");
        }
    }
}
