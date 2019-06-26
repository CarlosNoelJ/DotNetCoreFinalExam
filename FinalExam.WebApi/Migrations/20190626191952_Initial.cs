using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalExam.WebApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "artist",
                columns: table => new
                {
                    artistId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("artist_id_pkey", x => x.artistId);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    employeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    last_name = table.Column<string>(maxLength: 20, nullable: false),
                    first_name = table.Column<string>(maxLength: 20, nullable: false),
                    title = table.Column<string>(maxLength: 30, nullable: true),
                    ReportsTo = table.Column<int>(nullable: true),
                    birthdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    hire_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    address = table.Column<string>(maxLength: 70, nullable: true),
                    city = table.Column<string>(maxLength: 40, nullable: true),
                    state = table.Column<string>(maxLength: 40, nullable: true),
                    country = table.Column<string>(maxLength: 40, nullable: true),
                    postalCode = table.Column<string>(maxLength: 10, nullable: true),
                    phone = table.Column<string>(maxLength: 24, nullable: true),
                    fax = table.Column<string>(maxLength: 24, nullable: true),
                    email = table.Column<string>(maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("employee_id_pkey", x => x.employeeId);
                    table.ForeignKey(
                        name: "Employee_ReportsTo_fkey",
                        column: x => x.ReportsTo,
                        principalTable: "employee",
                        principalColumn: "employeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "genre",
                columns: table => new
                {
                    genreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("genre_id_pkey", x => x.genreId);
                });

            migrationBuilder.CreateTable(
                name: "mediaType",
                columns: table => new
                {
                    mediaTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("mediaType_id_pkey", x => x.mediaTypeId);
                });

            migrationBuilder.CreateTable(
                name: "playlist",
                columns: table => new
                {
                    playlistId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("playlist_id_pkey", x => x.playlistId);
                });

            migrationBuilder.CreateTable(
                name: "album",
                columns: table => new
                {
                    albumId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(maxLength: 160, nullable: true),
                    ArtistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("album_id_pkey", x => x.albumId);
                    table.ForeignKey(
                        name: "FK_AlbumArtistId",
                        column: x => x.ArtistId,
                        principalTable: "artist",
                        principalColumn: "artistId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    customerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    first_name = table.Column<string>(maxLength: 40, nullable: false),
                    last_name = table.Column<string>(maxLength: 20, nullable: false),
                    company = table.Column<string>(maxLength: 80, nullable: true),
                    address = table.Column<string>(maxLength: 70, nullable: true),
                    city = table.Column<string>(maxLength: 40, nullable: true),
                    state = table.Column<string>(maxLength: 40, nullable: true),
                    country = table.Column<string>(maxLength: 40, nullable: true),
                    postal_code = table.Column<string>(maxLength: 10, nullable: true),
                    phone = table.Column<string>(maxLength: 24, nullable: true),
                    fax = table.Column<string>(maxLength: 24, nullable: true),
                    email = table.Column<string>(maxLength: 60, nullable: false),
                    SupportRepId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("customer_id_pkey", x => x.customerId);
                    table.ForeignKey(
                        name: "Customer_SupportRepId_fkey",
                        column: x => x.SupportRepId,
                        principalTable: "employee",
                        principalColumn: "employeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "track",
                columns: table => new
                {
                    trackId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 200, nullable: true),
                    AlbumId = table.Column<int>(nullable: true),
                    MediaTypeId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: true),
                    composer = table.Column<string>(maxLength: 220, nullable: true),
                    Milliseconds = table.Column<int>(nullable: false),
                    Bytes = table.Column<int>(nullable: true),
                    unit_price = table.Column<decimal>(type: "numeric(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("track_id_pkey", x => x.trackId);
                    table.ForeignKey(
                        name: "Track_AlbumId_fkey",
                        column: x => x.AlbumId,
                        principalTable: "album",
                        principalColumn: "albumId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Track_GenreId_fkey",
                        column: x => x.GenreId,
                        principalTable: "genre",
                        principalColumn: "genreId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Track_MediaTypeId_fkey",
                        column: x => x.MediaTypeId,
                        principalTable: "mediaType",
                        principalColumn: "mediaTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "invoice",
                columns: table => new
                {
                    invoiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    invoice_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    billing_address = table.Column<string>(maxLength: 70, nullable: true),
                    billing_city = table.Column<string>(maxLength: 40, nullable: true),
                    billing_state = table.Column<string>(maxLength: 40, nullable: true),
                    billing_country = table.Column<string>(maxLength: 40, nullable: true),
                    billing_postal_code = table.Column<string>(maxLength: 10, nullable: true),
                    total = table.Column<decimal>(type: "numeric(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("invoice_id_pkey", x => x.invoiceId);
                    table.ForeignKey(
                        name: "Invoice_CustomerId_fkey",
                        column: x => x.CustomerId,
                        principalTable: "customer",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "playlistTrack",
                columns: table => new
                {
                    PlaylistId = table.Column<int>(nullable: false),
                    TrackId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("playlistId_trackId_pkey", x => new { x.PlaylistId, x.TrackId });
                    table.ForeignKey(
                        name: "PlaylistTrack_PlaylistId_fkey",
                        column: x => x.PlaylistId,
                        principalTable: "playlist",
                        principalColumn: "playlistId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "PlaylistTrack_TrackId_fkey",
                        column: x => x.TrackId,
                        principalTable: "track",
                        principalColumn: "trackId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "invoiceLine",
                columns: table => new
                {
                    invoiceLineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InvoiceId = table.Column<int>(nullable: false),
                    TrackId = table.Column<int>(nullable: false),
                    unit_price = table.Column<decimal>(type: "numeric(10, 2)", nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("invoiceLine_id_pkey", x => x.invoiceLineId);
                    table.ForeignKey(
                        name: "InvoiceLine_InvoiceId_fkey",
                        column: x => x.InvoiceId,
                        principalTable: "invoice",
                        principalColumn: "invoiceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "InvoiceLine_TrackId_fkey",
                        column: x => x.TrackId,
                        principalTable: "track",
                        principalColumn: "trackId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "album_artist_idx",
                table: "album",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "Customer_SupportRepId_idx",
                table: "customer",
                column: "SupportRepId");

            migrationBuilder.CreateIndex(
                name: "Employee_ReportsTo_idx",
                table: "employee",
                column: "ReportsTo");

            migrationBuilder.CreateIndex(
                name: "invoice_customerId_idx",
                table: "invoice",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "InvoiceLine_InvoiceId_idx",
                table: "invoiceLine",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "InvoiceLine_TrackId_idx",
                table: "invoiceLine",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "playlist_trackTrackId_idx",
                table: "playlistTrack",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "Track_AlbumId_idx",
                table: "track",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "Track_GenreId_idx",
                table: "track",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "Track_MediaTypeId_idx",
                table: "track",
                column: "MediaTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "invoiceLine");

            migrationBuilder.DropTable(
                name: "playlistTrack");

            migrationBuilder.DropTable(
                name: "invoice");

            migrationBuilder.DropTable(
                name: "playlist");

            migrationBuilder.DropTable(
                name: "track");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "album");

            migrationBuilder.DropTable(
                name: "genre");

            migrationBuilder.DropTable(
                name: "mediaType");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "artist");
        }
    }
}
