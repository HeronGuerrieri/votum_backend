using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotumServer.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatorNavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectedOption",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "CreatedVotations",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ParticipatedVotations",
                table: "Users");

            migrationBuilder.AddColumn<Guid>(
                name: "VoteOptionId",
                table: "Votes",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Votations",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Votes_VoteOptionId",
                table: "Votes",
                column: "VoteOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Votations_CreatorId",
                table: "Votations",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Votations_UserId",
                table: "Votations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Votations_Users_CreatorId",
                table: "Votations",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votations_Users_UserId",
                table: "Votations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_VoteOptions_VoteOptionId",
                table: "Votes",
                column: "VoteOptionId",
                principalTable: "VoteOptions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votations_Users_CreatorId",
                table: "Votations");

            migrationBuilder.DropForeignKey(
                name: "FK_Votations_Users_UserId",
                table: "Votations");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_VoteOptions_VoteOptionId",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votes_VoteOptionId",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votations_CreatorId",
                table: "Votations");

            migrationBuilder.DropIndex(
                name: "IX_Votations_UserId",
                table: "Votations");

            migrationBuilder.DropColumn(
                name: "VoteOptionId",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Votations");

            migrationBuilder.AddColumn<string>(
                name: "SelectedOption",
                table: "Votes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<List<Guid>>(
                name: "CreatedVotations",
                table: "Users",
                type: "uuid[]",
                nullable: false);

            migrationBuilder.AddColumn<List<Guid>>(
                name: "ParticipatedVotations",
                table: "Users",
                type: "uuid[]",
                nullable: false);
        }
    }
}
