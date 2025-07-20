using MotoGP.Shared.BaseEntity;
using MotoGP.Shared.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoGP.Domain.Entities;

public class Rider : Entity<Guid>
{
    public string FullName { get; private set; } = default!;
    public string Nationality { get; private set; } = default!;
    public DateTime DateOfBirth { get; private set; }
    public Guid TeamId { get; private set; }

    // Navigation Property (optional if using EF Core)
    public Team? Team { get; private set; }

    private Rider() { } // EF Core needs parameterless constructor

    public Rider(Guid id, string fullName, string nationality, DateTime dateOfBirth, Guid teamId)
    {
        Guard.AgainstInvalidGuid(id, nameof(id));
        Guard.AgainstNullOrEmpty(fullName, nameof(fullName));
        Guard.AgainstNullOrEmpty(nationality, nameof(nationality));
        Guard.AgainstOutOfRange(dateOfBirth.Year, 1900, DateTime.UtcNow.Year, nameof(dateOfBirth));
        Guard.AgainstInvalidGuid(teamId, nameof(teamId));

        Id = id;
        FullName = fullName.Trim();
        Nationality = nationality.Trim();
        DateOfBirth = dateOfBirth;
        TeamId = teamId;
    }

    public void UpdateInfo(string fullName, string nationality, DateTime dateOfBirth)
    {
        Guard.AgainstNullOrEmpty(fullName, nameof(fullName));
        Guard.AgainstNullOrEmpty(nationality, nameof(nationality));
        Guard.AgainstOutOfRange(dateOfBirth.Year, 1900, DateTime.UtcNow.Year, nameof(dateOfBirth));

        FullName = fullName.Trim();
        Nationality = nationality.Trim();
        DateOfBirth = dateOfBirth;
    }
}
