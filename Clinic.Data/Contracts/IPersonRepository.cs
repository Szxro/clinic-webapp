﻿using Clinic.Data.Entities;

namespace Clinic.Data.Contracts;

public interface IPersonRepository
{
    Task<bool> IsNifNotAvaliable(string nif);

    Task<bool> IsSocialNumberNotAvaliable(int socialNumber);
}
