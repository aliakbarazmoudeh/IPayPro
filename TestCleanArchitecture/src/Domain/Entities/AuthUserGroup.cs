﻿namespace TestCleanArchitecture.Domain.Entities;

public partial class AuthUserGroup
{
    public long Id { get; set; }

    public int UserId { get; set; }

    public int GroupId { get; set; }

    public virtual AuthGroup Group { get; set; } = null!;

    public virtual AuthUser User { get; set; } = null!;
}
