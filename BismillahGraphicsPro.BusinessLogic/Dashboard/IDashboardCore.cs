﻿using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.BusinessLogic;

public interface IDashboardCore
{
    Task<List<DDL>> GetYearsAsync(string userName);
    Task<DashboardViewModel> GetAsync(string userName, int? year);
}