using AutoMapper;
using BismillahGraphicsPro.Data;

namespace BismillahGraphicsPro.Repository;

public class ExpenseRepository: Repository, IExpenseRepository
{
    public ExpenseRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
    {
    }
}