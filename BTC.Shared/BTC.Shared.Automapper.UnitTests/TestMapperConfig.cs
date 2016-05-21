using AutoMapper;

namespace BTC.Shared.Automapper.UnitTests
{
    public class TestMapperConfig : EntityModelBaseMapConfig<TestModel, TestViewModel>
    {
        protected override void MapToModel(IMappingExpression<TestModel, TestViewModel> map)
        {

        }

        protected override void MapToEntity(IMappingExpression<TestViewModel, TestModel> map)
        {
        }
    }
}