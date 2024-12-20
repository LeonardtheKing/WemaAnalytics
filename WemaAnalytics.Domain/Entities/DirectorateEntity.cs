﻿namespace WemaAnalytics.Domain.Entities;

public class DirectorateEntity : BaseEntity
{
    public int DirectorateCode { get; set; }
    public string DirectorateName { get; set; } = string.Empty;


    // Navigation property back to ApplicationUser
    public List<ApplicationUser> ApplicationUser { get; set; } = default!;

    public ICollection<RegionEntity> Regions { get; set; } = new List<RegionEntity>(); // Navigation Property

    public DirectorateEntity()
    {

    }

}
