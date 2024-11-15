﻿using Moq;
using orbita_challenge.Domain.Repositories;

namespace CommonTestsUtilities.Repositories;
public class UnitOfWorkBuilder
{
    public static IUnitOfWork Build()
    {
        var mock = new Mock<IUnitOfWork>();

        return mock.Object;
    }
}