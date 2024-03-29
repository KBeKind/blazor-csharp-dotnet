﻿using BethanysPieShopHRM.Shared.Domain;

namespace BlazorBethanyPieShop.App.Services
{

    public interface IJobCategoryDataService
    {
        Task<IEnumerable<JobCategory>> GetAllJobCategories();
        Task<JobCategory> GetJobCategoryById(int jobCategoryId);
    }


}
